using System.Dynamic;
using System.Text.Json;
using A1_QuizApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A1_QuizApp.Pages;

public class ResultModel : PageModel
{
    public string[] UserAnswers { get; set; }
    public Quiz UserQuiz { get; set; }
    public bool OkData { get; set; } = true;

    public void OnGet(string userQuiz, string sendAnswers)
    {
        string quiz = TempData["userQuiz"].ToString();
        string answers = TempData["sendAnswers"].ToString();

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
            UserAnswers = answers.Split(" q ");
            UserQuiz = JsonSerializer.Deserialize<Quiz>(quiz.ToString(), JsonOptions);
            OkData = true;
        }
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
}

