using X.PagedList;

namespace Prularia.Models
{
    public class BestellingenViewModel
    {
        //bestelling Items
        public IPagedList<Bestelling>? BestellingItems { get; set; } /*= new List<Bestelling>();*/
        //public List<Bestelling> BestellingItems { get; set; } = new List<Bestelling>();
    }
}
