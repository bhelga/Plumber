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
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : Window
    {
        public MenuBar()
        {
            InitializeComponent();
        }
        private Window myMainWindow;
        public Window MyMainWindow 
        {
            get 
            {
                return myMainWindow;
            }
            set 
            {
                myMainWindow = value;
            }
        }

        private void MenuBarContinue_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            MyMainWindow.Close();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            
            GameField gameField = new GameField();
            this.Close();
            MyMainWindow.Close();
            gameField.ShowDialog();
        }

        private void GoToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            MyMainWindow.Close();
            mainWindow.ShowDialog();
        }
    }
}
