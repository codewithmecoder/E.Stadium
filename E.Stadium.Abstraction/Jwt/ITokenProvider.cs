using System.Security.Claims;

namespace E.Stadium.Abstraction.Jwt;

public interface ITokenProvider<TUser> where TUser : class
{
    string CreateToken(TUser user, string userId, string deviceId);

    string CreateToken(TUser user, string userId);

    string CreateToken(string id, string code);

    string CreateToken(Claim[] claims);

    bool ValidateToken(string token);
}
