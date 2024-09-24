namespace Prularia.Models;

public class PersoneelslidAccountViewDetails
{
    public int Id { get; set; }
    public string? Voornaam { get; set; }
    public string? Familienaam { get; set; }
    public string? Email { get; set; }
    public List<Securitygroep> Securitygroepen { get; set; } = new List<Securitygroep>();
    public bool Disabled { get; set; }
}

