using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.DTO;

namespace Store.Pages.Home
{
    public class ErrorModel : PageModel
    {
        public ErrorDto Error { get; set; } = null!;

        public void OnGet(string? errorCode = null, string? errorMessage = null)
        {
            Error = new ErrorDto(
                errorCode ?? "Unknown error",
                errorMessage ?? "An unknown error occurred"
            );
        }
    }
}