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

            dgSrchResults.MouseDoubleClick += new MouseButtonEventHandler(dgSrchResults_MouseDoubleClick);
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
        }

        void dgSrchResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessSelect();

        }



        void PrescriberSearchWindow_Loaded(object sender, RoutedEventArgs e)
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
                SelectedPrescriber = dgSrchResults.SelectedItem as Prescriber;
                SearchDialogResult = SearchDialogResult.Select;

                Close();
            }
        }

        private void btnProductSearch_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            var prescribers = new PrescriberManager().SearchForPrescriber(txtFirstName.Text, txtLastName.Text);

            dgSrchResults.ItemsSource = prescribers;
        }
    }
}
