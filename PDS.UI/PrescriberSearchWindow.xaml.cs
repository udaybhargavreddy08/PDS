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

namespace PDS.UI
{

   
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class PrescriberSearchWindow : Window
    {

        public Prescriber SelectedPrescriber { get; set; }

        public SearchDialogResult SearchDialogResult { get; set; }

        public PrescriberSearchWindow(string firstName, string lastName)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PrescriberSearchWindow_Loaded);

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
        }



        void PrescriberSearchWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dgSrchResults.SelectedItem != null)
            {
                SelectedPrescriber = dgSrchResults.SelectedItem as Prescriber;
                SearchDialogResult = SearchDialogResult.Select;
            }

            Close();
        }

        private void btnProductSearch_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            var prescribers = new List<Prescriber>() {
                                               new Prescriber{ FirstName="George", LastName = "Peter", DEA="AB123123123", NPI="98988989"},
                                               new Prescriber{ FirstName="George", LastName= "Alexander", DEA="BC9009099", NPI="9879889"}
                                                };

            dgSrchResults.ItemsSource = prescribers;
        }
    }
}
