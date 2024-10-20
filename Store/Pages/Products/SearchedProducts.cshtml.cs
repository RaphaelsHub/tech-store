using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Products;

public class SearchedProducts : PageModel
{
    public ProductsDto Products { get; set; } = new(new List<ProductDto>());

    public void OnGet()
    {
        
    }
}