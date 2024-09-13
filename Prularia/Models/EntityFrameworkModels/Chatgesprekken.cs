using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Chatgesprekken
{
    public int ChatgesprekId { get; set; }

    public int GebruikersAccountId { get; set; }


    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnen { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; } = new List<Chatgespreklijnen>();


    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;
}
