using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Eventwachtrijartikelen
{
    public int ArtikelId { get; set; }

    public int Aantal { get; set; }

    public int MaxAantalInMagazijnPlaats { get; set; }
}
