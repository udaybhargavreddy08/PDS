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
    public partial class ProductSearchWindow : Window
    {

        public Product SelectedProduct { get; set; }

        public SearchDialogResult SearchDialogResult { get; set; }

        public ProductSearchWindow(string drugName, string ndc)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PatientSearchWindow_Loaded);

            dgSrchResults.MouseDoubleClick += new MouseButtonEventHandler(dgSrchResults_MouseDoubleClick);

            txtDrugName.Text = drugName;
            txtNDC.Text = ndc;
        }

        void dgSrchResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessSelect();
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
                SelectedProduct = dgSrchResults.SelectedItem as Product;
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
            var products = new ProductManager().SearchForProducts(txtDrugName.Text, txtNDC.Text);

            dgSrchResults.ItemsSource = products;
        }
    }
}
