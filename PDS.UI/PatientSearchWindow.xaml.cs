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
using System.Windows.Shapes;
using PDS.DomainModel;
using PDS.BusinessLayer;

namespace PDS.UI
{

    public enum SearchDialogResult
    {
        Cancel,
        Select
    }

    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class PatientSearchWindow : Window
    {

        public Patient SelectedPatient { get; set; }

        public SearchDialogResult SearchDialogResult { get; set; }

        public PatientSearchWindow(string firstName, string lastName, string phoneNumber)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PatientSearchWindow_Loaded);
            txtfirstName.Text = firstName;
            txtlastName.Text = lastName;
            txtPhone.Text = phoneNumber;

        }

        

        void PatientSearchWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            ProcessSelect();
        }

        private void ProcessSelect()
        {
            if (dgSrchResults.SelectedItem != null)
            {
                SelectedPatient = dgSrchResults.SelectedItem as Patient;
                SearchDialogResult = SearchDialogResult.Select;

                Close();
            }
        }

        private void btnPatientSearch_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {

            var searchResults = new SearchManager().SearchPatients(txtfirstName.Text, txtlastName.Text, txtPhone.Text);
            
            //var patients = new List<Patient>() {
            //                                   new Patient{ FirstName= "Uday", LastName="Reddy", MiddleName="Bhargav", DOB = DateTime.Now, PhoneNumber = "6127479973" },
            //                                   new Patient{ FirstName= "Teja", LastName="Bhimavarapu", MiddleName="Krishna", DOB = DateTime.Now, PhoneNumber = "6127479973", Address= new Address{ Address1="255 W. 96th Street", Address2="Apt# 3D", City="Bloomington", State="MN", ZipCode="55420" }}

            //                                    };

            dgSrchResults.ItemsSource = searchResults;
        }

        private void dgSrchResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessSelect();
        }
    }
}
