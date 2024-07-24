using Consultant_ATS.Commands;
using Consultant_ATS.Models;
using MongoDB.Driver;
using System.Windows;
using System.Windows.Input;

namespace Consultant_ATS.ViewModels
{
    public class SignupWindowViewModel : BaseViewModel
    {
        private string _name;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _phone;
        private string _linkedIn;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public string LinkedIn
        {
            get => _linkedIn;
            set
            {
                _linkedIn = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignupCommand { get; }

        public SignupWindowViewModel()
        {
            SignupCommand = new RelayCommand(Signup);
        }

        private async void Signup(object obj)
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Create a new user
            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Phone = Phone,
                LinkedIn = LinkedIn
            };

            // Save the user to MongoDB
            var client = new MongoClient("your_mongodb_connection_string");
            var database = client.GetDatabase("ConsultantATS");
            var usersCollection = database.GetCollection<User>("Users");

            await usersCollection.InsertOneAsync(user);

            MessageBox.Show("Account created successfully!");

            // Redirect to the login page
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
