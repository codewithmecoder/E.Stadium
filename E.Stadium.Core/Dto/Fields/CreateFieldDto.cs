namespace E.Stadium.Core.Dto.Fields;

public class CreateFieldDto
{
    public string? Name { get; set; }
    public int NumberOfPoeple { get; set; }
    public string? Size { get; set; }
    public List<string>? FieldImageUrls { get; set; }
}
