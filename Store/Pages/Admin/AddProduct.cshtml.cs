using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Admin;

public class AddProduct : PageModel
{
    public ProductDto Product { get; set; }
    
    public void OnGet()
    {
        
    }
}