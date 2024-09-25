namespace Prularia.Models;

public class PersoneelslidToevoegenAanGroepViewModel
{
    public int SecuritygroepId { get; set; }
    public List<PersoneelslidAccountViewModel> Personeelsleden { get; set; } = new List<PersoneelslidAccountViewModel>();
}
