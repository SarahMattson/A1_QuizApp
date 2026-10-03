using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using A1_QuizApp.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A1_QuizApp.Pages;

public class InputModel : PageModel
{
    public Quiz YourQuiz { get; set; } = new Quiz();
    public Boolean DataOk = true;
    public string Error;

    public void OnGet(string selectedQuiz)
    {
        DataOk = true;
        QuizParser(selectedQuiz);
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    private void QuizParser(string selectedQuiz)
    {
        string jsonString = System.IO.File.ReadAllText("./AppData/" + selectedQuiz + ".json");
        YourQuiz = JsonSerializer.Deserialize<Quiz>(jsonString, JsonOptions) ?? new Quiz();
    }

    public IActionResult OnPost(string selectedQuiz)
    {
        QuizParser(selectedQuiz);
        string userAnswers = "";

        for (int i = 0; i < YourQuiz.Questions.Count; i++)
        {
            string? selection = Request.Form[$"question{i}"];

            if (string.IsNullOrEmpty(selection))
            {
                Error = "Please answer all the questions. :)";
                DataOk = false;
                return Page();
            }
            userAnswers += selection.ToString() + " q ";
        }

        TempData["sendAnswers"] = userAnswers;
        TempData["userQuiz"] = JsonSerializer.Serialize(YourQuiz).ToString();
        return RedirectToPage("./Results");
    }
}