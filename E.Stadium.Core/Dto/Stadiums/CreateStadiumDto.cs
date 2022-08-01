namespace E.Stadium.Core.Dto.Stadiums;

public class CreateStadiumDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public string? Address { get; set; }
    public List<string>? StadiumImageUrls { get; set; }
}
