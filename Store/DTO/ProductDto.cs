using System.ComponentModel.DataAnnotations;

namespace Store.DTO;

public record ProductDto(
    int Id,
    [Required]
    byte[] Photo,
    [Required]
    string Name,
    [Required]
    string ShortDescription,
    [Required]
    string FullDescription,
    [Required]
    decimal Price,
    [Required]
    uint Quantity,
    [Required]
    string Category
    );