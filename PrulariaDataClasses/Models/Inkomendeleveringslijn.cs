namespace Prularia.Models;

public partial class Inkomendeleveringslijn
{
    public int InkomendeLeveringsId { get; set; }

    public int ArtikelId { get; set; }

    public int AantalGoedgekeurd { get; set; }

    public int AantalTeruggestuurd { get; set; }

    public int MagazijnPlaatsId { get; set; }

    public virtual Artikel Artikel { get; set; } = null!;

    public virtual Inkomendelevering InkomendeLevering { get; set; } = null!;

    public virtual Magazijnplaats MagazijnPlaats { get; set; } = null!;
}
