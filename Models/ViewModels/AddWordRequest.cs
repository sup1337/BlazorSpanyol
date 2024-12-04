using System.ComponentModel.DataAnnotations;

namespace BlazorSpanyol.Models.ViewModels;

public class AddWordRequest
{
    [Required]
    public string Hungarian { get; set; }
    [Required]
    public string English { get; set; }
    [Required]
    public string CorrectSpanish { get; set; }
}