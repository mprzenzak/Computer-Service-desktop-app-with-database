using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Computer_Service.Models
{
    public class Computer : INotifyPropertyChanged
    {
        [Key]
        [Display(Name = "ID komputera")]
        public int computer_id { get; set; }

        [Required]
        public string customer_id { get; set; }

        [ForeignKey("customer_id")]
        [Display(Name = "ID klienta")]
        public Customer Customer { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "System")]
        public string system_name { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Procesor")]
        public string processor { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Płyta główna")]
        public string motherboard { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "RAM")]
        public string ram { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Karta graficzna")]
        public string graphics_card { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}