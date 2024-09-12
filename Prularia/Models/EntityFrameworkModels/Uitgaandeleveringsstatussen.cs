using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Uitgaandeleveringsstatussen
{
    public int UitgaandeLeveringsStatusId { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; } = new List<Uitgaandeleveringen>();
}
