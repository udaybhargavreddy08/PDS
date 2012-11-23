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
    /// Interaction logic for DUEPage.xaml
    /// </summary>
    public partial class DUEPage : Page
    {
        public Fill SelectedFill { get; set; }
        public DUEPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DUEPage_Loaded);
        }

        public DUEPage(Fill selectedFill) : this()
        {
            SelectedFill = selectedFill;
        }

        void DUEPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<DUEConflict> dueConflicts = new List<DUEConflict>()
            {
                new DUEConflict{ Name = "High Dose" , Serverity = "High" , Description = "High dose, has potential for patient harm"},
                new DUEConflict{ Name = "Possible Allergy" , Serverity = "High" , Description = "Drug may cause allergy"},
                new DUEConflict{ Name = "Stomach or Intestinal Ulcer" , Serverity = "High" , Description = "High dose, has potential for patient harm"},
                new DUEConflict{ Name = "High Dose" , Serverity = "High" , Description = "High dose, has potential for patient harm"},
            };


            dgConflicts.ItemsSource = dueConflicts;

            rxInfoControl.SelectedFill = SelectedFill;

        }



        public bool CanApprove
        {
            get { return (bool)GetValue(CanApproveProperty); }
            set { SetValue(CanApproveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanApprove.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanApproveProperty =
            DependencyProperty.Register("CanApprove", typeof(bool), typeof(DUEPage), new UIPropertyMetadata(false));

        
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var selectedItem = dgConflicts.SelectedItem as DUEConflict;

            if(selectedItem != null)
            {
              selectedItem.IsApproved = !selectedItem.IsApproved;
            }


            if (dgConflicts.ItemsSource != null)
            {
                var conflicts = dgConflicts.ItemsSource as List<DUEConflict>;

                if(conflicts != null)
                {
                    var count = conflicts.Count(p => !p.IsApproved);

                    if (count == 0)
                    {
                        CanApprove = true;                       
                    }
                    else
                    {
                        CanApprove = false;
                    }                  
                }
            }

            btnApprove.IsEnabled = CanApprove;
            
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            new FillManager().ApproveDUE(SelectedFill);
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        
    }
}
