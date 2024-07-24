using System;
using Consultant_ATS.Services;
using Consultant_ATS.Models;
using Consultant_ATS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Consultant_ATS
{
   
    public partial class SignupWindow : Window
    {
        private DatabaseService _databaseService;

        public SignupWindow()
        {
            InitializeComponent();
            DataContext = new SignupWindowViewModel();
            _databaseService = new DatabaseService();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text,
                LinkedIn = LinkedInTextBox.Text,
                Password = PasswordBox.Password
            };

            _databaseService.CreateUser(user);

            MessageBox.Show("Account created successfully. Please login.");

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
