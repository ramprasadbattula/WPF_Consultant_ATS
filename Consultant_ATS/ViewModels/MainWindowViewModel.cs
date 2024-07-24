using Consultant_ATS.Commands;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
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

        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            SignupCommand = new RelayCommand(Signup);
        }

        private void Login(object obj)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow.Close();
        }

        private void Signup(object obj)
        {
            // Implement signup logic
            var signupWindow = new SignupWindow();
            signupWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
