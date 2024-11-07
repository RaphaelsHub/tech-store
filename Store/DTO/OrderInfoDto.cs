using System.ComponentModel.DataAnnotations;

namespace Store.DTO;

public record OrderInfoDto(
    uint Id,
    [Required]
    string Name, 
    [Required]
    [EmailAddress]
    string Email, 
    [Required]
    [Phone]
    string Phone, 
    [Required]
    string Country,
    [Required]
    string City,
    [Required]
    string Address,
    string Comment
);