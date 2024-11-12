using Microsoft.IdentityModel.Tokens;
using PerfumeManagement.BLL.Service;
using PerfumeManagement.DAL.Entities;
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

namespace PerfumeManagement_StudentCode
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserService _userService = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailAddressTextBox.Text;
            string password = PasswordTextBox.Text;
            Psaccount? user = _userService.Authenticate(email, password);
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Both Email And Password Is Required", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (user == null)
            {
                MessageBox.Show("Invalid Email Address or Wrong Password", "Wrong Identials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (user.Role == 4 || user.Role == 1)
            {
                MessageBox.Show("You Dont Have Permission To This Function", "Wrong Permmission", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow d = new();
            d.Show();
            this.Hide();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
