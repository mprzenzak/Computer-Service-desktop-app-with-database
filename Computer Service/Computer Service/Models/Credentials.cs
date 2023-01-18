using System.ComponentModel.DataAnnotations;

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
