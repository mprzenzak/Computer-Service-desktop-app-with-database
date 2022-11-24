using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Service.Models
{
    public class Computer : INotifyPropertyChanged
    {
        public int computerID { get; set; }
        public int clientID { get; set; }
        public string model { get; set; }
        public string system_name { get; set; }
        public string processor { get; set; }
        public string graphic_card { get; set; }
        public string motherboard { get; set; }
        public string ram { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}