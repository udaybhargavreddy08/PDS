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
    /// Interaction logic for PrintLabel.xaml
    /// </summary>
    public partial class PrintLabel : UserControl
    {

        public Fill SelectedFill { get; set; }
        public PrintLabel(Fill fill)
        {
            InitializeComponent();
            SelectedFill = fill;

            if (SelectedFill != null && SelectedFill.Prescription != null)
            {
                txtPatientDetails.Text = string.Format("{0} {1} ", SelectedFill.Prescription.Patient.FirstName, SelectedFill.Prescription.Patient.LastName);
                txtPrescriber.Text = string.Format("{0} {1} ", SelectedFill.Prescription.Prescriber.FirstName, SelectedFill.Prescription.Prescriber.LastName);
                txtProduct.Text = string.Format("{0} \r\n {1} ", SelectedFill.Prescription.Product.Name, SelectedFill.Prescription.Product.NDC);
            }
            this.Loaded += new RoutedEventHandler(PrintLabel_Loaded);
        }

        void PrintLabel_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
