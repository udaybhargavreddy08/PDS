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

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Uri iconUri = new Uri("pack://application:,,,/Images/pill.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            LoginPage loginPage = new LoginPage();
            mainFrame.Navigate(loginPage);


            
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientPage patientPage = new PatientPage();
            mainFrame.Navigate(patientPage);
        }

        private void btnRxEntry_Click(object sender, RoutedEventArgs e)
        {
            RxEntryPage rxEntryPage = new RxEntryPage();
            mainFrame.Navigate(rxEntryPage);
        }

        private void btnDUE_Click(object sender, RoutedEventArgs e)
        {
            DUEPage duePage = new DUEPage();
            mainFrame.Navigate(duePage);
        }

        private void btnRphVerification_Click(object sender, RoutedEventArgs e)
        {
            RPHVerificationPage verificationPage = new RPHVerificationPage();
            mainFrame.Navigate(verificationPage);
        }

        private void btnMar_Click(object sender, RoutedEventArgs e)
        {
            MARPage marPage = new MARPage();
            mainFrame.Navigate(marPage);
        }

     
    }
}
