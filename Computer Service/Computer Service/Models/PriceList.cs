using System.ComponentModel.DataAnnotations;

namespace Computer_Service.Models
{
    public class PriceList
    {
        [Key]
        [MaxLength(20)]
        [Display(Name = "Typ usterki")]
        public string repair_type { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public float price { get; set; }
    }
}
