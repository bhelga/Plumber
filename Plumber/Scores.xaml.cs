using System;
using System.Collections.Generic;
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
    /// Interaction logic for Scores.xaml
    /// </summary>
    public partial class Scores : Window
    {
        private List<Gamer> Players = new List<Gamer>();
        public List<Gamer> players
        {
            get
            {
                return Players;
            }
            set
            {
                players = value;
            }
        }
        public Scores(List<Gamer> gamers)
        {
            InitializeComponent();
            Players = gamers;
            for (int i = 0; i < players.Count; i++)
            {
                TextResult.Text += $"{i + 1}. " + players[i].ToString() + "\n";
            }
        }

        private void ComeBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void myTestKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
