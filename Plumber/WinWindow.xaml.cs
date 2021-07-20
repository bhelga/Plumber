using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plumber
{
    /// <summary>
    /// Interaction logic for WinWindow.xaml
    /// </summary>
    public partial class WinWindow : Window
    {
        private TextBox textBox;
        public WinWindow()
        {
            InitializeComponent();
        }

        private void GamerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox = (TextBox)sender;
            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\scoreTable.txt", true, Encoding.Default))
                {
                    sw.WriteLine(textBox.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.DialogResult = true;
        }

        private void GamerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(@"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\scoreTable.txt", true, Encoding.Default))
                    {
                        sw.WriteLine(textBox.Text);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                this.DialogResult = true;
            }
        }

        private void GamerName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= GamerName_GotFocus;
        }
        private void myTestKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(@"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\scoreTable.txt", true, Encoding.Default))
                    {
                        sw.WriteLine("Random Guy");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                this.DialogResult = true;
            }
        }
    }
}
