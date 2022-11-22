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
using TRPO_LAB.Pages;

namespace TRPO_LAB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TextBlock error;
        public MainWindow()
        {
            InitializeComponent();

            Manager.MainFrame = MainFrame;
            Manager.CurrentPage = new WelcomePage();
            Manager.MainFrame.Navigate(Manager.CurrentPage);
            error = tbError;

            Classes.DataContext.addUser("123456", 250, 200, 500);
            Classes.DataContext.addUser("654321", 0, 0, 200);
            Classes.DataContext.addUser("123321", 0, 0, 0);
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (AtmManager.context.Length <= 11)
            {
                if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.WelcomePage")
                {
                    AtmManager.context += (sender as Button).Content;
                    WelcomePage.account.Text = AtmManager.context;
                }
                else if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.PhonePage")
                {
                    AtmManager.context += (sender as Button).Content;
                    PhonePage.phone.Text = AtmManager.context;
                }
            }            
        }

        private void btnDo_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.PaymentPage" && (sender as Button).Content.ToString() == "Return")
            {
                if (Convert.ToInt32(PaymentPage.enteredSum.Text) != 0)
                {
                    if (MessageBox.Show($"Вы точно хотите вернуть {PaymentPage.enteredSum.Text} рублей ?",
                    "Возврат денег",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AtmManager.context = "0";
                        Manager.MainFrame.Refresh();
                    }
                }
            }           
            else if ((sender as Button).Content.ToString() == "Del")
            {
                if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.WelcomePage")
                {
                    WelcomePage.account.Text = "";
                    AtmManager.context = "";
                }               
                else if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.PhonePage")
                {
                    PhonePage.phone.Text = "";
                    AtmManager.context = "";
                }
            }
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {            
            if (Manager.CurrentPage.GetType().ToString() == "TRPO_LAB.Pages.PaymentPage")
            {
                PaymentPage.enteredSum.Text = AtmManager.context;
            }            
            
        }

        private void btnSpecial_Click(object sender, RoutedEventArgs e)
        {
            int result = Convert.ToInt32(AtmManager.context) + Convert.ToInt32((sender as Button).Content);
            AtmManager.context = result.ToString();
            MainFrame.Refresh();
        }
    }
}
