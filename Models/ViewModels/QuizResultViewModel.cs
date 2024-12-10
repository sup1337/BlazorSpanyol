namespace BlazorSpanyol.Models.ViewModels;

public class QuizResultViewModel
{
    public string Hungarian { get; set; }
    public string English { get; set; }
    public string UserAnswer { get; set; }
    public string CorrectSpanish { get; set; }
    public bool IsCorrect { get; set; }
}