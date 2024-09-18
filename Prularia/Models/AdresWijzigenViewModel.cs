namespace Prularia.Models
{
    public class AdresWijzigenViewModel
    {
        public int KlantId { get; set; }

        public virtual Adres FacturatieAdres { get; set; } = null!;

        public virtual Adres LeveringsAdres { get; set; } = null!;
    }
}
