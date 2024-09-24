namespace Prularia.Models;

public class SecuritygroepDetailsViewModel
{
    public int Id { get; set; }
    public string? Naam { get; set; }
    public List<PersoneelslidAccountViewDetails> Personeelsleden { get; set; } = new List<PersoneelslidAccountViewDetails>();
}
