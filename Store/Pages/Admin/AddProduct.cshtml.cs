using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Admin;

public class AddProductModel(IRepository<ProductEf> repository, IMapper mapper) : PageModel
{
    [BindProperty] public ProductDto Product { get; set; } = null!;

    public async Task<IActionResult> OnGet(uint? id)
    {
        Product = id is null
            ? new ProductDto()
            : mapper.Map<ProductDto>(await repository.GetAsync((uint)id));

        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var productEf = mapper.Map<ProductEf>(Product);

        if (Product.Id is not null && await repository.GetAsync((uint)Product.Id) is not null)
        {
            await repository.UpdateAsync(productEf);
            return RedirectToPage("/Admin/AllProducts");
        }

        await repository.CreateAsync(productEf);
        return RedirectToPage("/Admin/AllProducts");
    }
}