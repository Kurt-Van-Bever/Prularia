using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Personeelslidaccount
{
    public int PersoneelslidAccountId { get; set; }

    public string Emailadres { get; set; } = null!;

    public string Paswoord { get; set; } = null!;

    public bool Disabled { get; set; }


    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnen { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Personeelsleden> Personeelsleden { get; set; } = new List<Personeelsleden>();

}
