namespace BlazorSpanyol.Models.Domain;

public class Words
{
    public Guid Id { get; set; }
    
    public string Hungarian { get; set; } // Magyar szó
    
    public string English { get; set; }   // Angol szó
    
    public string CorrectSpanish { get; set; } // Helyes spanyol fordítás
}