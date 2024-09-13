using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Inkomendeleveringen
{
    public int InkomendeLeveringsId { get; set; }

    public int LeveranciersId { get; set; }

    public string LeveringsbonNummer { get; set; } = null!;

    public DateTime Leveringsbondatum { get; set; }

    public DateTime LeverDatum { get; set; }

    public int OntvangerPersoneelslidId { get; set; }


    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnen { get; set; } = new List<Inkomendeleveringslijnen>();

    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; } = new List<Inkomendeleveringslijnen>();

    public virtual Leverancier Leveranciers { get; set; } = null!;

    public virtual Personeelsleden OntvangerPersoneelslid { get; set; } = null!;
}
