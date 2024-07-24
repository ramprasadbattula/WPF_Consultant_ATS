using Consultant_ATS.Services;
using Consultant_ATS.ViewModels;
using System;
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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DatabaseService _databaseService;

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel();
            _databaseService = new DatabaseService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;
            var user = _databaseService.GetUser(email, password);

            if (user != null)
            {
                DashboardWindow dashboardWindow = new DashboardWindow(user);
                dashboardWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }
    }
}
