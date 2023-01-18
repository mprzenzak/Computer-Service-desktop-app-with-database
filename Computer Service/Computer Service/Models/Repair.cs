using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Computer_Service.Models
{
    public class Repair
    {
        [Key]
        [Display(Name = "ID naprawy")]
        public int repair_id { get; set; }

        [Required]
        public int computer_id { get; set; }

        [ForeignKey("computer_id")]
        [Display(Name = "Komputer")]
        public Computer Computer { get; set; }

        [Required]
        public string service_id { get; set; }

        [ForeignKey("service_id")]
        [Display(Name = "ID serwisu")]
        public Service Service { get; set; }

        [ForeignKey("repair_type")]
        [Display(Name = "Typ usterki")]
        public string repair_type { get; set; }

        [Required]
        [Display(Name = "Data zgłoszenia")]
        public DateTimeOffset filling_date { get; set; }

        [Required]
        [Display(Name = "Przewidywana data zakończenia")]
        public DateTimeOffset end_date { get; set; }
    }
}
