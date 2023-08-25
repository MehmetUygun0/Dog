using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rent_A_Dog.Models
{
	public class Filtre
	{
		public IEnumerable<KopekIlan> kopekIlan { get; set; }
		[DisplayName("Starting Date")]
		public DateTime FiltreStartTime { get; set; }
		[DisplayName("End Date")]
		public DateTime FiltreEndTime { get; set; }
		public string FiltreDogType { get; set; }

        public DateTime MinDate { get; set; }
		public DateTime MaxDate { get; set; }

	}
}
