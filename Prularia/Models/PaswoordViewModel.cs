using System.ComponentModel.DataAnnotations;

namespace Prularia.Models;

public class PaswoordViewModel
{
    [Display(Name = "Paswoord")]
    [Required(ErrorMessage = "Verplicht")] //Deze errormessage wordt niet doorgegeven om een of andere reden
    public string? OudPaswoord {  get; set; }

    [Display(Name = "Nieuw paswoord")]
    [Required(ErrorMessage = "Verplicht")] //Deze errormessage wordt niet doorgegeven om een of andere reden
    [StringLength(int.MaxValue, ErrorMessage = "Te kort", MinimumLength = 8)]
    public string? NieuwPaswoord {  get; set; }

    [Display(Name = "Confirmeer nieuw paswoord")]
    [Required(ErrorMessage = "Verplicht")] //Deze errormessage wordt niet doorgegeven om een of andere reden
    [StringLength(int.MaxValue, ErrorMessage = "Te kort", MinimumLength = 8)]
    public string? NieuwPaswoordConfirmatie {  get; set; }
}
