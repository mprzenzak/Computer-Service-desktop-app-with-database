using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Service.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public int clientID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int phone { get; set; }
        public string email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}