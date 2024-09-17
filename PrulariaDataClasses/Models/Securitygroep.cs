namespace Prularia.Models;

public partial class Securitygroep
{
    public int SecurityGroepId { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Personeelslid> Personeelsleden { get; set; } = new List<Personeelslid>();
}
