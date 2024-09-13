using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Chatgesprekken
{
    public int ChatgesprekId { get; set; }

    public int GebruikersAccountId { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnen { get; set; } = new List<Chatgespreklijnen>();
=======
    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; } = new List<Chatgespreklijnen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;
}
