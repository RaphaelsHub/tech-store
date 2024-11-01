using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DataAccess;
using Store.DataAccess.InterfaceExtensions;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.Pages.Account;

public class SignUpModel(IRepository<AccountEf> repository, IMapper mapper, StoreDbContext dbContext) : PageModel
{
    [BindProperty]
    public RegisterDto? RegisterInput { get; set; }
    
    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var userEf = mapper.Map<AccountEf>(RegisterInput);
        var user = await repository.FindByEmailAsync(dbContext, userEf.Email!);
        
        if (user != null)
        {
            ModelState.AddModelError("Register.Email", "User with this email already exists");
            return Page();
        }

        await repository.CreateAsync(userEf);
        
        return RedirectToPage("/Account/SignIn");
    }
}