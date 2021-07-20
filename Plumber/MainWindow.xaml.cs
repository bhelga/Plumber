using System;
using System.Collections.Generic;
using System.IO;
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

namespace Plumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void myTestKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                HowToPlay howToPlay = new HowToPlay();
                howToPlay.Show();
                this.Close();
                
            }
            else if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            GameField gameField = new GameField();
            gameField.Show();
            this.Close();
        }

        private void HowToPlay_Click(object sender, RoutedEventArgs e)
        {
            
            HowToPlay howToPlay = new HowToPlay();
            howToPlay.Show();
            this.Close();
        }

        private void HelpBox_Click(object sender, RoutedEventArgs e)
        {
            HelpBox helpBox = new HelpBox();
            helpBox.Show();
            this.Close();
        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {
            List<Gamer> gamers = new Gamer().ReadFile();
            Scores scores = new Scores(gamers);
            scores.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
