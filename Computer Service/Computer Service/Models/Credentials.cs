using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Computer_Service.Models
{
    public class Credentials
    {
        [Key]
        [MaxLength(20)]
        [Display(Name = "Login")]
        public string login { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        public string password { get; set; }
    }
}
