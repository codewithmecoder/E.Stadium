using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;

public class UpdateUserCommand : ICommand
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;
    public DateTime? DOB { get; set; }
    public string? Email { get; set; } = string.Empty;

    public UpdateUserCommand(
        Guid userId,
        string? firstName,
        string? lastName,
        string? gender,
        DateTime? dOB,
        string? email)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DOB = dOB;
        Email = email;
    }
}
