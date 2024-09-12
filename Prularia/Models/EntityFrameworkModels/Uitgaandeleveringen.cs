using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Uitgaandeleveringen
{
    public int UitgaandeLeveringsId { get; set; }

    public int BestelId { get; set; }

    public DateTime VertrekDatum { get; set; }

    public DateTime? AankomstDatum { get; set; }

    public string Trackingcode { get; set; } = null!;

    public int KlantId { get; set; }

    public int UitgaandeLeveringsStatusId { get; set; }

    public virtual Bestellingen Bestel { get; set; } = null!;

    public virtual Klanten Klant { get; set; } = null!;

    public virtual Uitgaandeleveringsstatussen UitgaandeLeveringsStatus { get; set; } = null!;
}
