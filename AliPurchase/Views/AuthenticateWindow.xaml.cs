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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AliPurchase.Views;
using AliPurchase.Models;
using RestSharp;
using MahApps.Metro.Controls;

namespace AliPurchase
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class AuthenticateWindow : MetroWindow
    {
        public AuthenticateWindow()
        {
            InitializeComponent();
#if DEBUG
            tbx_email.Text = "supplier01@alizon.fr";
            pbx_pwd.Password = "12345678";
#endif
        }

        private void btn_signin_Click(object sender, RoutedEventArgs e)
        {
            String message = Login.Connect(tbx_email.Text, pbx_pwd.Password);
            if (message == "Success")
            {
                // Call the ShellWindow view and close without verifying the credentials : TODO
                ShellWindow mainWindow = new ShellWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Set the message for the user
                tbx_message.Text = message;
            }
        }
    }
}
