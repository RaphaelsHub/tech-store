using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Admin;

public class AllDeliveriesModel(IRepository<OrderEf> repository, IMapper mapper) : PageModel
{
    [BindProperty] public List<OrderInfoDto> Orders { get; set; } = null!;
    
    public async Task<IActionResult> OnGet()
    {
        var _ = await repository.GetAllAsync();
        Orders = mapper.Map<List<OrderInfoDto>>(_);
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteOrderAsync(uint? id)
    {
        await repository.DeleteAsync(id ?? throw new ArgumentNullException(nameof(id)));
        return RedirectToPage("/Admin/AllDeliveries");
    }
    
    public IActionResult OnPostViewOrderAsync(uint? id) =>
        RedirectToPage("/Shop/OrderDetails", new { id });
}