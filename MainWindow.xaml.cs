using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button_Click_1Async(sender, e);
        }

        private async Task Button_Click_1Async(object sender, RoutedEventArgs e)
        {
            var chart = new ChartAndCharacteristics(ulong.Parse(textBox2.Text), ulong.Parse(textBox1.Text), ulong.Parse(textBox3.Text));
            var windowWait = new WindowWait();
            windowWait.Show();
            await Task.Run(chart.Calculate);
            windowWait.Close();
            chart.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button_Click_2Async(sender, e);
        }

        private async Task Button_Click_2Async(object sender, RoutedEventArgs e)
        {
            var indirectSign = new IndirectSign(ulong.Parse(textBox2.Text), ulong.Parse(textBox1.Text), ulong.Parse(textBox3.Text));
            var windowWait = new WindowWait();
            windowWait.Show();
            await Task.Run(indirectSign.Calculate);
            windowWait.Close();
            indirectSign.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button_Click_3Async(sender, e);
        }

        private async Task Button_Click_3Async(object sender, RoutedEventArgs e)
        {
            var period = new Period(ulong.Parse(textBox2.Text), ulong.Parse(textBox1.Text), ulong.Parse(textBox3.Text));
            var windowWait = new WindowWait();
            windowWait.Show();
            await Task.Run(period.Calculate);
            windowWait.Close();
            period.Show();
        }

        private void UpdateButtonsEnabled()
        {
            ulong n1, n2, n3;
            if (ulong.TryParse(textBox1.Text, out n1) && n1 > 10)
                if (ulong.TryParse(textBox2.Text, out n2) && n2 > 10)
                    if (ulong.TryParse(textBox3.Text, out n3) && n3 > 10 && n3 > n2 && n3 > n1)
                    {
                        button1.IsEnabled = true;
                        button2.IsEnabled = true;
                        button3.IsEnabled = true;
                        return;
                    }

            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            TextBoxInputFilter(sender, e);
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            TextBoxInputFilter(sender, e);
        }

        private void TextBox_PreviewTextInput_3(object sender, TextCompositionEventArgs e)
        {
            TextBoxInputFilter(sender, e);
        }

        private void TextBoxInputFilter(object sender, TextCompositionEventArgs e)
        {
            string text = ((TextBox)sender).Text + e.Text;
            ulong num;
            if (!ulong.TryParse(text, out num))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonsEnabled();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonsEnabled();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonsEnabled();
        }
    }
}
