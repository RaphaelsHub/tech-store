using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DataAccess.Repository;
using Store.DTO;

namespace Store.Pages.Products;

public class SingleProduct(
    IRepository<ProductEf> productsRepository,
    CartsRepository cartsRepository,
    IMapper mapper) : PageModel
{
    public ProductDto Product { get; set; } = null!;
    public async Task<IActionResult> OnGetAsync(uint id)
    {
        Product = mapper.Map<ProductDto>(await productsRepository.GetAsync(id));
        return Page();
    }
}