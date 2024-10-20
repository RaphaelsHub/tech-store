using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Account;

public class SignUpModel : PageModel
{
    [BindProperty]
    public RegisterDto Register { get; set; }
    
    public void OnGet()
    {
        
    }
}