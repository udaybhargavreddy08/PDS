using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Prescriber : INotifyPropertyChanged
    {
        private void NotifyPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value != _LastName)
                {
                    _LastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        private string _DEA;
        public string DEA
        {
            get { return _DEA; }
            set
            {
                if (value != _DEA)
                {
                    _DEA = value;
                    NotifyPropertyChanged("DEA");
                }
            }
        }

        private string _NPI;
        public string NPI
        {
            get { return _NPI; }
            set
            {
                if (value != _NPI)
                {
                    _NPI = value;
                    NotifyPropertyChanged("NPI");
                }
            }
        }
        
        
        
    }
}
