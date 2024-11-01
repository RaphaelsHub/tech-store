using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DataAccess.Repository;
using Store.DTO;

namespace Store.Pages.Shop;

public class Cart(IRepository<ProductEf> repository, CartsRepository cartsRepository, IMapper mapper) : PageModel
{
    public CartDto Products { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var cartProducts =await cartsRepository.GetCartProductsAsync(1);
        if (cartProducts == null) return Page();
        
        var listCartItem =  cartProducts.Select(m=>new CartItem(m.Product.Photo, m.Product.Name, m.Product.Price,(int)m.Quantity,m.AccountId)).ToList();

        Products = new CartDto(listCartItem);

        decimal totalPrice = Products.Total;
        decimal deliveryPrice = Products.DeliveryPrice;
        decimal total = Products.TotalPrice;
        
        
        
        
        return Page();
    }
}