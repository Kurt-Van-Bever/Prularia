namespace Prularia.Models;

public partial class Inkomendelevering
{
    public int InkomendeLeveringsId { get; set; }

    public int LeveranciersId { get; set; }

    public string LeveringsbonNummer { get; set; } = null!;

    public DateTime Leveringsbondatum { get; set; }

    public DateTime LeverDatum { get; set; }

    public int OntvangerPersoneelslidId { get; set; }

    public virtual ICollection<Inkomendeleveringslijn> Inkomendeleveringslijnen { get; set; } = new List<Inkomendeleveringslijn>();

    public virtual Leverancier Leverancier { get; set; } = null!;

    public virtual Personeelslid OntvangerPersoneelslid { get; set; } = null!;
}
