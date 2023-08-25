namespace Rent_A_Dog.Models
{
	public class IlanVerDTO
	{
        public KopekIlan ReferansIlan { get; set; }
		public IEnumerable<KopekIlan>? ReferansIlanLİst { get; set; }
		public IEnumerable<Teklif>? TeklifIlanLİst { get; set; }

		public Teklif TeklifIlan { get; set; }
    }
}
