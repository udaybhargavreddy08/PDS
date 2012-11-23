using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Product : INotifyPropertyChanged
    {

        private void NotifyPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public int Id { get; set; }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }


        private string _NDC;
        public string NDC
        {
            get { return _NDC; }
            set
            {
                if (value != _NDC)
                {
                    _NDC = value;
                    NotifyPropertyChanged("NDC");
                }
            }
        }


        public int DrugClass { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
