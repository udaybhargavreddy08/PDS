using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Patient : INotifyPropertyChanged
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

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (value != _MiddleName)
                {
                    _MiddleName = value;
                    NotifyPropertyChanged("MiddleName");
                }
            }
        }

        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set
            {
                if (value != _DOB)
                {
                    _DOB = value;
                    NotifyPropertyChanged("DOB");
                }
            }
        }

        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                if (value != _PhoneNumber)
                {
                    _PhoneNumber = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (value != _Email)
                {
                    _Email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        private bool _IsBillingMethodCash;
        public bool IsBillingMethodCash
        {
            get { return _IsBillingMethodCash; }
            set
            {
                if (value != _IsBillingMethodCash)
                {
                    _IsBillingMethodCash = value;
                    NotifyPropertyChanged("IsBillingMethodCash");
                }
            }
        }


        public Address Address { get; set; }


        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (value != _Gender)
                {
                    _Gender = value;
                    NotifyPropertyChanged("Gender");
                }
            }
        }
        
        


        private void NotifyPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
