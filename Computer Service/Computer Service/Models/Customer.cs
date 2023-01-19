using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Computer_Service.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "ID klienta")]
        public string customer_id { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Imię")]
        public string firstname { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Nazwisko")]
        public string lastname { get; set; }

        [MaxLength(9)]
        [Display(Name = "Telefon kontaktowy")]
        public int phone { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Email")]
        public string email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}