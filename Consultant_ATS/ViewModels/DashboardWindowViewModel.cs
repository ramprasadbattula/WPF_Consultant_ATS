using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class DashboardWindowViewModel : BaseViewModel
    {
        private User _loggedInUser;
        public ICommand AddSubmissionCommand { get; }
        public ICommand SeeAllSubmissionsCommand { get; }
        public ICommand VerifyVendorCommand { get; }
        public ICommand UpdateSubmissionStatusCommand { get; }
        public ICommand LogoutCommand { get; }

        public DashboardWindowViewModel(User user)
        {
            _loggedInUser = user;
            AddSubmissionCommand = new RelayCommand(AddSubmission);
            SeeAllSubmissionsCommand = new RelayCommand(SeeAllSubmissions);
            VerifyVendorCommand = new RelayCommand(VerifyVendor);
            UpdateSubmissionStatusCommand = new RelayCommand(UpdateSubmissionStatus);
            LogoutCommand = new RelayCommand(Logout);
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
            var seeAllSubmissionsWindow = new SeeAllSubmissionsWindow(_loggedInUser);
            seeAllSubmissionsWindow.Show();

        }

        private void VerifyVendor(object obj)
        {
            // Navigate to VerifyVendorWindow
            var verifyVendorWindow = new VerifyVendorWindow(_loggedInUser);
            verifyVendorWindow.Show();
        }

        private void UpdateSubmissionStatus(object obj)
        {
            // Navigate to UpdateSubmissionStatusWindow
            var updateSubmissionStatusWindow = new UpdateSubmissionStatusWindow();
            updateSubmissionStatusWindow.Show();
        }
        private void Logout(object obj)
        {
            // Close the current window and show the MainWindow
            if (obj is Window window)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                window.Close();
            }
        }
    }
}
