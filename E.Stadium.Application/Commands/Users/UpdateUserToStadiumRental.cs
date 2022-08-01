using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;

public class UpdateUserToStadiumRental:ICommand
{
    public Guid Id { get; set; }

    public UpdateUserToStadiumRental(Guid id)
    {
        Id = id;
    }
}
