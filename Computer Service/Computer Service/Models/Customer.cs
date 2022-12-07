using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        [Required]
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