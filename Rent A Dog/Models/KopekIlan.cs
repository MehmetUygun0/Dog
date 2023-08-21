using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rent_A_Dog.Models
{
    public class KopekIlan
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Dog Name")]
        public string DogName { get; set; }
        [DisplayName("Dog Age")]
        public string DogAge { get; set; }
        [DisplayName("Dog Type")]
        public string DogType { get; set; }
        [MaxLength(250)]
        [DisplayName("Dog Features")]
        public string DogFeatures { get; set; }
        [Required]
        [DisplayName("Starting Date")]
        public DateTime DogStartTime { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime DogEndTime { get; set; }
        public string Email { get; set; }
        public string? ImgUrl { get; set; }
    }
}
