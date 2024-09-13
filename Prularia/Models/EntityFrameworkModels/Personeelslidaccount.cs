using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Personeelslidaccount
{
    public int PersoneelslidAccountId { get; set; }

    public string Emailadres { get; set; } = null!;

    public string Paswoord { get; set; } = null!;

    public bool Disabled { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnen { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Personeelsleden> Personeelsleden { get; set; } = new List<Personeelsleden>();
=======
    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Personeelsleden> Personeelsledens { get; set; } = new List<Personeelsleden>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
