using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Admin;

public class AllProductsModel(IRepository<ProductEf> repository, IMapper mapper) : PageModel
{
    public ProductsDto Products { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        var productsEf = await repository.GetAllAsync();
        var productDtoList = productsEf.Select(product => mapper.Map<ProductDto>(product)).ToList();
        Products = new ProductsDto(productDtoList);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteProductAsync(uint? id)
    {
        await repository.DeleteAsync(id ?? throw new ArgumentNullException(nameof(id)));
        return RedirectToPage("/Admin/AllProducts");
    }

    public IActionResult OnPostEditProductAsync(uint? id) =>
        RedirectToPage("/Admin/AddProduct", new { id });

    public IActionResult OnPostViewProductAsync(uint? id) =>
        RedirectToPage("/Products/SingleProduct", new { id });
}