using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
