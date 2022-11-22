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
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public static TextBlock enteredSum;
        public PaymentPage(int sum, UserAccount ua)
        {
            InitializeComponent();
            tbSum.Text += sum.ToString();
            tbEnteredSum.Text = AtmManager.context.ToString();
            enteredSum = tbEnteredSum;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tbEnteredSum.Text) >= Convert.ToInt32(tbSum.Text))
            {
                Manager.CurrentPage = new PhonePage(
                    (Convert.ToInt32(tbEnteredSum.Text) - Convert.ToInt32(tbSum.Text)), 
                    Convert.ToInt32(tbEnteredSum.Text), 
                    Convert.ToInt32(tbSum.Text));
                Manager.MainFrame.Navigate(Manager.CurrentPage);
                AtmManager.context = "";
                MainWindow.error.Text = "";
            }
            else
            {
                MainWindow.error.Text = "Недостаточно средств для выполнения операции";
            }
        }
    }
}
