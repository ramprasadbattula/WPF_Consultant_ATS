using Consultant_ATS.Models;
using Consultant_ATS.Services;
using System.Linq;
using System.Windows;

namespace Consultant_ATS
{
    public partial class UpdateSubmissionStatusWindow : Window
    {
        private DatabaseService _databaseService;

        public UpdateSubmissionStatusWindow()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var vendorEmail = VendorEmailTextBox.Text;
            var status = StatusTextBox.Text;

            // Fetch submissions by vendor email
            var submissions = _databaseService.GetSubmissionsByVendorEmail(vendorEmail);

            if (submissions.Any())
            {
                // Update each submission's status
                foreach (var submission in submissions)
                {
                    submission.Status = status;
                    _databaseService.UpdateSubmission(submission);
                }

                MessageBox.Show("Submission statuses updated successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No submissions found for the specified vendor email.");
            }
        }
    }
}
