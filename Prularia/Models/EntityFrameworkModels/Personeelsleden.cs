using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Personeelsleden
{
    public int PersoneelslidId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public bool? InDienst { get; set; }

    public int PersoneelslidAccountId { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Inkomendeleveringen> Inkomendeleveringen { get; set; } = new List<Inkomendeleveringen>();

    public virtual Personeelslidaccount PersoneelslidAccount { get; set; } = null!;

    public virtual ICollection<Securitygroepen> SecurityGroepen { get; set; } = new List<Securitygroepen>();
=======
    public virtual ICollection<Inkomendeleveringen> Inkomendeleveringens { get; set; } = new List<Inkomendeleveringen>();

    public virtual Personeelslidaccount PersoneelslidAccount { get; set; } = null!;

    public virtual ICollection<Securitygroepen> SecurityGroeps { get; set; } = new List<Securitygroepen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
