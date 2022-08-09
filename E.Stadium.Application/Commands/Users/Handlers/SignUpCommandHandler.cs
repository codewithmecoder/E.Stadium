using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Utilities;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;
    private readonly IPhoneParser _phoneParser;

    public SignUpCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher<UserEntity> passwordHasher,
        IPhoneParser phoneParser)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _phoneParser = phoneParser;
    }
    public async Task HandleAsync(SignUpCommand cmd)
    {
        var user = new UserEntity(
            id: cmd.Id,
            firstName: cmd.FirstName,
            lastName: cmd.LastName,
            gender: cmd.Gender,
            dOB: cmd.DOB,
            phone: cmd.Phone,
            region: cmd.Region,
            email: string.Empty,
            password: cmd.Password,
            passwordHash: cmd.Password,
            token: string.Empty,
            resetToken: string.Empty,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            isActive: true,
            isStadiumRental: false,
            imageUrl: cmd.ImageUrl);

        user.SetPassword(user.Password!, _passwordHasher);
        user.ParsePhone(_phoneParser);
        if (await _userRepository.ExistPhoneAsync(user.Phone!))
            throw new ExistedPhoneException(user.Phone!);

        await _userRepository.AddAsync(user);
    }
}
