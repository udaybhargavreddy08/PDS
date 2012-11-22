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

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for RxEntryPage.xaml
    /// </summary>
    public partial class RxEntryPage : Page
    {
        public RxEntryPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RxEntryPage_Loaded);
        }

        void RxEntryPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtWrittenDate.SelectedDate = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnPatientSearch_Click(object sender, RoutedEventArgs e)
        {

            PatientSearchWindow dlg = new PatientSearchWindow(txtfirstName.Text, txtlastName.Text, txtPhoneNumber.Text);
            // Configure the dialog box
            dlg.Owner = Window.GetWindow(this);
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            // Open the dialog box modally 
            dlg.ShowDialog();

            if (dlg.SearchDialogResult == SearchDialogResult.Select && dlg.SelectedPatient != null)
            {
                var selectedPatient = dlg.SelectedPatient;
                txtfirstName.Text = selectedPatient.FirstName;
                txtlastName.Text = selectedPatient.LastName;
                txtPhoneNumber.Text = selectedPatient.PhoneNumber;
                txtAddres.Text = selectedPatient.Address.ToString();
                txtDOB.Text = selectedPatient.DOB != null ?selectedPatient.DOB.ToShortDateString() : string.Empty;
               // txtGender.Text = selectedPatient.Gender;
            }
        }

        private void btnProductSearch_Click(object sender, RoutedEventArgs e)
        {
            ProductSearchWindow dlg = new ProductSearchWindow(txtProductName.Text, txtNDC.Text);
            // Configure the dialog box
            dlg.Owner = Window.GetWindow(this);
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            // Open the dialog box modally 
            dlg.ShowDialog();

            if (dlg.SearchDialogResult == SearchDialogResult.Select && dlg.SelectedProduct != null)
            {
                var selectedProduct = dlg.SelectedProduct;

                txtProductName.Text = selectedProduct.Name;
                txtNDC.Text = selectedProduct.NDC;
            }

        }

        private void btnPscbSearch_Click(object sender, RoutedEventArgs e)
        {
            PrescriberSearchWindow dlg = new PrescriberSearchWindow(txtPscbfirstName.Text, txtPscblastName.Text);
            // Configure the dialog box
            dlg.Owner = Window.GetWindow(this);
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            // Open the dialog box modally 
            dlg.ShowDialog();

            if (dlg.SearchDialogResult == SearchDialogResult.Select && dlg.SelectedPrescriber != null)
            {
                var selectePrescriber = dlg.SelectedPrescriber;

                txtPscbfirstName.Text = selectePrescriber.FirstName;
                txtPscblastName.Text = selectePrescriber.LastName;
                txtDEA.Text = selectePrescriber.DEA;
                txtNPI.Text = selectePrescriber.NPI;
            }
        }
    }
}
