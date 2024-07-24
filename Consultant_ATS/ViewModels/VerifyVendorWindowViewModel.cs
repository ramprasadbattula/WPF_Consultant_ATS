using System;
using Consultant_ATS.Commands;
using System.Windows.Input;
using Consultant_ATS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
