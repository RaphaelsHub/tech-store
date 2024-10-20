using System.ComponentModel.DataAnnotations;

namespace Store.DTO;

public record LoginDto(
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [DataType(DataType.Password)]
    string Password
);