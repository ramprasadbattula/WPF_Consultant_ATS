using Consultant_ATS.Services;
using Consultant_ATS.ViewModels;
using System.Windows;

namespace Consultant_ATS
{

    public partial class MainWindow : Window
    {
        private DatabaseService _databaseService;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            _databaseService = new DatabaseService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            var signupWindow = new SignupWindow();
            signupWindow.Show();
            this.Close();
        }

    }


}