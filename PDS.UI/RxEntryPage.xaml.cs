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
using PDS.BusinessLayer;

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for RxEntryPage.xaml
    /// </summary>
    public partial class RxEntryPage : Page
    {

        public Patient SelectedPatient { get; set; }

        public Product SelectedProduct { get; set; }

        public Prescriber SelectedPrescriber { get; set; }

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

            Prescription prescription = new Prescription();
            prescription.Patient = SelectedPatient;
            prescription.Product = SelectedProduct;
            prescription.Prescriber = SelectedPrescriber;
            prescription.SIG = txtSig.Text;
            prescription.WrittenDate = txtWrittenDate.SelectedDate.Value;
            prescription.ExpirationDate = prescription.WrittenDate.Add(new TimeSpan(365,0,0,0));

            Int32 refills;
            Int32.TryParse(txtRefills.Text, out refills);

            prescription.RefillsAllowed = refills;
                            //Create the Fills 
            prescription = new PrescriptionManager().Create(prescription);

            Fill fill = new Fill();
            fill.Prescription = prescription;
            fill.RefillsAllowed = refills;
            
            Int32 writtenQty;
            Int32.TryParse(txtWrittenQty.Text, out writtenQty);

            fill.WrittenQty = writtenQty;
            fill.DispensedQty = writtenQty;

            fill.QueueState = QueueStates.RxEntry;
            fill.DispensedDate = DateTime.Today;
                       
            var createdFill = new FillManager().Create(fill);

            //Submit the Fill
            new FillManager().Submit(createdFill);

      
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
                SelectedPatient = dlg.SelectedPatient;
                txtfirstName.Text = SelectedPatient.FirstName;
                txtlastName.Text = SelectedPatient.LastName;
                txtPhoneNumber.Text = SelectedPatient.PhoneNumber;
                txtAddres.Text = SelectedPatient.Address.ToString();
                txtDOB.Text = SelectedPatient.DOB != null ?SelectedPatient.DOB.ToShortDateString() : string.Empty;
               // txtGender.Text = SelectedPatient.Gender;
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
                SelectedProduct = dlg.SelectedProduct;

                txtProductName.Text = SelectedProduct.Name;
                txtNDC.Text = SelectedProduct.NDC;
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
                SelectedPrescriber = dlg.SelectedPrescriber;

                txtPscbfirstName.Text = SelectedPrescriber.FirstName;
                txtPscblastName.Text = SelectedPrescriber.LastName;
                txtDEA.Text = SelectedPrescriber.DEA;
                txtNPI.Text = SelectedPrescriber.NPI;
            }
        }
    }
}
