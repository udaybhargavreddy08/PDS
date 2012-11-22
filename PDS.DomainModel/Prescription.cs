using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Prescription : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        public int RefillsAllowed { get; set; }

        public Patient Patient { get; set; }

        public Product Product { get; set; }

        public Prescriber Prescriber { get; set; }

        public string SIG { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime WrittenDate { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
