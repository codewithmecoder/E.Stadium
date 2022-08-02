using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Fields;

public class UpdateFieldCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public int NumberOfPoeple { get; set; }
    public string? Size { get; set; }
    public string? Name { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public UpdateFieldCommand(
        Guid id,
        Guid stadiumId,
        int numberOfPoeple,
        string? size,
        string? name,
        DateTime? updatedAt)
    {
        Id = id;
        StadiumId = stadiumId;
        NumberOfPoeple = numberOfPoeple;
        Size = size;
        Name = name;
        UpdatedAt = updatedAt;
    }
}
