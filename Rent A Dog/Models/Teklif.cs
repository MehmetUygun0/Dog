using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rent_A_Dog.Models
{
	public class Teklif
	{
		[Key]
		public int Id { get; set; }
		public string Name{ get; set; }
		[DisplayName("Teklif Fİyat")]
		public string TeklifFİyat { get; set; }
		[DisplayName("Not (Opsiyonel)")]
		[MaxLength(250)]
		public string Not { get; set; }
		[DisplayName("Telefon Numarası")]
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public string IlanEmail { get; set; }
        public bool Enable { get; set; }
	}
}
