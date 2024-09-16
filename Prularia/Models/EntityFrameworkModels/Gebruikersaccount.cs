using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Gebruikersaccount
{
    public int GebruikersAccountId { get; set; }

    public string Emailadres { get; set; } = null!;

    public string Paswoord { get; set; } = null!;

    public bool Disabled { get; set; }


    public virtual ICollection<Chatgesprekken> Chatgesprekken { get; set; } = new List<Chatgesprekken>();

    public virtual ICollection<Chatgespreklijnen> Chatgespreklijnen { get; set; } = new List<Chatgespreklijnen>();

    public virtual ICollection<Contactpersonen> Contactpersonen { get; set; } = new List<Contactpersonen>();

    public virtual ICollection<Natuurlijkepersonen> Natuurlijkepersonen { get; set; } = new List<Natuurlijkepersonen>();

    public virtual ICollection<Wishlistitem> Wishlistitem { get; set; } = new List<Wishlistitem>();

}
