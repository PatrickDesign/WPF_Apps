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

namespace Third_Xaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<int> Operands;
        public char CurrOperation;

        public MainWindow()
        {
            InitializeComponent();
            Operands = new List<int>();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        private void Calc_Button_Click(object sender, RoutedEventArgs e)
        {
            calcWindow.Text = (!calcWindow.Text.Equals("0") ? calcWindow.Text : "") + ((Button)sender).Content;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            if(!calcWindow.Text.Equals("0"))
                Operands.Add(int.Parse(calcWindow.Text));

            if (Operands.Count() < 2)
                return;

            if (CurrOperation == '+')
                calcWindow.Text = (Operands[0] + Operands[1]).ToString();
            else
                calcWindow.Text = (Operands[0] - Operands[1]).ToString();

            Operands.Clear();

        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            calcWindow.Text = "0";
            Operands.Clear();
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calcWindow.Text.Equals("0"))
                return;

            Operands.Add(int.Parse(calcWindow.Text));
            calcWindow.Text = "0";
            CurrOperation = '+';
        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            Operands.Add(int.Parse(calcWindow.Text));
            calcWindow.Text = "0";
            CurrOperation = '-';
        }
    }
}
