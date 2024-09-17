namespace Prularia.Models;

public partial class Bestellijn
{
    public int BestellijnId { get; set; }

    public int BestelId { get; set; }

    public int ArtikelId { get; set; }

    public int AantalBesteld { get; set; }

    public int AantalGeannuleerd { get; set; }

    public virtual Artikel Artikel { get; set; } = null!;

    public virtual Bestelling Bestel { get; set; } = null!;

    public virtual ICollection<Klantenreview> Klantenreviews { get; set; } = new List<Klantenreview>();
}
