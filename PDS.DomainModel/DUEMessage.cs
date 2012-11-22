using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class DUEConflict : INotifyPropertyChanged
    {
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


        private bool _IsApproved;
        public bool IsApproved
        {
            get { return _IsApproved; }
            set
            {
                if (value != _IsApproved)
                {
                    _IsApproved = value;
                    NotifyPropertyChanged("IsApproved");
                }
            }
        }


        private string _Serverity;
        public string Serverity
        {
            get { return _Serverity; }
            set
            {
                if (value != _Serverity)
                {
                    _Serverity = value;
                    NotifyPropertyChanged("Serverity");
                }
            }
        }


        public string Description { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
