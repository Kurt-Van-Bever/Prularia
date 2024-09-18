

namespace Prularia.Models
{
    public class BestellingenViewModel
    {
        //bestelling Items
        public List<Bestelling> BestellingItems { get; set; } = new List<Bestelling>();
        public string SorteerOptie { get; set; } = "null";
        public string ZoekOptie { get; set; } = "null";
    }
}
