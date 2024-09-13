using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Securitygroepen
{
    public int SecurityGroepId { get; set; }

    public string Naam { get; set; } = null!;

<<<<<<< HEAD
    public virtual ICollection<Personeelsleden> Personeelslid { get; set; } = new List<Personeelsleden>();
=======
    public virtual ICollection<Personeelsleden> Personeelslids { get; set; } = new List<Personeelsleden>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
