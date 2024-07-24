using System;
using Consultant_ATS.Commands;
using System.Windows.Input;
using Consultant_ATS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant_ATS.ViewModels
{
    public class DashboardWindowViewModel : BaseViewModel
    {
        private User _loggedInUser;
        public ICommand AddSubmissionCommand { get; }
        public ICommand SeeAllSubmissionsCommand { get; }
        public ICommand VerifyVendorCommand { get; }
        public ICommand UpdateSubmissionStatusCommand { get; }

        public DashboardWindowViewModel(User user)
        {
            AddSubmissionCommand = new RelayCommand(AddSubmission);
            SeeAllSubmissionsCommand = new RelayCommand(SeeAllSubmissions);
            VerifyVendorCommand = new RelayCommand(VerifyVendor);
            UpdateSubmissionStatusCommand = new RelayCommand(UpdateSubmissionStatus);
        }

        private void AddSubmission(object obj)
        {
            // Navigate to AddSubmissionWindow
            var addSubmissionWindow = new AddSubmissionWindow(_loggedInUser);
            addSubmissionWindow.Show();
        }

        private void SeeAllSubmissions(object obj)
        {
            // Navigate to see all submissions
           
        }

        private void VerifyVendor(object obj)
        {
            // Navigate to VerifyVendorWindow
            var verifyVendorWindow = new VerifyVendorWindow();
            verifyVendorWindow.Show();
        }

        private void UpdateSubmissionStatus(object obj)
        {
            // Navigate to UpdateSubmissionStatusWindow
            var updateSubmissionStatusWindow = new UpdateSubmissionStatusWindow();
            updateSubmissionStatusWindow.Show();
        }
    }
}
