namespace Prularia.Models;

public partial class Chatgesprek
{
    public int ChatgesprekId { get; set; }

    public int GebruikersAccountId { get; set; }

    public virtual ICollection<Chatgespreklijn> Chatgespreklijnen { get; set; } = new List<Chatgespreklijn>();

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;
}
