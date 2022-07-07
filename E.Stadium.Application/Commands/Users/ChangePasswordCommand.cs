using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;

public class ChangePasswordCommand : ICommand
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

    public ChangePasswordCommand(Guid userId, string oldPassword, string newPassword)
    {
        UserId = userId;
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
}
