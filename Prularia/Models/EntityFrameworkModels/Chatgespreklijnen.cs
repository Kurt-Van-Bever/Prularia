using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Chatgespreklijnen
{
    public int ChatgesprekLijnId { get; set; }

    public int ChatgesprekId { get; set; }

    public string Bericht { get; set; } = null!;

    public DateTime Tijdstip { get; set; }

    public int? GebruikersAccountId { get; set; }

    public int? PersoneelslidAccountId { get; set; }

    public virtual Chatgesprekken Chatgesprek { get; set; } = null!;

    public virtual Gebruikersaccount? GebruikersAccount { get; set; }

    public virtual Personeelslidaccount? PersoneelslidAccount { get; set; }
}
