using Consultant_ATS.Models;
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
    /// Interaction logic for AddSubmissionWindowWindow.xaml
    /// </summary>
    public partial class AddSubmissionWindow : Window
    {
        private User _loggedInUser;
        private DatabaseService _databaseService;

        public AddSubmissionWindow(User user)
        {
            InitializeComponent();
            DataContext = new AddSubmissionWindowViewModel();
            _loggedInUser = user;
            _databaseService = new DatabaseService();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            var submission = new Submission
            {
                UserId = _loggedInUser.Id.ToString(),
                ClientName = ClientNameTextBox.Text,
                VendorName = VendorNameTextBox.Text,
                VendorCompany = VendorCompanyTextBox.Text,
                VendorEmail = VendorEmailTextBox.Text,
                VendorPhone = VendorPhoneTextBox.Text,
                PayRate = PayRateTextBox.Text,
                Notes = NotesTextBox.Text,
                Date = DateTime.Parse(DateTextBox.Text),
                Status = "Submitted"
            };

            _databaseService.CreateSubmission(submission);

            MessageBox.Show("Submission added successfully.");
            this.Close();
        }
    }
}
