using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DataAccess.Repository;
using Store.DTO;

namespace Store.Pages.Shop;

public class Cart(IRepository<ProductEf> repository, IRepository<AccountEf> repositorya, StoreDbContext cont, CartsRepository cartsRepository, IMapper mapper) : PageModel
{
    const string MessageSuccess = "Product added to cart";
    const string MessageError = "Not enough quantity";

    public CartDto Products { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var cartProducts =await cartsRepository.GetCartProductsAsync(1);
        if (cartProducts == null) return Page();
        
        var listCartItem =  cartProducts.Select(m=>new CartItem(m.Product.Photo, m.Product.Name, m.Product.Price,(int)m.Quantity,m.Product.Id)).ToList();

        Products = new CartDto(listCartItem);
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteCartItemAsync(uint productId, uint quantity)
    {
        await cartsRepository.RemoveProductAsync(1, productId, quantity);
        return RedirectToPage("/Shop/Cart");
    }
    
    public async Task<IActionResult> OnPostAddProductAsync(uint id, uint quantity)
    {
        var product = await repository.GetAsync(id);
            
        if (product != null && product.Quantity < quantity)
        {
            TempData["Message"] = MessageError;
            return RedirectToPage("/Products/SingleProduct", new { id });
        }


        var result = await cartsRepository.AddProductAsync(1, id, quantity);
        
        TempData["Message"] = result ? MessageSuccess : MessageError;
        return RedirectToPage("/Products/SingleProduct", new { id });
    }
}