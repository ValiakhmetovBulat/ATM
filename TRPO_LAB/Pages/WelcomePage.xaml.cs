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
using TRPO_LAB.Classes;

namespace TRPO_LAB.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public static TextBox account;
        public WelcomePage()
        {
            InitializeComponent();
            account = tbAccount;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool isSigned = false;

            foreach (var user in Classes.DataContext.GetContext())
            {
                if (tbAccount.Text == user.number)
                {
                    AtmManager.currUser = user;
                    DebtsPage dp = new DebtsPage(user);
                    Manager.MainFrame.Navigate(dp);
                    Manager.CurrentPage = dp;
                    isSigned = true;
                    AtmManager.context = "0";
                    MainWindow.error.Text = "";
                }
                    
            }
            if (!isSigned)
            {
                MainWindow.error.Text = "Неверный номер счета";
            }
        }
    }
}
