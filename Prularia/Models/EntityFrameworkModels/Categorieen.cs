using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Categorieen
{
    public int CategorieId { get; set; }

    public string Naam { get; set; } = null!;

    public int? HoofdCategorieId { get; set; }

    public virtual Categorieen? HoofdCategorie { get; set; }

    public virtual ICollection<Categorieen> InverseHoofdCategorie { get; set; } = new List<Categorieen>();

    public virtual ICollection<Artikelen> Artikels { get; set; } = new List<Artikelen>();
}
