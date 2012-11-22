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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class PatientPage : PageFunction<PatientViewModel>

    {
        public PatientPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PatientPage_Loaded);

        }

        void PatientPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Patient patient = new Patient();

            MapPatientData(patient);
            
            new PatientManager().Save(patient);
                       
            //Save and go back
            NavigationService.GoBack();
        }

        private void MapPatientData(Patient patient)
        {
            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
            patient.MiddleName = txtMiddleName.Text;
            patient.DOB = txtDOB.SelectedDate.Value;
            patient.PhoneNumber = txtPhone.Text;
            
            if(rdbCash.IsChecked.HasValue && rdbCash.IsChecked.Value)
            {
                patient.IsBillingMethodCash = true;
            }
            else
            {
                patient.IsBillingMethodCash = false;
            }


            var patientAddress = new Address();
           
            patientAddress.Address1 = txtAddress1.Text;
            patientAddress.Address2 = txtAddress2.Text;
            patientAddress.City = txtCity.Text;
            patientAddress.State = cmbState.SelectedValue.ToString();

            patient.Address = patientAddress;

        }

       
    }
}
