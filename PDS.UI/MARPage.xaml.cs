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
    /// Interaction logic for MARPage.xaml
    /// </summary>
    public partial class MARPage : Page
    {

        public Fill SelectedFill { get; set; }
        public MARPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MARPage_Loaded);
        }

        void MARPage_Loaded(object sender, RoutedEventArgs e)
        {
            rxInfoControl.SelectedFill = SelectedFill;
        }

        public MARPage(Fill selectedFill) :  this()
        {
            SelectedFill = selectedFill;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnResubmit_Click(object sender, RoutedEventArgs e)
        {
            new FillManager().ReSubmit(SelectedFill);

            NavigationService.GoBack();
        }
    }
}
