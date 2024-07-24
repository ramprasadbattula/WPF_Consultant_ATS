﻿using Consultant_ATS.Models;
using Consultant_ATS.ViewModels;
using Consultant_ATS.Services;
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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private User _loggedInUser;
        private DatabaseService _databaseService;

        public DashboardWindow(User user)
        {
            InitializeComponent();
            _loggedInUser = user;
            DataContext = new DashboardWindowViewModel(_loggedInUser);
            
            _databaseService = new DatabaseService();
        }

        private void AddSubmissionButton_Click(object sender, RoutedEventArgs e)
        {
            AddSubmissionWindow addSubmissionWindow = new AddSubmissionWindow(_loggedInUser);
            addSubmissionWindow.Show();
        }

        private void SeeAllSubmissionsButton_Click(object sender, RoutedEventArgs e)
        {
            var submissions = _databaseService.GetSubmissions(_loggedInUser.Id.ToString());
            SubmissionsListView.ItemsSource = submissions;
            SubmissionsListView.Visibility = Visibility.Visible;
        }

        private void VerifyVendorButton_Click(object sender, RoutedEventArgs e)
        {
            VerifyVendorWindow verifyVendorWindow = new VerifyVendorWindow();
            verifyVendorWindow.Show();
        }

        private void UpdateSubmissionStatusButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSubmissionStatusWindow updateSubmissionStatusWindow = new UpdateSubmissionStatusWindow();
            updateSubmissionStatusWindow.Show();
        }
    }
}
