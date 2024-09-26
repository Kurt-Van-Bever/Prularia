﻿namespace Prularia.Models;

public class PersoneelslidAccountViewModel
{
    public int Id { get; set; }
    public string? Voornaam { get; set; }
    public string? Familienaam { get; set; }
    public string? Email { get; set; }
    public List<Securitygroep> Securitygroepen { get; set; } = new List<Securitygroep>();
    public int? SelectedSecuritygroepId { get; set; }
    public bool Disabled { get; set; }
}

