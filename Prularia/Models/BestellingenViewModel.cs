using PagedList;

namespace Prularia.Models
{
    public class BestellingenViewModel
    {
        //bestelling Items
        public IPagedList<Bestelling>? BestellingItems { get; set; } = null;
    }
}
