using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Securitygroepen
{
    public int SecurityGroepId { get; set; }

    public string Naam { get; set; } = null!;


    public virtual ICollection<Personeelsleden> Personeelslid { get; set; } = new List<Personeelsleden>();

    public virtual ICollection<Personeelsleden> Personeelslids { get; set; } = new List<Personeelsleden>();

}
