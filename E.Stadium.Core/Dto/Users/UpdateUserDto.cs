﻿namespace E.Stadium.Core.Dto.Users;

public class UpdateUserDto
{
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;
    public DateTime? DOB { get; set; }
    public string? Region { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
}
