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


    public virtual ICollection<Inkomendeleveringen> Inkomendeleveringen { get; set; } = new List<Inkomendeleveringen>();

    public virtual Personeelslidaccount PersoneelslidAccount { get; set; } = null!;

    public virtual ICollection<Securitygroepen> SecurityGroepen { get; set; } = new List<Securitygroepen>();

}
