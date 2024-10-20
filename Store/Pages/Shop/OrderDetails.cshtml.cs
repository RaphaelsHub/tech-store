using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Shop;

public class OrderDetails : PageModel
{
    public OrderInfoDto Order { get; set; }
    public List<CartItem> Products { get; set; }

    public IActionResult OnGet(int id)
    {
        return Page();
    }
}