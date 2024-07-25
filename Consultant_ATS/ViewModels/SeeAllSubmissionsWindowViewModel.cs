using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using Consultant_ATS.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class SeeAllSubmissionsWindowViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private readonly User _loggedInUser;

        public ObservableCollection<Submission> Submissions { get; set; }

        public ICommand DeleteSubmissionCommand { get; set; }
        public ICommand ReturnToDashboardCommand { get; set; }

        public SeeAllSubmissionsWindowViewModel(User user)
        {
            _loggedInUser = user;
            _databaseService = new DatabaseService();

            Submissions = new ObservableCollection<Submission>(_databaseService.GetSubmissions(_loggedInUser.Id.ToString()));

            DeleteSubmissionCommand = new RelayCommand<Submission>(DeleteSubmission);
            ReturnToDashboardCommand = new RelayCommand(ReturnToDashboard);
        }

        private void DeleteSubmission(Submission submission)
        {
            if (submission != null)
            {
                _databaseService.DeleteSubmission(submission.Id.ToString());
                Submissions.Remove(submission);
            }
        }

        private void ReturnToDashboard(object parameter)
        {
            var dashboardWindow = new DashboardWindow(_loggedInUser);
            dashboardWindow.Show();
            Application.Current.Windows.OfType<SeeAllSubmissionsWindow>().FirstOrDefault()?.Close();
        }

    }
}
