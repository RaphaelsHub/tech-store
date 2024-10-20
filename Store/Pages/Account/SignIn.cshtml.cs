using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Account;

public class SignInModel : PageModel
{
    [BindProperty]
    public LoginDto LoginInput { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            // Если валидация не прошла, вернем страницу с ошибками
            return Page();
        }

        // Логика аутентификации пользователя
        // Например, проверка логина и пароля в базе данных

        // В случае успеха можно перенаправить пользователя на другую страницу:
        return RedirectToPage("/Index");
    }
}