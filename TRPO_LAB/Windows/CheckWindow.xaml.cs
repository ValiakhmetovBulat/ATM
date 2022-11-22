using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace TRPO_LAB.Windows
{
    /// <summary>
    /// Логика взаимодействия для CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        public CheckWindow(int _sumToPay, int _enteredSum, int _exchange, List<bool> _paidServices)
        {
            InitializeComponent();
            checkNum.Text = ((new Random()).Next(100000, 999999)).ToString();

            sumToPay.Text = _sumToPay.ToString();
            enteredSum.Text = _enteredSum.ToString();
            exchange.Text = _exchange.ToString();
            if (_paidServices[0] == true)
            {
                paidServices.Text += "Стационарный телефон\n";
            }
            if (_paidServices[1] == true)
            {
                paidServices.Text += "Счет-фактура\n";
            }
            if (_paidServices[2] == true)
            {
                paidServices.Text += "Газ\n";
            }
        }
    }
}
