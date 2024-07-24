using Consultant_ATS.ViewModels;
using System.Windows;

namespace Consultant_ATS
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
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