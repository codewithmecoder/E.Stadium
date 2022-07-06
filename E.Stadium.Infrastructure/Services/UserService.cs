using E.Stadium.Abstraction.Utilities;
using E.Stadium.Abstraction.Vonage;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Services.Interfaces;
using E.Stadium.Shared.Postgres;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace E.Stadium.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;
    private readonly IPhoneParser _phoneParser;
    private readonly IVonage _vonage;

    public UserService(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher, IPhoneParser phoneParser, IVonage vonage)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _phoneParser = phoneParser;
        _vonage = vonage;
    }

    public Task<bool> ExistPhoneAsync(string phone, string region)
    {
        var validPhone = _phoneParser.Parse(phone, region);
        return _userRepository.ExistPhoneAsync(validPhone);
    }

    public async Task<UserEntity> LoginAsync(string phone, string region, string password)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new FieldRequireException(nameof(phone));

        if (string.IsNullOrWhiteSpace(region))
            throw new FieldRequireException(nameof(region));

        if (string.IsNullOrWhiteSpace(password))
            throw new FieldRequireException(nameof(password));
        /// this condition is for specific user only, use for global user
        if (phone.IndexOf("0") == 0 && phone == "011000000")
            phone = "11000000";
        if (phone == "11000000")
        {
            region = "kh";
        }
        var validPhone = _phoneParser.Parse(phone, region);
        var user = await _userRepository.GetByPhoneAsync(validPhone);

        if (user is not null && user.ValidatePassword(password, _passwordHasher))
        {
            return user;
        }

        throw new LoginFailedException();
    }

    public async Task<VonageResult> RequestVerifyCode(string phone, string region, string message = "Your verify", string userId = "")
    {
        var validPhone = _phoneParser.Parse(phone, region);
        var result = await _vonage.RequestAsync(validPhone, message);

        if (result.StatusCode == "0")
        {
            if (string.IsNullOrEmpty(userId))
            {
                await SetResetPasswordTokenByPhone(validPhone, result.RequestId);
            }
            else
            {
                await _userRepository.SetResetPasswordTokenByUserId(userId.ToGuid(), result.RequestId);
            }
        }

        return result;
    }

    public async Task ResetPassword(string token, string password)
    {

        var user = await _userRepository.GetByResetTokenAsync(token);
        if (user is { })
        {
            user.SetPassword(password, _passwordHasher);
            user.ResetToken = "";

            await _userRepository.UpdateAsync(user);
        }
    }

    public Task SetResetPasswordTokenByPhone(string phone, string token)
    {
        return _userRepository.SetResetPasswordTokenByPhone(phone, token);
    }
    public async Task SignupAsync(UserEntity user)
    {
        if (user is null)
            throw new FailedToSignUpException();
        if (string.IsNullOrEmpty(user.Password))
            throw new FieldRequireException("Password");

        user.SetPassword(user.Password, _passwordHasher);
        user.ParsePhone(_phoneParser);

        if (await _userRepository.ExistPhoneAsync(user.Phone!))
            throw new ExistedPhoneException(user.Phone!);

        await _userRepository.AddAsync(user);
    }

    public Task StoreToken(UserEntity user, string token, IDataProtector protector)
    {
        if (user is null || string.IsNullOrWhiteSpace(token))
            throw new FailedToUpdateUserException();

        user.SetToken(token, protector);

        return _userRepository.UpdateAsync(user);
    }

    public Task UpdateResetPasswordToken(string oldToken, string newToken)
    {
        return _userRepository.SetResetPasswordTokenByResetToken(oldToken, newToken);
    }
}
