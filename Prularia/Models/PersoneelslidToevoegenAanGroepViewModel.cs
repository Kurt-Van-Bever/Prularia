namespace Prularia.Models;

public class PersoneelslidToevoegenAanGroepViewModel
{
    public string SecuritygroepNaam { get; set; }
    public int SecuritygroepId { get; set; }
    public List<PersoneelslidAccountViewModel> Personeelsleden { get; set; } = new List<PersoneelslidAccountViewModel>();
}
