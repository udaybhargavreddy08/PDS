using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PDS.DomainModel;

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for RxInformationControl.xaml
    /// </summary>
    public partial class RxInformationControl : UserControl
    {
        public RxInformationControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RxInformationControl_Loaded);
        }

        void RxInformationControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedFill != null)
            {
                txtRxNumber.Text = SelectedFill.Prescription.Id.ToString();
                txtWrittenDate.Text = SelectedFill.Prescription.WrittenDate.ToShortDateString();

                var patient = SelectedFill.Prescription.Patient;

                txtName.Text = string.Format("{0} {1}", patient.FirstName.Trim(), patient.LastName.Trim());
                txtGender.Text = patient.Gender;
                txtAddress.Text = patient.Address.ToString();
                txtDOB.Text = patient.DOB.ToShortDateString();
                txtDrug.Text = SelectedFill.Prescription.Product.Name;
                txtQty.Text = SelectedFill.WrittenQty.ToString();
                txtRefills.Text = SelectedFill.RefillsAllowed.ToString();
            }

        }

        public Fill SelectedFill { get; set; }
    }
}
