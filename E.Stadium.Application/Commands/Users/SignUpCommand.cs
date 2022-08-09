using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Users;
public class SignUpCommand : ICommand
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    /// <summary>
    /// Accept only (m, f, and o):
    /// m = male
    /// f = female
    /// o = other
    /// </summary>
    public string Gender { get; set; }
    public DateTime DOB { get; set; }
    public string Region { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string? ImageUrl { get; set; }

    public SignUpCommand(
        Guid id,
        string firstName,
        string lastName,
        string gender,
        DateTime dOB,
        string region,
        string phone,
        string password,
        string? imageUrl)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DOB = dOB;
        Region = region;
        Phone = phone;
        Password = password;
        ImageUrl = imageUrl;
    }
}
