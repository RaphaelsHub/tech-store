using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Shop;

public class Cart : PageModel
{
    public CartDto Products { get; set; } = new CartDto(new List<CartItem>());
    
    public void OnGet()
    {
        
    }
}