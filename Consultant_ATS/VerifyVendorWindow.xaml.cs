using Consultant_ATS.Models;
using Consultant_ATS.Services;
using Consultant_ATS.ViewModels;
using System.Linq;
using System.Windows;

namespace Consultant_ATS
{
    public partial class VerifyVendorWindow : Window
    {
        private VerifyVendorWindowViewModel _viewModel;

        public VerifyVendorWindow(User loggedInUser)
        {
            InitializeComponent();
            _viewModel = new VerifyVendorWindowViewModel(loggedInUser);
            DataContext = _viewModel;
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.VendorCompany = VendorCompanyTextBox.Text;
            _viewModel.VerifyCommand.Execute(null);

            var results = _viewModel.Results;
            if (results.Any())
            {
                VerificationResultsListView.ItemsSource = results;
                VerificationResultsListView.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No submissions found for the specified vendor company.");
            }
        }
    }
}
