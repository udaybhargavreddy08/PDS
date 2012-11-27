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
using PDS.BusinessLayer;
using PDS.DomainModel;

namespace PDS.UI
{
    /// <summary>
    /// Interaction logic for RPHVerificationPage.xaml
    /// </summary>
    public partial class RPHVerificationPage : Page
    {
        public RPHVerificationPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RPHVerificationPage_Loaded);
        }

        void RPHVerificationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = string.Format("{0} {1}", SelectedFill.Prescription.Patient.FirstName.Trim(), SelectedFill.Prescription.Patient.LastName.Trim());
            txtAddress.Text = SelectedFill.Prescription.Patient.Address.ToString();
            txtDOB.Text = SelectedFill.Prescription.Patient.DOB.ToShortDateString();
            txtGender.Text = SelectedFill.Prescription.Patient.Gender;

            txtDrug.Text = SelectedFill.Prescription.Product.Name;
            txtNDC.Text = SelectedFill.Prescription.Product.NDC;

            txtPrescriberName.Text = string.Format("{0} {1}", SelectedFill.Prescription.Prescriber.FirstName.Trim(), SelectedFill.Prescription.Prescriber.LastName.Trim());
            txtNPI.Text = SelectedFill.Prescription.Prescriber.NPI;
            txtDEA.Text = SelectedFill.Prescription.Prescriber.DEA;

            txtRxID.Text = SelectedFill.Prescription.Id.ToString();
            txtWrittenDate.Text = SelectedFill.Prescription.WrittenDate.ToShortDateString();
            txtQty.Text = SelectedFill.WrittenQty.ToString();
            txtSig.Text = SelectedFill.Prescription.SIG;
        }

        public Fill SelectedFill { get; set; }

        public RPHVerificationPage(Fill selecetedFill) :  this()
        {
           
            SelectedFill = selecetedFill;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            new FillManager().PerformRPHVerificaiton(SelectedFill);

            NavigationService.GoBack();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }



        public bool IsPatientInfoVerified
        {
            get { return (bool)GetValue(IsPatientInfoVerifiedProperty); }
            set { SetValue(IsPatientInfoVerifiedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPatientInfoVerified.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPatientInfoVerifiedProperty =
            DependencyProperty.Register("IsPatientInfoVerified", typeof(bool), typeof(RPHVerificationPage), new UIPropertyMetadata(false, new PropertyChangedCallback(OnVerifyChanged)));




        public bool IsRxVerified
        {
            get { return (bool)GetValue(IsRxVerifiedProperty); }
            set { SetValue(IsRxVerifiedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRxVerified.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRxVerifiedProperty =
            DependencyProperty.Register("IsRxVerified", typeof(bool), typeof(RPHVerificationPage), new UIPropertyMetadata(false, new PropertyChangedCallback(OnVerifyChanged)));




        public bool IsPrescriberVerified
        {
            get { return (bool)GetValue(IsPrescriberVerifiedProperty); }
            set { SetValue(IsPrescriberVerifiedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPrescriberVerified.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPrescriberVerifiedProperty =
            DependencyProperty.Register("IsPrescriberVerified", typeof(bool), typeof(RPHVerificationPage), new UIPropertyMetadata(false, new PropertyChangedCallback(OnVerifyChanged)));




        public bool IsDrugVerified
        {
            get { return (bool)GetValue(IsDrugVerifiedProperty); }
            set { SetValue(IsDrugVerifiedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDrugVerified.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDrugVerifiedProperty =
            DependencyProperty.Register("IsDrugVerified", typeof(bool), typeof(RPHVerificationPage), new UIPropertyMetadata(false, new PropertyChangedCallback(OnVerifyChanged)));


        static void OnVerifyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rphPage = d as RPHVerificationPage;

            if (rphPage != null)
            {
                if (rphPage.IsPatientInfoVerified && rphPage.IsPrescriberVerified && rphPage.IsRxVerified && rphPage.IsDrugVerified)
                {
                    rphPage.btnSubmit.IsEnabled = true;
                }
                else
                {
                    rphPage.btnSubmit.IsEnabled = false;
                }
            }
        }
        


    }
}
