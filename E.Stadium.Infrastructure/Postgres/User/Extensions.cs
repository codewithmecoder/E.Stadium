using E.Stadium.Core.Dto.Users;
using E.Stadium.Core.Entities.Users;

namespace E.Stadium.Infrastructure.Postgres.User;

public static class Extensions
{
    public static UserTable AsTable(this UserEntity x)
        => new(
                id: x.Id,
                firstName: x.FirstName,
                lastName: x.LastName,
                gender: x.Gender,
                dOB: x.DOB,
                phone: x.Phone,
                region: x.Region,
                email: x.Email,
                password: x.PasswordHash,
                token: x.Token,
                resetToken: x.ResetToken,
                createdAt: x.CreatedAt,
                updatedAt: x.UpdatedAt,
                isActive: x.IsActive,
                isStadiumRental: x.IsStadiumRental == null ? false : x.IsStadiumRental,
                imageUrl: x.ImageUrl
            )
        { };

    public static UserEntity AsEntity(this UserTable x)
        => new(
                id: x.Id,
                firstName: x.FirstName,
                lastName: x.LastName,
                gender: x.Gender,
                dOB: x.DOB,
                phone: x.Phone ?? string.Empty,
                region: x.Region ?? string.Empty,
                email: x.Email ?? string.Empty,
                password: x.Password ?? string.Empty,
                passwordHash: x.Password ?? string.Empty,
                token: x.Token ?? string.Empty,
                resetToken: x.ResetToken ?? string.Empty,
                createdAt: x.CreatedAt,
                updatedAt: x.UpdatedAt,
                isActive: x.IsActive,
                isStadiumRental: x.IsStadiumRental == null ? false : x.IsStadiumRental,
                imageUrl: x.ImageUrl
            )
        { };
    public static UserDto AsUserDto(this UserEntity x)
        => new()
        {
            Id = x.Id.ToString(),
            FirstName = x.FirstName ?? string.Empty,
            LastName = x.LastName ?? string.Empty,
            DOB = x.DOB,
            Email = x.Email,
            Gender = x.Gender,
            Phone = x.Phone,
            Region = x.Region,
            FullName = x.GetFullName(),
            IsActive = x.IsActive,
            IsStadiumRental = x.IsStadiumRental,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            ImageUrl = x.ImageUrl
        };
}
