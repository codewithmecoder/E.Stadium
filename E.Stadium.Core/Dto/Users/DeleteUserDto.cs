namespace E.Stadium.Core.Dto.Users;

public class DeleteUserDto
{
    public Guid Id { get; set; }

    public DeleteUserDto(Guid id)
    {
        Id = id;
    }
}
