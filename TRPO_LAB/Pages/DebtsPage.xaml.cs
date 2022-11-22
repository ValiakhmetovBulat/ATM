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
    /// Логика взаимодействия для DebtsPage.xaml
    /// </summary>
    public partial class DebtsPage : Page
    {
        private static UserAccount _ua;
        public DebtsPage(UserAccount ua)
        {
            InitializeComponent();
            _ua = ua;

            if (ua.phoneSum == 0)
            {
                dpPhone.Visibility = Visibility.Hidden;
            }
            if (ua.factureSum == 0)
            {
                dpFacture.Visibility = Visibility.Hidden;
            }
            if (ua.gasSum == 0)
            {
                dpGas.Visibility = Visibility.Hidden;
            }
            tbPhoneSum.Text += ua.phoneSum.ToString();
            tbFactureSum.Text += ua.factureSum.ToString();
            tbGasSum.Text += ua.gasSum.ToString();

            if (ua.gasSum == 0 && ua.factureSum == 0 && ua.phoneSum == 0)
            {
                btnNext.Visibility = Visibility.Hidden;
                MainWindow.error.Text = "Задолженностей не обнаружено";
            }
                
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;

            if (payFacture.IsChecked == true)
            {
                AtmManager.choosenServices[0] = true;
                sum += _ua.factureSum;
            }
            if (payPhone.IsChecked == true)
            {
                AtmManager.choosenServices[1] = true;
                sum += _ua.phoneSum;
            }
            if (payGas.IsChecked == true)
            {
                AtmManager.choosenServices[2] = true;
                sum += _ua.gasSum;
            }

            if (sum == 0)
            {
                MainWindow.error.Text = "Услуги не выбраны";
            }
            else
            {
                MainWindow.error.Text = "";
                PaymentPage pp = new PaymentPage(sum, _ua);
                Manager.MainFrame.Navigate(pp);
                Manager.CurrentPage = pp;
                MainWindow.error.Text = "";
            }
        }
    }
}
