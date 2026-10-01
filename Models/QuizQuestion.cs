namespace A1_QuizApp.Models
{
    public class QuizQuestion
    {
        public string QuestionText { get; set; } = "";
        public List<string> Choices { get; set; } = new();
        public int AnswerIndex { get; set; }
    }
}
