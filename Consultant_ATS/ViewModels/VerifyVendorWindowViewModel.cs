using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using Consultant_ATS.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class VerifyVendorWindowViewModel : BaseViewModel
    {
        private string _vendorCompany;
        private ObservableCollection<Submission> _results;
        private DatabaseService _databaseService;
        private User _loggedInUser;

        public string VendorCompany
        {
            get => _vendorCompany;
            set
            {
                _vendorCompany = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Submission> Results
        {
            get => _results;
            set
            {
                _results = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; }

        public VerifyVendorWindowViewModel(User loggedInUser)
        {
            _loggedInUser = loggedInUser;
            _databaseService = new DatabaseService();
            Results = new ObservableCollection<Submission>();
            VerifyCommand = new RelayCommand(Verify);
        }

        private void Verify(object obj)
        {
            var submissions = _databaseService.GetSubmissionsByVendorCompany(_loggedInUser.Id.ToString(), _vendorCompany);
            Results.Clear();
            foreach (var submission in submissions)
            {
                Results.Add(submission);
            }

            if (submissions.Count == 0)
            {
                // Notify the user that no submissions were found
                MessageBox.Show("No submissions found for the specified vendor company.");
            }
        }

    }
}
