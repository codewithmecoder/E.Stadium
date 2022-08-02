namespace E.Stadium.Core.Dto.Stadiums;

public class UpdateStadiumDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public string? Address { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
}
