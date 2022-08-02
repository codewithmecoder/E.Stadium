using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Fields;

public class CreateFieldCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public int NumberOfPoeple { get; set; }
    public string? Size { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public List<string>? FieldImageUrls { get; set; }

    public CreateFieldCommand(
        Guid id,
        Guid stadiumId,
        int numberOfPoeple,
        string? size,
        string? name,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        StadiumId = stadiumId;
        NumberOfPoeple = numberOfPoeple;
        Size = size;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }
}
