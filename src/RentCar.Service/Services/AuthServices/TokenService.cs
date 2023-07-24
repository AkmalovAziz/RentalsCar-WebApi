using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentCar.Domain.Entities.Clients;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentCar.Service.Services.AuthServices;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public string GeneratedToken(Client client)
    {
        var identityClaims = new Claim[]
        {
            new Claim("Id", client.Id.ToString()),
            new Claim("FirstName", client.FirstName),
            new Claim("Lastname", client.LastName),
            new Claim(ClaimTypes.MobilePhone, client.PhoneNumber),
            new Claim(ClaimTypes.Role, client.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
