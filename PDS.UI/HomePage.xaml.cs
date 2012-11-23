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
            
             var pdsQueues = new List<PDSQueue>()
                            {
                               
                                new PDSQueue { StateId = (int)QueueStates.ThirdPartyRejects, Name="3RD PARTY REJECTS", Code="MAR"},
                                new PDSQueue { StateId = (int)QueueStates.DUE, Name="DUE", Code="DUE"},
                                new PDSQueue { StateId = (int)QueueStates.PrintLabel, Name="PRINT LABEL", Code="PLABEL"},
                                new PDSQueue { StateId = (int)QueueStates.RPHVerificaiton, Name="RPH VERIFICATION", Code="RPH"},
                                new PDSQueue { StateId = (int)QueueStates.WillCall, Name="WILL CALL",  Code="WILLCALL"}
                            };


            lstWorklists.ItemsSource = pdsQueues;

            lstWorklists.SelectedIndex = 0;
          

        }

        private void UpdateQueueInfo(int stateId)
        {

            var snapShot = new QueueManager().GetQueueInformation(stateId);
            var pdsQueues = lstWorklists.ItemsSource;

            foreach (var item in pdsQueues)
            {
                var queueItem = item as PDSQueue;
                queueItem.Count = snapShot.Queues.Single(p => p.StateId == queueItem.StateId).Count;
            }
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
                var selectedId = pdsQueue.StateId;

                UpdateQueueInfo(selectedId);

                ChangeButtonContent(pdsQueue);
            }
        }

        private void ChangeButtonContent(PDSQueue pdsQueue)
        {
            QueueStates selectedQueue = (QueueStates)Enum.ToObject(typeof(QueueStates), pdsQueue.StateId);

            if (selectedQueue == QueueStates.ThirdPartyRejects)
            {
                btnProcessQueue.Content = "Process Rejects";
            }
            else if (selectedQueue == QueueStates.DUE)
            {
                btnProcessQueue.Content = "Process DUE";
            }
            else if (selectedQueue == QueueStates.RPHVerificaiton)
            {
                btnProcessQueue.Content = "Verify Fill";
            }
            else if (selectedQueue == QueueStates.PrintLabel)
            {
                btnProcessQueue.Content = "Print Label";
            }
            else if (selectedQueue == QueueStates.WillCall)
            {
                btnProcessQueue.Content = "Sell";
            }
        }

        private void dgQueueItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessFill();
        }

        private void ProcessFill()
        {
            if (dgQueueItems.SelectedItem != null && lstWorklists.SelectedItem != null)
            {
                var pdsQueue = lstWorklists.SelectedItem as PDSQueue;
                var selectedFill = dgQueueItems.SelectedItem as Fill;

                var selectedId = pdsQueue.StateId;
                QueueStates selectedQueue = (QueueStates)Enum.ToObject(typeof(QueueStates), pdsQueue.StateId);

                if (selectedFill != null)
                {
                    if (selectedQueue == QueueStates.ThirdPartyRejects)
                    {
                        NavigationService.Navigate(new MARPage(selectedFill));
                    }
                    else if (selectedQueue == QueueStates.DUE)
                    {
                        NavigationService.Navigate(new DUEPage(selectedFill));
                    }
                    else if (selectedQueue == QueueStates.PrintLabel)
                    {
                        new FillManager().PrintLabel(selectedFill);
                        UpdateQueueInfo((int)QueueStates.PrintLabel);
                    }
                    else if (selectedQueue == QueueStates.RPHVerificaiton)
                    {
                        NavigationService.Navigate(new RPHVerificationPage(selectedFill));
                    }
                    else if (selectedQueue == QueueStates.WillCall)
                    {
                        new FillManager().Sell(selectedFill);
                        UpdateQueueInfo((int)QueueStates.WillCall);
                    }
                   
                }
            }
        }

        private void btnProcessQueue_Click(object sender, RoutedEventArgs e)
        {
            ProcessFill();
        }


    }
}
