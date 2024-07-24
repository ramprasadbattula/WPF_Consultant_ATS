using Consultant_ATS.Services;
using Consultant_ATS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Consultant_ATS
{
    /// <summary>
    /// Interaction logic for VerifyVendorWindow.xaml
    /// </summary>
   
   public partial class VerifyVendorWindow : Window
    {
        private DatabaseService _databaseService;

        public VerifyVendorWindow()
        {
            InitializeComponent();
            DataContext = new VerifyVendorWindowViewModel();
            _databaseService = new DatabaseService();
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            var domain = VendorDomainTextBox.Text;
            var submission = _databaseService.GetSubmissionByVendorDomain(domain);

            if (submission != null)
            {
                VerificationResultsListView.ItemsSource = new[] { submission };
                VerificationResultsListView.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No submissions found for the specified vendor domain.");
            }
        }
    }
}
