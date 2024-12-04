namespace BlazorSpanyol.Models.ViewModels;

public class EditWordsRequest
{
    public Guid Id { get; set; }
    
    public string Hungarian { get; set; }
    
    public string English { get; set; }
    
    public string CorrectSpanish { get; set; }
    
}