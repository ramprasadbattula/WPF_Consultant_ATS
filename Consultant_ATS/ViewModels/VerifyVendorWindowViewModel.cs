using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class VerifyVendorWindowViewModel : BaseViewModel
    {
        private string _vendorDomain;
        private ObservableCollection<Submission> _results;

        public string VendorDomain
        {
            get => _vendorDomain;
            set
            {
                _vendorDomain = value;
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

        public VerifyVendorWindowViewModel()
        {
            Results = new ObservableCollection<Submission>();
            VerifyCommand = new RelayCommand(Verify);
        }

        private void Verify(object obj)
        {
            // Implement verification logic
        }
    }
}
