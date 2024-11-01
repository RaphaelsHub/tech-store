using System.ComponentModel.DataAnnotations;

namespace Store.DTO;

public record ProductDto(
    uint? Id = null,
    [Required]
    byte[]? Photo = null,
    [Required]
    string Name = "",
    [Required]
    string ShortDescription = "",
    [Required]
    string FullDescription = "",
    [Required]
    decimal Price = 0,
    [Required]
    uint Quantity = 0,
    [Required]
    string Category = ""
);
