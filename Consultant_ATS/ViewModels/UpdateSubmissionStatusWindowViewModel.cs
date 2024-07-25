using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using Consultant_ATS.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class UpdateSubmissionStatusWindowViewModel : BaseViewModel
    {
        private string _vendorEmail;
        private string _status;
        private DatabaseService _databaseService;

        public string VendorEmail
        {
            get => _vendorEmail;
            set
            {
                _vendorEmail = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateStatusCommand { get; }

        public UpdateSubmissionStatusWindowViewModel()
        {
            _databaseService = new DatabaseService();
            UpdateStatusCommand = new RelayCommand(UpdateStatus);
        }

        private void UpdateStatus(object obj)
        {
            var submissions = _databaseService.GetSubmissionsByVendorEmail(_vendorEmail);

            if (submissions.Count > 0)
            {
                foreach (var submission in submissions)
                {
                    submission.Status = _status;
                    _databaseService.UpdateSubmission(submission);
                }

                // Show confirmation message
                MessageBox.Show("Submission status updated successfully.");
            }
            else
            {
                // Show warning message
                MessageBox.Show("No submissions found for the specified vendor email.");
            }
        }
    }
}
