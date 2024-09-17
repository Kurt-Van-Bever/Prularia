namespace Prularia.Models;

public partial class Uitgaandelevering
{
    public int UitgaandeLeveringsId { get; set; }

    public int BestelId { get; set; }

    public DateTime VertrekDatum { get; set; }

    public DateTime? AankomstDatum { get; set; }

    public string Trackingcode { get; set; } = null!;

    public int KlantId { get; set; }

    public int UitgaandeLeveringsStatusId { get; set; }

    public virtual Bestelling Bestelling { get; set; } = null!;

    public virtual Klant Klant { get; set; } = null!;

    public virtual Uitgaandeleveringsstatus UitgaandeLeveringsStatus { get; set; } = null!;
}
