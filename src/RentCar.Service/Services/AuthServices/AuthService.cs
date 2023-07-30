using Microsoft.Extensions.Caching.Memory;
using RentCar.DataAccess.Interfaces.Clients;
using RentCar.Domain.Entities.Clients;
using RentCar.Domain.Exceptions.Auth;
using RentCar.Domain.Exceptions.Client;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Common.Security;
using RentCar.Service.Dtos.Auth;
using RentCar.Service.Dtos.Notification;
using RentCar.Service.Dtos.Security;
using RentCar.Service.Interfaces.Auth;
using RentCar.Service.Interfaces.Notification;

namespace RentCar.Service.Services.AuthServices;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memorycache;
    private readonly ISmsSender _sender;
    private readonly ITokenService _token;
    private readonly IClientRepository _clientRepository;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;
    public AuthService(IMemoryCache memoryCache, ISmsSender smsSender, IClientRepository clientRepository,
        ITokenService tokenService)
    {
        this._memorycache = memoryCache;
        this._sender = smsSender;
        this._token = tokenService;
        this._clientRepository = clientRepository;
    }

#pragma warning disable
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistrDto dto)
    {
        var user = await _clientRepository.GetByPhoneNumberAsync(dto.PhoneNumber);
        if (user is not null) throw new ClientAllreadyExistsExseption(dto.PhoneNumber);

        // delete if exists user by this phone number
        if (_memorycache.TryGetValue(REGISTER_CACHE_KEY + dto.PhoneNumber, out RegistrDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memorycache.Remove(REGISTER_CACHE_KEY + dto.PhoneNumber);
        }
        else _memorycache.Set(REGISTER_CACHE_KEY + dto.PhoneNumber, dto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        if (_memorycache.TryGetValue(REGISTER_CACHE_KEY + phone, out RegistrDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

            // make confirm code as random
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();

            if (_memorycache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + phone, out VerificationDto oldVerifcationDto))
            {
                _memorycache.Remove(VERIFY_REGISTER_CACHE_KEY + phone);
            }

            _memorycache.Set(VERIFY_REGISTER_CACHE_KEY + phone, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            SmsMessage smsMessage = new SmsMessage();
            smsMessage.Title = "Rent Car";
            smsMessage.Content = "Your verification code : " + verificationDto.Code;
            smsMessage.Recipient = phone.Substring(1);

            var smsResult = await _sender.SendAsync(smsMessage);
            if (smsResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new ClientCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        if (_memorycache.TryGetValue(REGISTER_CACHE_KEY + phone, out RegistrDto registerDto))
        {
            if (_memorycache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + phone, out VerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registerDto);
                    if (dbResult is true)
                    {
                        var user = await _clientRepository.GetByPhoneNumberAsync(phone);
                        string token = _token.GeneratedToken(user);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memorycache.Remove(VERIFY_REGISTER_CACHE_KEY + phone);
                    verificationDto.Attempt++;
                    _memorycache.Set(VERIFY_REGISTER_CACHE_KEY + phone, verificationDto,
                        TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpireException();
        }
        else throw new ClientCacheDataExpiredException();
    }

    private async Task<bool> RegisterToDatabaseAsync(RegistrDto registerDto)
    {
        var client = new Client();
        client.FirstName = registerDto.FirstName;
        client.LastName = registerDto.LastName;
        client.PhoneNumber = registerDto.PhoneNumber;

        var hasherResult = PasswordHasher.Hash(registerDto.Password);
        client.PasswordHAsh = hasherResult.Hash;
        client.Salt = hasherResult.Salt;
        client.Role = 0;
        client.IsMale = true;

        client.CreatedAt = client.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _clientRepository.CreatAsync(client);
        return dbResult > 0;
    }

    public async Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto)
    {
        var client = await _clientRepository.GetByPhoneNumberAsync(loginDto.PhoneNumber);
        if (client is null) throw new ClientNotFoundException();

        var hasherResult = PasswordHasher.Verify(loginDto.Password, client.PasswordHAsh, client.Salt);
        if (hasherResult == false) throw new PasswordNotMatchExceptions();

        string token = _token.GeneratedToken(client);
        return (Result: true, Token: token);
    }
}
