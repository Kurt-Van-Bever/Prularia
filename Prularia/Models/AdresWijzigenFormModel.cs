namespace Prularia.Models
{
    public class AdresWijzigenFormModel
    {
        public int KlantId { get; set; }
        public string Straat { get; set; } = null!;

        public string HuisNummer { get; set; } = null!;

        public string? Bus { get; set; }
        public string PostCode { get; set; }
        public string? Type { get; set; }
    }
}
