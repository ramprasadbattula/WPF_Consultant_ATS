using Consultant_ATS.Services;
using Consultant_ATS.ViewModels;
using System.Windows;

namespace Consultant_ATS
{

    public partial class UpdateSubmissionStatusWindow : Window
    {
        private DatabaseService _databaseService;

        public UpdateSubmissionStatusWindow()
        {
            InitializeComponent();
            DataContext = new UpdateSubmissionStatusWindowViewModel();
            _databaseService = new DatabaseService();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var vendorEmail = VendorEmailTextBox.Text;
            var status = StatusTextBox.Text;

            var submission = _databaseService.GetSubmissionByVendorEmail(vendorEmail);

            if (submission != null)
            {
                submission.Status = status;
                _databaseService.UpdateSubmission(submission);
                MessageBox.Show("Submission status updated successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Submission not found for the specified vendor email.");
            }
        }
    }
}
