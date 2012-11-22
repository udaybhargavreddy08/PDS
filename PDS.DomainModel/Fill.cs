using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PDS.DomainModel
{
    public class Fill : INotifyPropertyChanged
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

        public Prescription Prescription { get; set; }

        private DateTime _PromiseTime;
        public DateTime PromiseTime
        {
            get { return _PromiseTime; }
            set
            {
                if (value != _PromiseTime)
                {
                    _PromiseTime = value;
                    NotifyPropertyChanged("PromiseTime");
                }
            }
        }


        private int _WrittenQty;
        public int WrittenQty
        {
            get { return _WrittenQty; }
            set
            {
                if (value != _WrittenQty)
                {
                    _WrittenQty = value;
                    NotifyPropertyChanged("WrittenQty");
                }
            }
        }

        private int _DispensedQty;
        public int DispensedQty
        {
            get { return _DispensedQty; }
            set
            {
                if (value != _DispensedQty)
                {
                    _DispensedQty = value;
                    NotifyPropertyChanged("DispensedQty");
                }
            }
        }


        private int _RefillsAllowed;
        public int RefillsAllowed
        {
            get { return _RefillsAllowed; }
            set
            {
                if (value != _RefillsAllowed)
                {
                    _RefillsAllowed = value;
                    NotifyPropertyChanged("RefillsAllowed");
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
