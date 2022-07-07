using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;

public class ActiveInActiveUserCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid CurrentUserId { get; set; }
    public bool IsActive { get; set; }

    public ActiveInActiveUserCommand(Guid id, bool isActive, Guid currentUserId)
    {
        Id = id;
        IsActive = isActive;
        CurrentUserId = currentUserId;
    }
}
