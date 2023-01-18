using System.ComponentModel.DataAnnotations;

namespace Computer_Service.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "ID serwisu")]
        public string service_id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Lokalizacja")]
        public string service_location { get; set; }
    }
}
