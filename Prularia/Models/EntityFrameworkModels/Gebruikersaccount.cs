using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Gebruikersaccount
{
    public int GebruikersAccountId { get; set; }

    public string Emailadres { get; set; } = null!;

    public string Paswoord { get; set; } = null!;

    public bool Disabled { get; set; }

    public virtual ICollection<Chatgesprekken> Chatgesprekkens { get; set; } = new List<Chatgesprekken>();

    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Contactpersonen> Contactpersonens { get; set; } = new List<Contactpersonen>();

    public virtual ICollection<Natuurlijkepersonen> Natuurlijkepersonens { get; set; } = new List<Natuurlijkepersonen>();

    public virtual ICollection<Wishlistitem> Wishlistitems { get; set; } = new List<Wishlistitem>();
}
