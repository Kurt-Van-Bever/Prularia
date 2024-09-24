namespace Prularia.Models;

public class SecuritygroepDetailsViewModel
{
    public int Id { get; set; }
    public string? Naam { get; set; }
    public List<PersoneelslidAccountViewModel> Personeelsleden { get; set; } = new List<PersoneelslidAccountViewModel>();
}
