namespace Prularia.Models;

public partial class Uitgaandeleveringsstatus
{
    public int UitgaandeLeveringsStatusId { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Uitgaandelevering> Uitgaandeleveringen { get; set; } = new List<Uitgaandelevering>();
}
