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
using TRPO_LAB.Windows;

namespace TRPO_LAB.Pages
{
    /// <summary>
    /// Логика взаимодействия для PhonePage.xaml
    /// </summary>
    public partial class PhonePage : Page
    {
        public static TextBox phone;
        private int _change;
        private int _enteredSum;
        private int _sumToPay;
        public PhonePage(int change, int enteredSum, int sumToPay)
        {            
            InitializeComponent();
            tbChange.Text = change.ToString();
            phone = tbPhone;

            _change = change;
            _enteredSum = enteredSum;
            _sumToPay = sumToPay;
        }

        private void btnSendChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbPhone.Text.Length != 11)
            {
                MainWindow.error.Text = "Некорректный номер телефона";
            }
            else
            {
                if (MessageBox.Show($"Введенный номер - {phone.Text}\nПродолжить?", "Проверьте введенный номер", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (var item in Classes.DataContext.GetContext())
                    {
                        if (item.number == AtmManager.currUser.number)
                        {
                            CheckWindow cw = new CheckWindow(_sumToPay, _enteredSum, _change, AtmManager.choosenServices);
                            cw.Show();

                            if (AtmManager.choosenServices[0])
                            {
                                AtmManager.currUser.phoneSum = 0;
                            }
                            if (AtmManager.choosenServices[1])
                            {
                                AtmManager.currUser.factureSum = 0;
                            }
                            if (AtmManager.choosenServices[2])
                            {
                                AtmManager.currUser.gasSum = 0;
                            }                    
                        }                        
                    }
                    AtmManager.currUser = null;
                    AtmManager.choosenServices = new List<bool>() { false, false, false };
                    AtmManager.context = "";
                    Manager.CurrentPage = new WelcomePage();
                    Manager.MainFrame.Navigate(Manager.CurrentPage);
                    MainWindow.error.Text = "";
                }                
            }
        }
    }
}
