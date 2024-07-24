using Consultant_ATS.Commands;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class AddSubmissionWindowViewModel : BaseViewModel
    {
        private string _clientName;
        private string _vendorName;
        private string _vendorCompany;
        private string _vendorEmail;
        private string _vendorPhone;
        private string _payRate;
        private string _notes;
        private string _date;

        public string ClientName
        {
            get => _clientName;
            set
            {
                _clientName = value;
                OnPropertyChanged();
            }
        }

        public string VendorName
        {
            get => _vendorName;
            set
            {
                _vendorName = value;
                OnPropertyChanged();
            }
        }

        public string VendorCompany
        {
            get => _vendorCompany;
            set
            {
                _vendorCompany = value;
                OnPropertyChanged();
            }
        }

        public string VendorEmail
        {
            get => _vendorEmail;
            set
            {
                _vendorEmail = value;
                OnPropertyChanged();
            }
        }

        public string VendorPhone
        {
            get => _vendorPhone;
            set
            {
                _vendorPhone = value;
                OnPropertyChanged();
            }
        }

        public string PayRate
        {
            get => _payRate;
            set
            {
                _payRate = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public ICommand CompleteCommand { get; }

        public AddSubmissionWindowViewModel()
        {
            CompleteCommand = new RelayCommand(Complete);
        }

        private void Complete(object obj)
        {
            // Implement submission logic
        }
    }
}

