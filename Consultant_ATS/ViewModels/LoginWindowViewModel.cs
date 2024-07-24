using Consultant_ATS.Commands;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant_ATS.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            SignupCommand = new RelayCommand(Signup);
        }

        private void Login(object obj)
        {
            // Implement login logic
        }

        private void Signup(object obj)
        {
            // Implement signup logic
        }
    }
}
