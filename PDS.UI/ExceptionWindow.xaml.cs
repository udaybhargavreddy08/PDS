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
    public partial class ExceptionWindow : Window
    {

      

        public ExceptionWindow(Exception ex)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ExceptionWindow_Loaded);

            if (ex.InnerException != null)
            {
                txtErrorDetails.Text = ex.InnerException.ToString();
            }
            txtErrorMsg.Text = ex.Message;
            txtStackTrace.Text = ex.StackTrace;
        }

        void ExceptionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }



    }
}
