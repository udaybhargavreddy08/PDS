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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(HomePage_Loaded);

        }

        void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            //var queues = new List<PDSQueue>()
            //                {
            //                    new PDSQueue {  Name="DUE", Count = 20, Code="DUE"},
            //                    new PDSQueue { Name="3RD PARTY REJECTS", Count = 12, Code="MAR"},
            //                    new PDSQueue { Name="PRINT LABEL", Count = 2, Code="PLABEL"},
            //                    new PDSQueue { Name="RPH VERIFICATION", Count = 2, Code="RPH"},
            //                    new PDSQueue { Name="WILL CALL", Count = 2, Code="WILLCALL"}
            //                };

            //lstWorklists.ItemsSource = queues;

            //lstWorklists.SelectedIndex = 0;
            //var queueItems = new List<Fill>()
            //{
            //    new Fill{ Prescription = new Prescription{ Patient = new Patient{ FirstName = "Uday", LastName="Reddy"}, Prescriber = new Prescriber { FirstName= "Peter", LastName = "George"}, Product = new Product { Name = "Amoxicillin"}}},
            //    new Fill{ Prescription = new Prescription{ Patient = new Patient{ FirstName = "Jan", LastName="Doe"}, Prescriber = new Prescriber { FirstName= "Peter", LastName = "George"}, Product = new Product { Name = "Prozac"}}},
            //    new Fill{ Prescription = new Prescription{ Patient = new Patient{ FirstName = "Jan", LastName="Doe"}, Prescriber = new Prescriber { FirstName= "Peter", LastName = "George"}, Product = new Product { Name = "IBruphine"}}}
            //};


           
           var snapShot = new QueueManager().GetQueueInformation(1001);
           lstWorklists.ItemsSource = snapShot.Queues;
           dgQueueItems.ItemsSource = snapShot.SelectedQueueFills;

        }

      

        private void btnNewFilling_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RxEntryPage());
        }

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientPage());
        }

        private void lstWorklists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstWorklists.SelectedItem != null)
            {
                var pdsQueue = lstWorklists.SelectedItem as PDSQueue;
                string selectedCode = pdsQueue.Code;

                if (selectedCode == "MAR")
                {
                    btnProcessQueue.Content = "Process Rejects";
                }
                else if (selectedCode == "DUE")
                {
                    btnProcessQueue.Content = "Process DUE";
                }
                else if (selectedCode == "RPH")
                {
                    btnProcessQueue.Content = "Verify Fill";
                }
                else if (selectedCode == "PLABEL")
                {
                    btnProcessQueue.Content = "Print Label";
                }
                else if (selectedCode == "WILLCALL")
                {
                    btnProcessQueue.Content = "Sell";
                }
            }
        }

        private void dgQueueItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgQueueItems.SelectedItem != null && lstWorklists.SelectedItem != null)
            {
                var pdsQueue = lstWorklists.SelectedItem as PDSQueue;
                var selectedFill = dgQueueItems.SelectedItem as Fill;
                string selectedCode = pdsQueue.Code;

                if (selectedCode == "MAR")
                {
                    NavigationService.Navigate(new MARPage(), selectedFill);
                }
                else if (selectedCode == "DUE")
                {
                    NavigationService.Navigate(new DUEPage(), selectedFill);
                }
                else if (selectedCode == "RPH")
                {
                    NavigationService.Navigate(new RPHVerificationPage(), selectedFill);
                }
                else if (selectedCode == "WILLCALL")
                {
                    NavigationService.Navigate(new RPHVerificationPage(), selectedFill);
                }

            }
        }

        private void btnProcessQueue_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
