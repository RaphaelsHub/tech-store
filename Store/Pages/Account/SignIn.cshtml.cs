using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess;
using Store.DataAccess.Interfaces;
using Store.DataAccess.Interfaces.InterfacesExtensions;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Account;

public class SignInModel(IRepository<AccountEf> repository, StoreDbContext dbContext, IMapper mapper) : PageModel
{
    [BindProperty] public LoginDto LoginInput { get; set; } = null!; 

    public void OnGet() { }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();
        
        var userEf = mapper.Map<AccountEf>(LoginInput);
        
        var user = await repository.FindByEmailAsync(dbContext, userEf.Email ?? "NotFound");
        
        if (user == null)
        {
            ModelState.AddModelError("LoginInput.Email", "User with this email not found");
            return Page();
        }
        
        if (user.PasswordHash != userEf.PasswordHash)
        {
            ModelState.AddModelError("LoginInput.Password", "Invalid password");
            return Page();
        }

        return RedirectToPage("/Home/Index");
    }
}