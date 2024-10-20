using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Home;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public ProductsDto ProductsDto { get; set; } = new (new List<ProductDto>());

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
    public async Task<IActionResult> OnPostLogoutAsync()
    {
        //await HttpContext.SignOutAsync();
        return RedirectToPage("/Home/Index");
    }

}