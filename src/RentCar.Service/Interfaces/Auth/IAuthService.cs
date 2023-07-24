using RentCar.Service.Dtos.Auth;

namespace RentCar.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistrDto dto);

    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code);

    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);
}
