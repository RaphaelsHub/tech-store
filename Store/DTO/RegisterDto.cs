using System.ComponentModel.DataAnnotations;

namespace Store.DTO;

public record RegisterDto(
    [Required]
    [StringLength(30, MinimumLength = 4)]
    string Name,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [Phone]
    string Number,
    [Required]
    [StringLength(100, MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[A-Za-z]{4,})(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password must contain at least 4 letters, 1 digit, and 1 special character.")]
    string Password
);
