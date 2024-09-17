namespace Prularia.Models;

public partial class Veelgesteldevraagartikel
{
    public int VeelgesteldeVraagArtikelId { get; set; }

    public int ArtikelId { get; set; }

    public string Vraag { get; set; } = null!;

    public string Antwoord { get; set; } = null!;

    public virtual Artikel Artikel { get; set; } = null!;
}
