using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Wishlistitem
{
    public int WishListItemId { get; set; }

    public int ArtikelId { get; set; }

    public int GebruikersAccountId { get; set; }

    public DateTime AanvraagDatum { get; set; }

    public int Aantal { get; set; }

    public DateTime? EmailGestuurdDatum { get; set; }

    public virtual Artikelen Artikel { get; set; } = null!;

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;
}
