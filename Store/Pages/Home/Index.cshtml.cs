using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Home;

public class IndexModel(IRepository<ProductEf> repository, IMapper mapper) : PageModel
{
    public ProductsDto ProductsDto { get; set; } = null!;

    public async  Task<IActionResult> OnGetAsync()
    {
        var productsEf = await repository.GetAllAsync();
        var productDtoList = productsEf.Select(product => mapper.Map<ProductDto>(product)).ToList();
        ProductsDto = new ProductsDto(productDtoList);
        return Page();
    }
    
    
    public async Task<IActionResult> OnPostLogoutAsync()
    {
        
        //await HttpContext.SignOutAsync();
        return RedirectToPage("/Home/Index");
    }

}