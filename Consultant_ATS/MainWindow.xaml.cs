using System.Text;
using Consultant_ATS.ViewModels;
using Consultant_ATS.Models;
using Consultant_ATS.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            var signupWindow = new SignupWindow();
            signupWindow.Show();
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

    }
    
            
        }