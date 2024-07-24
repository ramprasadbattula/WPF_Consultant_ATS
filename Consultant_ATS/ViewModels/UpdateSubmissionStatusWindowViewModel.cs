using System;
using Consultant_ATS.Commands;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant_ATS.ViewModels
{
    public class UpdateSubmissionStatusWindowViewModel : BaseViewModel
    {
        private string _vendorEmail;
        private string _status;

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
            UpdateStatusCommand = new RelayCommand(UpdateStatus);
        }

        private void UpdateStatus(object obj)
        {
            // Implement status update logic
        }
    }
}
