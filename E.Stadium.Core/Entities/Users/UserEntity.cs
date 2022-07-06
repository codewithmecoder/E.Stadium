using E.Stadium.Abstraction.Data;
using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Utilities;
using E.Stadium.Core.Exceptions.User;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace E.Stadium.Core.Entities.Users;

public class UserEntity : IEntity
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime? DOB { get; set; }
    public string? Phone { get; set; }
    public string? Region { get; set; }

    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordHash { get; set; }
    public string? Token { get; set; }
    public string? ResetToken { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public UserEntity(
        Guid id,
        string? firstName,
        string? lastName,
        string? gender,
        DateTime? dOB,
        string phone,
        string region,
        string email,
        string password,
        string passwordHash,
        string token,
        string resetToken,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DOB = dOB;
        Phone = phone;
        Region = region;
        Email = email;
        Password = password;
        PasswordHash = passwordHash;
        Token = token;
        ResetToken = resetToken;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public UserEntity(Guid id)
    {
        Id = id;
    }

    public void SetPassword(string password, IPasswordHasher<UserEntity> passwordHasher)
    {
        if (string.IsNullOrWhiteSpace(password) || passwordHasher is null)
            throw new InvalidPasswordException();

        PasswordHash = passwordHasher.HashPassword(this, password);
    }
    public void SetToken(string token, IDataProtector protector)
        => Token = protector.Protect(token);
    public string GetToken(IDataProtector protector)
    {
        try
        {
            return protector.Unprotect(Token!);
        }
        catch
        {
            return string.Empty;
        }
    }
    public bool ValidatePassword(string password, IPasswordHasher<UserEntity> passwordHasher)
        => passwordHasher?.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;

    public void ParsePhone(IPhoneParser phoneParser)
        => Phone = phoneParser?.Parse(Phone!, Region!) ?? string.Empty;

    public string CreateToken(ITokenProvider<UserEntity> tokenProvider, string deviceId)
        => tokenProvider?.CreateToken(this, Id.ToString(), deviceId) ?? throw new FailedToCreateTokenException();

    public string GetFullName()
        => $"{FirstName} {LastName}";
}
