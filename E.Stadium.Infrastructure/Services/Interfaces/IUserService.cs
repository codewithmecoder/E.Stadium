using E.Stadium.Abstraction.Vonage;
using E.Stadium.Core.Entities.Users;
using Microsoft.AspNetCore.DataProtection;

namespace E.Stadium.Infrastructure.Services.Interfaces;

public interface IUserService
{
    Task SignupAsync(UserEntity user);
    Task<UserEntity> LoginAsync(string phone, string region, string password);
    Task StoreToken(UserEntity user, string token, IDataProtector protector);
    Task<bool> ExistPhoneAsync(string phone, string region);
    Task<VonageResult> RequestVerifyCode(string phone, string region, string message = "Your verify", string userId = "");
    Task UpdateResetPasswordToken(string oldToken, string newToken);
    Task ResetPassword(string token, string password);
}
