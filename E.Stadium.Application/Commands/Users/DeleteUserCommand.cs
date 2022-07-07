using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;

public class DeleteUserCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid CurrentUserId { get; set; }


    public DeleteUserCommand(Guid id, Guid currentUserId)
    {
        Id = id;
        CurrentUserId = currentUserId;
    }
}
