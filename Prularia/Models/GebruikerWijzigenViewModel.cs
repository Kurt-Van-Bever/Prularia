namespace Prularia.Models;

public class GebruikerWijzigenViewModel
{
    public int PersoneelslidAccountId { get; set; }
    public string Emailadres { get; set; } = null!;

    //public string Paswoord { get; set; } = null!;

    public bool Disabled { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public bool? InDienst { get; set; }
}
