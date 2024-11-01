using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Shop;

public class OrderModel(IRepository<OrderEf> repository, IMapper mapper) : PageModel
{
    [BindProperty]
    public OrderInfoDto OrderInfo { get; set; }
    
    public void OnGet()
    {
        
    }

    
    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();
        var order = mapper.Map<OrderEf>(OrderInfo);
        order.AccountId = 1;
        await repository.CreateAsync(order);
        
        return RedirectToPage("/Home/ThanksForOrder");
    }
}