using System.Windows;
using Consultant_ATS.Models;
using Consultant_ATS.ViewModels;

namespace Consultant_ATS
{
    public partial class SeeAllSubmissionsWindow : Window
    {
        public SeeAllSubmissionsWindow(User user)
        {
            InitializeComponent();
            DataContext = new SeeAllSubmissionsWindowViewModel(user);
        }
    }
}
