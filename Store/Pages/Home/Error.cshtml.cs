using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Home
{
    public class ErrorModel(ErrorDto errorDto) : PageModel
    {
        public ErrorDto ErrorInfo { get; set; } = errorDto;

        public void OnGet()
        {
            // Здесь можно добавить логику, если это необходимо
        }
    }
}