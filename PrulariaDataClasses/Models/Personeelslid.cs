namespace Prularia.Models;

public partial class Personeelslid
{
    public int PersoneelslidId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public bool? InDienst { get; set; }

    public int PersoneelslidAccountId { get; set; }

    public virtual ICollection<Inkomendelevering> Inkomendeleveringen { get; set; } = new List<Inkomendelevering>();

    public virtual Personeelslidaccount PersoneelslidAccount { get; set; } = null!;

    public virtual ICollection<Securitygroep> SecurityGroepen { get; set; } = new List<Securitygroep>();
}
