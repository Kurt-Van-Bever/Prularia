using System.ComponentModel.DataAnnotations;

namespace Prularia.Models;

public class PaswoordViewModel
{
    [Required]
    [Display(Name = "Paswoord")]
    public string OudPaswoord {  get; set; }
    [Required]
    [Display(Name = "Nieuw paswoord")]
    public string NieuwPaswoord {  get; set; }
    [Required]
    [Display(Name = "Confirmeer nieuw paswoord")]
    public string NieuwPaswoordConfirmatie {  get; set; }
}
