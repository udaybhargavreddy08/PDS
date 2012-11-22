using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Address : INotifyPropertyChanged
    {

        public int Id { get; set; }

        private string _Address1 = string.Empty;
        public string Address1
        {
            get { return _Address1; }
            set
            {
                if (value != _Address1)
                {
                    _Address1 = value;
                    NotifyPropertyChanged("Address1");
                }
            }
        }

        private string _Address2 = string.Empty;
        public string Address2
        {
            get { return _Address2; }
            set
            {
                if (value != _Address2)
                {
                    _Address2 = value;
                    NotifyPropertyChanged("Address2");
                }
            }
        }

        private string _City = string.Empty;
        public string City
        {
            get { return _City; }
            set
            {
                if (value != _City)
                {
                    _City = value;
                    NotifyPropertyChanged("City");
                }
            }
        }


        private string _ZipCode = string.Empty;
        public string ZipCode
        {
            get { return _ZipCode; }
            set
            {
                if (value != _ZipCode)
                {
                    _ZipCode = value;
                    NotifyPropertyChanged("ZipCode");
                }
            }
        }


        private string _State = string.Empty;
        public string State
        {
            get { return _State; }
            set
            {
                if (value != _State)
                {
                    _State = value;
                    NotifyPropertyChanged("State");
                }
            }
        }
              
        


        private void NotifyPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3}, {4}",_Address1,_Address2,_City,_State,_ZipCode);
        }
    }
}
