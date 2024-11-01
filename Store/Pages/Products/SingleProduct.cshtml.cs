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
    const string MessageSuccess = "Product added to cart";
    const string MessageError = "Not enough quantity";

    public async Task<IActionResult> OnGetAsync(uint id)
    {
        Product = mapper.Map<ProductDto>(await productsRepository.GetAsync(id));
        return Page();
    }

    public async Task<IActionResult> OnPostAddProductAsync(uint id, uint quantity)
    {
        var product = await productsRepository.GetAsync(id);
            
        if (product != null && product.Quantity < quantity)
        {
            TempData["Message"] = MessageError;
            return RedirectToPage("/Products/SingleProduct", new { id });
        }
        
        var result = await cartsRepository.AddProductAsync(1, quantity, id);
        
        TempData["Message"] = result ? MessageSuccess : MessageError;
        return RedirectToPage("/Products/SingleProduct", new { id });
    }
}