using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Products;

public class SingleProduct : PageModel
{
    public ProductDto? Product { get; set; } = null;
    
    public void OnGet()
    {
        
    }
}