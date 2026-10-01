using Microsoft.AspNetCore.Mvc.RazorPages;
using A1_QuizApp.Models;
using System.Text.Json;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Json;

namespace A1_QuizApp.Pages;

public class InputModel : PageModel
{
    public Quiz YourQuiz { get; set; } = new Quiz(); 

    public void OnGet(string selectedQuiz)
    {
        QuizParser(selectedQuiz);
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,    
    };

    private void QuizParser (string selectedQuiz)
    {
        string jsonString = System.IO.File.ReadAllText("./AppData/" + selectedQuiz + ".json");
        YourQuiz = JsonSerializer.Deserialize<Quiz>(jsonString, JsonOptions) ?? new Quiz();
    }
}