using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Prularia.Models
{
    public class BestellingenViewModel
    {
        //bestelling Items
        public IPagedList<Bestelling>? BestellingItems { get; set; } /*= new List<Bestelling>();*/
        //public List<Bestelling> BestellingItems { get; set; } = new List<Bestelling>();
        public SelectListItem[] pageSizeKeuzes = new SelectListItem[] {
                        new SelectListItem() { Text = "10", Value = "10" },
                        new SelectListItem() { Text = "20", Value = "20" },
                        new SelectListItem() { Text = "30", Value = "30" },
                        new SelectListItem() { Text = "40", Value = "40" },
                        new SelectListItem() { Text = "50", Value = "50" },
                        new SelectListItem() { Text = "100", Value = "100" }
            };
    }
}
