using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A1_QuizApp.Pages;

public class ResultModel : PageModel
{
    public void OnGet()
    {

    }
    public IActionResult OnPost()
    {
        return Page();
    }
} 