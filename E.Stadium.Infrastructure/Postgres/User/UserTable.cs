using E.Stadium.Shared.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Infrastructure.Postgres.User;

[Table("users")]
public class UserTable : BasePostgresTable
{
    [Column("first_name")]
    public string? FirstName { get; set; }
    [Column("last_name")]
    public string? LastName { get; set; }
    [Column("gender")]
    public string? Gender { get; set; }
    [Column("dob")]
    public DateTime? DOB { get; set; }
    [Column("phone")]
    public string? Phone { get; set; }
    [Column("region")]
    public string? Region { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    [Column("token")]
    public string? Token { get; set; }
    [Column("reset_token")]
    public string? ResetToken { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }
    [Column("is_stadium_rental")]
    public bool? IsStadiumRental { get; set; }

    public UserTable(
        Guid id,
        string? firstName,
        string? lastName,
        string? gender,
        DateTime? dOB,
        string? phone,
        string? region,
        string? email,
        string? password,
        string? token,
        string? resetToken,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive,
        bool? isStadiumRental)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DOB = dOB;
        Phone = phone;
        Region = region;
        Email = email;
        Password = password;
        Token = token;
        ResetToken = resetToken;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
        IsStadiumRental = isStadiumRental;
    }
}
