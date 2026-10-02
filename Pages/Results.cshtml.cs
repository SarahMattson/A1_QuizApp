using System.Dynamic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using A1_QuizApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace A1_QuizApp.Pages;

public class ResultModel : PageModel
{
    public List<string> UserAnswers { get; set; }
    public Quiz UserQuiz { get; set; }
    public bool OkData { get; set; } = true;

    public void OnGet()
    {

        List<string> answers = TempData["sendAnswers"] as List<string>;
        var quiz = TempData["userQuiz"];

        if (answers == null)
        {
            OkData = false;
        }
        if (string.IsNullOrEmpty(quiz.ToString()))
        {
            OkData = false;
        }

        if (OkData)
        {
            UserAnswers = answers;
            UserQuiz = JsonSerializer.Deserialize<Quiz>(quiz.ToString(), JsonOptions) ;
            OkData = true;
        }

    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,    
    };

 
} 