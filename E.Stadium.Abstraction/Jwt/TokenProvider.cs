using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E.Stadium.Abstraction.Jwt
{
    public class TokenProvider<TUser> : ITokenProvider<TUser> where TUser : class
    {
        private readonly IServiceProvider _serviceProvider;

        public TokenProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string CreateToken(TUser user, string userId, string deviceId)
        {
            return CreateToken(new Claim[2]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userId),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", deviceId)
            });
        }

        public string CreateToken(string id, string code)
        {
            return CreateToken(new Claim[2]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", id),
                new Claim("Code", code)
            });
        }

        public string CreateToken(Claim[] claims)
        {
            JwtOptions requiredService = _serviceProvider.GetRequiredService<JwtOptions>();
            byte[] bytes = Encoding.UTF8.GetBytes(requiredService.SigningKey);
            int expiryInMinutes = requiredService.ExpiryInMinutes;
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"),
                Issuer = requiredService.Site,
                Audience = requiredService.Audience
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

        public string CreateToken(TUser user, string userId)
        {
            return CreateToken(new Claim[1]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userId)
            });
        }

        public bool ValidateToken(string token)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            TokenValidationParameters validationParameters = GetValidationParameters();
            jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out var _);
            return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            JwtOptions requiredService = _serviceProvider.GetRequiredService<JwtOptions>();
            return new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = requiredService.Site,
                ValidAudience = requiredService.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(requiredService.SigningKey))
            };
        }
    }
}
