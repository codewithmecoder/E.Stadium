namespace E.Stadium.Core.Dto.Users;

public class SignUpDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Accept only (m, f, and o):
    /// m = male
    /// f = female
    /// o = other
    /// </summary>
    public string Gender { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public string Region { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
