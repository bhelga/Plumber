using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Plumber
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : Window
    {
        private double[] Fields = new double[] { -2585.0000000000005, -391.6, -2865.0000000000005 - 70, -671.6 - 70 };
        private string FinalPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\water.jpg";
        private string FailPath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\images\tubes\FailGame.png";
        private string ScoreTablePath = @"D:\helga\university\programming\university\year\PlumberWPF\Plumber\Resources\scoreTable.txt";
        private bool StartGame = true;
        private bool GameOver = false;
        private bool Win = false;
        private int _tube2Counter = 0;
        private int _tube3Counter = 0;
        private int Timer = 0;
        DispatcherTimer timer;

        private List<Image> images = new List<Image>();

        private int Rotate = 0;

        private GameObject currentTube;
        private RotateTransform rotateTransform;

        private List<GameObject> Tubes = new List<GameObject>();
        GameObject FirstTube;
        GameObject LastTube;
        GameObject lastChainTube;

        public Window MyMainWindow { get; set; }

        public GameField()
        {
            
            InitializeComponent();
            Tubes.Clear();
            SetTimer();
            SetNewTube();
        }

        private void SetStartTubes()
        {
            LastTube = new Tube5() { GameObjectJointCoordinate = new List<double>() { LastButton.PointFromScreen(new Point(0,0)).X }, 
                GameObjectPlace = new GameObjectPlace(LastButton.PointFromScreen(new Point(0, 0)).X, LastButton.PointFromScreen(new Point(0, 0)).Y) };
            Tubes.Add(LastTube);

            FirstTube = new Tube1() { GameObjectJointCoordinate = new List<double>() { FirstButton.PointFromScreen(new Point(0, 0)).X  - 70}, 
                GameObjectPlace = new GameObjectPlace(FirstButton.PointFromScreen(new Point(0, 0)).X, FirstButton.PointFromScreen(new Point(0, 0)).Y) };
            FirstTube.AmountOfJoint--;
            Tubes.Add(FirstTube);
            images.Add(FirstTubeImage);

            lastChainTube = FirstTube;

            Fields = new double[] { FirstButton.PointFromScreen(new Point(0, 0)).X, FirstButton.PointFromScreen(new Point(0, 0)).Y, 
                LastButton.PointFromScreen(new Point(0, 0)).X - 70, LastButton.PointFromScreen(new Point(0, 0)).Y - 70 };
        }

        private void myTestKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                timer.Stop();
                MenuBar menuBar = new MenuBar();
                menuBar.MyMainWindow = this;
                menuBar.ShowDialog();
                if (menuBar.DialogResult == true)
                {
                    timer.Start();
                }
            }
            else if (e.Key == Key.Escape)
            {
                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Replay_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            GameField gameField = new GameField();
            gameField.Show();
            this.Close();
        }

        private void MenuBarButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            MenuBar menuBar = new MenuBar();
            menuBar.MyMainWindow = this;
            menuBar.ShowDialog();
            if (menuBar.DialogResult == true)
            {
                timer.Start();
            }
        }

        public void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Timer++;
            timerCheck();
            TimeSpan time = TimeSpan.FromSeconds(Timer);
            DateTime dateTime = DateTime.Today.Add(time);
            string displayTime = dateTime.ToString("mm:ss");
            LTimer.Content = displayTime;
        }
        
        private void timerCheck()
        {
            if (Timer == 30)
            {
                TextTimer.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0D7C87"));
                LTimer.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0D7C87"));
                MessageBox.Show("Зараз ти маєш 15 секунд, щоб скласти водопровід!");
            }
            else if (Timer == 41)
            {
                FirstTubeVideo.Visibility = Visibility.Visible;
                FirstTubeVideo.Play();
            }
            else if (Timer == 45)
            {
                if (StartGame == true)
                {
                    SetStartTubes();
                    StartGame = false;
                }
                FirstTubeImage.Source = new BitmapImage(new Uri(FirstTube.WinPath));
                FirstTubeVideo.Visibility = Visibility.Hidden;
                FirstTubeVideo.Pause();

                GameOver = true;
                Win = false;
                FinishTheGame();
            }
        }

        private void SetNewTube()
        {
            if (GameOver == false && StartGame == false) IsGameOver();
            Random random = new Random();
            int randomValue = random.Next(1, 5);
            Uri uri;
            BitmapImage bitmap = new BitmapImage();
            
            if (GameOver == false)
            {
                switch (randomValue)
                {
                    case 1:
                        currentTube = new Tube1();
                        break;
                    case 2:
                        if (_tube2Counter < 1)
                        {
                            currentTube = new Tube2();
                            _tube2Counter++;
                        }
                        else goto case 1;
                        break;
                    case 3:
                        if (_tube3Counter < 2)
                        {
                            currentTube = new Tube3();
                            _tube3Counter++;
                        }
                        else goto case 4;
                        break;
                    case 4:
                        currentTube = new Tube4();
                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }

                uri = new Uri(currentTube.Path);
                bitmap = new BitmapImage(uri);
                NewTubeImage.Source = bitmap;
            }
            else
            {
                FinishTheGame();
            }
            if (currentTube.gameObjectType == GameObjectType.Tube2)
            {
                Rotation.IsEnabled = false;
            }
            else
            {
                Rotation.IsEnabled = true;
            }
            
        }

        private void ShowWater(GameObject tube, Image image)
        {
            
            tube.SetWinPath();
            Uri uri = new Uri(tube.WinPath);
            BitmapImage bitmap = new BitmapImage(uri);
            image.Source = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartGame == true)
            {
                SetStartTubes();
                StartGame = false;
            }
            if (((Button)sender).IsEnabled == true && IsAvailableButton(sender, e) == true)
            {
                Grid grid = new Grid();
                var uri = new Uri(currentTube.Path);
                var bitmap = new BitmapImage(uri);
                Image image = new Image();
                image.Source = bitmap;
                image.RenderTransformOrigin = new Point(0.5, 0.5);
                image.RenderTransform = rotateTransform;
                grid.Children.Add(image);
                ((Button)sender).Content = grid;
                ((Button)sender).IsEnabled = false;
                Point location = ((Button)sender).PointFromScreen(new Point(0, 0)); 
                currentTube.GameObjectPlace = new GameObjectPlace(location.X, location.Y);
                SetJointCoordinates(location);
                currentTube.ObjRotation = Rotate;
                
                Tubes.Add(currentTube);
                rotateTransform = new RotateTransform(0);
                NewTubeImage.RenderTransform = rotateTransform;
                Rotate = 0;
                lastChainTube = currentTube;
                images.Add(image);
                SetNewTube();
            }
            else
            {
                MessageBox.Show("Ця клітинка недоступна!");
            }
            
        }

        private bool IsAvailableButton(object sender, RoutedEventArgs e)
        {
            if (lastChainTube.gameObjectType == GameObjectType.Tube2)
            {
                if (lastChainTube.GameObjectJoint[0] == 2)
                {
                    if ((((Button)sender).PointFromScreen(new Point(0, 0)).X - lastChainTube.GameObjectPlace.XCoordinate == -70 && ((Button)sender).PointFromScreen(new Point(0, 0)).Y == lastChainTube.GameObjectPlace.YCoordinate))
                    {
                        if (currentTube.GameObjectJoint[0] == 1)
                        {
                            currentTube.GameObjectJoint[0]++;
                            lastChainTube.GameObjectJoint[2]++;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (lastChainTube.GameObjectJoint[1] == 2)
                {
                    if ((((Button)sender).PointFromScreen(new Point(0, 0)).Y - lastChainTube.GameObjectPlace.YCoordinate == -70 && ((Button)sender).PointFromScreen(new Point(0, 0)).X == lastChainTube.GameObjectPlace.XCoordinate))
                    {
                        if (currentTube.GameObjectJoint[1] == 1)
                        {
                            currentTube.GameObjectJoint[1]++;
                            lastChainTube.GameObjectJoint[3]++;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (lastChainTube.GameObjectJoint[2] == 2)
                {
                    if ((((Button)sender).PointFromScreen(new Point(0, 0)).X - lastChainTube.GameObjectPlace.XCoordinate == 70 && ((Button)sender).PointFromScreen(new Point(0, 0)).Y == lastChainTube.GameObjectPlace.YCoordinate))
                    {
                        if (currentTube.GameObjectJoint[2] == 1)
                        {
                            currentTube.GameObjectJoint[2]++;
                            lastChainTube.GameObjectJoint[0]++;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (lastChainTube.GameObjectJoint[3] == 2)
                {
                    if ((((Button)sender).PointFromScreen(new Point(0, 0)).Y - lastChainTube.GameObjectPlace.YCoordinate == 70 && ((Button)sender).PointFromScreen(new Point(0, 0)).X == lastChainTube.GameObjectPlace.XCoordinate))
                    {
                        if (currentTube.GameObjectJoint[3] == 1)
                        {
                            currentTube.GameObjectJoint[3]++;
                            lastChainTube.GameObjectJoint[1]++;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if ((((Button)sender).PointFromScreen(new Point(0, 0)).X - lastChainTube.GameObjectPlace.XCoordinate == 70 && ((Button)sender).PointFromScreen(new Point(0, 0)).Y == lastChainTube.GameObjectPlace.YCoordinate))
            {
                if (currentTube.GameObjectJoint[2] == 1 && lastChainTube.GameObjectJoint[0] == 1)
                {
                    if (currentTube.gameObjectType == GameObjectType.Tube2)
                    {
                        currentTube.GameObjectJoint[1]--;
                        currentTube.GameObjectJoint[3]--;
                    }
                    currentTube.GameObjectJoint[2]++;
                    lastChainTube.GameObjectJoint[0]++;
                    return true;
                }
            }
            else if (((Button)sender).PointFromScreen(new Point(0, 0)).X - lastChainTube.GameObjectPlace.XCoordinate == -70 && (((Button)sender).PointFromScreen(new Point(0, 0)).Y == lastChainTube.GameObjectPlace.YCoordinate))
            {
                if (currentTube.GameObjectJoint[0] == 1 && lastChainTube.GameObjectJoint[2] == 1)
                {
                    if (currentTube.gameObjectType == GameObjectType.Tube2)
                    {
                        currentTube.GameObjectJoint[1]--;
                        currentTube.GameObjectJoint[3]--;
                    }
                    currentTube.GameObjectJoint[0]++;
                    lastChainTube.GameObjectJoint[2]++;
                    return true;
                }
            }
            else if (((Button)sender).PointFromScreen(new Point(0, 0)).Y - lastChainTube.GameObjectPlace.YCoordinate == 70 && ((Button)sender).PointFromScreen(new Point(0, 0)).X == lastChainTube.GameObjectPlace.XCoordinate)
            {
                if (currentTube.GameObjectJoint[3] == 1 && lastChainTube.GameObjectJoint[1] == 1)
                {
                    if (currentTube.gameObjectType == GameObjectType.Tube2)
                    {
                        currentTube.GameObjectJoint[0]--;
                        currentTube.GameObjectJoint[2]--;
                    }
                    currentTube.GameObjectJoint[3]++;
                    lastChainTube.GameObjectJoint[1]++;
                    return true;
                }
            }
            else if (((Button)sender).PointFromScreen(new Point(0, 0)).Y - lastChainTube.GameObjectPlace.YCoordinate == -70 && (((Button)sender).PointFromScreen(new Point(0, 0)).X == lastChainTube.GameObjectPlace.XCoordinate))
            {
                if (currentTube.GameObjectJoint[1] == 1 && lastChainTube.GameObjectJoint[3] == 1)
                {
                    if (currentTube.gameObjectType == GameObjectType.Tube2)
                    {
                        currentTube.GameObjectJoint[0]--;
                        currentTube.GameObjectJoint[2]--;
                    }
                    currentTube.GameObjectJoint[1]++;
                    lastChainTube.GameObjectJoint[3]++;
                    return true;
                }
            }
            return false;
        }

        private void Rotation_Click(object sender, RoutedEventArgs e)
        {
            currentTube.SetNewJoint();
            Rotate++;
            switch (Rotate)
            {
                case 0:
                    rotateTransform = new RotateTransform(0);
                    break;
                case 1:
                    rotateTransform = new RotateTransform(90);
                    break;
                case 2:
                    rotateTransform = new RotateTransform(180);
                    break;
                case 3:
                    rotateTransform = new RotateTransform(270);
                    break;
                default:
                    Rotate = 0;
                    goto case 0;
            }
            NewTubeImage.RenderTransform = rotateTransform;
        }

        private void SetJointCoordinates(Point point)
        {
            if (currentTube.GameObjectJoint[0] == 1)
            {
                currentTube.GameObjectJointCoordinate.Add(point.X);
            }
            if (currentTube.GameObjectJoint[1] == 1)
            {
                currentTube.GameObjectJointCoordinate.Add(point.Y);
            }
            if (currentTube.GameObjectJoint[2] == 1)
            {
                currentTube.GameObjectJointCoordinate.Add(point.X - 70);
            }
            if (currentTube.GameObjectJoint[3] == 1)
            {
                currentTube.GameObjectJointCoordinate.Add(point.Y - 70);
            }
        }

        private async void FinishTheGame()
        {
            Tubes.RemoveAt(0);
            var uri = new Uri(FinalPath);
            var bitmap = new BitmapImage(uri);
            NewTubeImage.Source = bitmap;
            if (Win == true)
            {
                Tubes.Add(LastTube);
                images.Add(LastTubeImage);
                lastChainTube.GameObjectJoint[2]++;
                int i = 0;
                foreach (var tube in Tubes)
                {
                    await Task.Delay(1000);
                    if (i == images.Count - 1)
                    {
                        ShowWater(tube, images[i]);
                        await Task.Delay(2000);
                        SaveInformation();
                    }
                    else
                    {
                        ShowWater(tube, images[i]);
                    }
                    i++;
                }
            }
            else
            {
                timer.Stop();
                int i = 0;
                foreach (var tube in Tubes)
                {
                    await Task.Delay(1000);
                    if (i == images.Count - 1)
                    {
                        ShowWater(tube, images[i]);
                        await Task.Delay(1000);
                        uri = new Uri(FailPath);
                        bitmap = new BitmapImage(uri);
                        images[i].Source = bitmap;
                        await Task.Delay(2000);
                        MessageBox.Show("Гру програно!!!");
                    }
                    else
                    {
                        ShowWater(tube, images[i]);
                    }
                    i++;
                }
            }
        }

        private void IsGameOver()
        {
            
            foreach (var coord in lastChainTube.GameObjectJointCoordinate)
            {
                if (coord == LastTube.GameObjectJointCoordinate[0] && lastChainTube.GameObjectPlace.YCoordinate == LastTube.GameObjectPlace.YCoordinate)
                {
                    GameOver = true;
                    Win = true;
                    timer.Stop();
                }
                else
                {
                    int counter = 0;
                    int j = 0;
                    for (int i = 0; i < lastChainTube.GameObjectJoint.Length; i++)
                    {
                        if (lastChainTube.GameObjectJoint[i] == 1)
                        {
                            counter++;
                            j = i;
                        }
                    }
                    if (counter == 1 || lastChainTube.gameObjectType == GameObjectType.Tube3 || lastChainTube.gameObjectType == GameObjectType.Tube2)
                    {
                        counter = 0;
                        foreach (var jcoord in lastChainTube.GameObjectJointCoordinate)
                        {
                            foreach (var field in Fields)
                            {
                                if (jcoord == field)
                                {
                                    if (lastChainTube.gameObjectType == GameObjectType.Tube3)
                                    {
                                        if ((lastChainTube.GameObjectPlace.XCoordinate == field && lastChainTube.GameObjectJoint[0] == 1)||
                                            (lastChainTube.GameObjectPlace.XCoordinate - 70 == field && lastChainTube.GameObjectJoint[2] == 1) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate == field && lastChainTube.GameObjectJoint[1] == 1) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate - 70 == field && lastChainTube.GameObjectJoint[3] == 1))
                                        {
                                            counter++;
                                        }
                                    }
                                    else if (lastChainTube.gameObjectType == GameObjectType.Tube2)
                                    {
                                        if ((lastChainTube.GameObjectPlace.XCoordinate == field && lastChainTube.GameObjectJoint[0] == 1) ||
                                            (lastChainTube.GameObjectPlace.XCoordinate - 70 == field && lastChainTube.GameObjectJoint[2] == 1) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate == field && lastChainTube.GameObjectJoint[1] == 1) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate - 70 == field && lastChainTube.GameObjectJoint[3] == 1) ||
                                            (lastChainTube.GameObjectPlace.XCoordinate == field && lastChainTube.GameObjectJoint[0] == 0) ||
                                            (lastChainTube.GameObjectPlace.XCoordinate - 70 == field && lastChainTube.GameObjectJoint[2] == 0) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate == field && lastChainTube.GameObjectJoint[1] == 0) ||
                                            (lastChainTube.GameObjectPlace.YCoordinate - 70 == field && lastChainTube.GameObjectJoint[3] == 0))
                                        {
                                            counter++;
                                        }
                                    }
                                    else if (lastChainTube.gameObjectType == GameObjectType.Tube2)
                                    {
                                        if (lastChainTube.GameObjectJoint[0] == 2) 
                                            lastChainTube.GameObjectJoint[2] = 2;
                                        else if (lastChainTube.GameObjectJoint[1] == 2)
                                            lastChainTube.GameObjectJoint[3] = 2;
                                        else if (lastChainTube.GameObjectJoint[2] == 2)
                                            lastChainTube.GameObjectJoint[0] = 2;
                                        else if (lastChainTube.GameObjectJoint[3] == 2)
                                            lastChainTube.GameObjectJoint[1] = 2;
                                    }
                                    else
                                    {
                                        GameOver = true;
                                        break;
                                    }
                                    
                                }
                            }
                            
                            if (counter == 2 || (counter == 1 && lastChainTube.gameObjectType == GameObjectType.Tube2))
                            {
                                GameOver = true;
                                break;
                            }
                        }
                        foreach (var tube in Tubes)
                        {
                            if ((counter == 0 && lastChainTube.gameObjectType != GameObjectType.Tube3) || counter == 1)
                            {
                                if (j == 0)
                                {
                                    if (lastChainTube.GameObjectPlace.XCoordinate == tube.GameObjectPlace.XCoordinate - 70 && lastChainTube.GameObjectPlace.YCoordinate == tube.GameObjectPlace.YCoordinate)
                                    {
                                        GameOver = true;
                                        break;
                                    }
                                }
                                else if (j == 1)
                                {
                                    if (lastChainTube.GameObjectPlace.YCoordinate == tube.GameObjectPlace.YCoordinate - 70 && lastChainTube.GameObjectPlace.XCoordinate == tube.GameObjectPlace.XCoordinate)
                                    {
                                        GameOver = true;
                                        break;
                                    }
                                }
                                else if (j == 2)
                                {
                                    if (lastChainTube.GameObjectPlace.XCoordinate - 70 == tube.GameObjectPlace.XCoordinate && lastChainTube.GameObjectPlace.YCoordinate == tube.GameObjectPlace.YCoordinate)
                                    {
                                        GameOver = true;
                                        break;
                                    }
                                }
                                else if (j == 3)
                                {
                                    if (lastChainTube.GameObjectPlace.YCoordinate - 70 == tube.GameObjectPlace.YCoordinate && lastChainTube.GameObjectPlace.XCoordinate == tube.GameObjectPlace.XCoordinate)
                                    {
                                        GameOver = true;
                                        break;
                                    }
                                }
                            }
                            
                            
                        }
                    }
                }
            }
        }

        private void SaveInformation()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ScoreTablePath, true, Encoding.Default))
                {
                    sw.WriteLine(Timer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            WinWindow winWindow = new WinWindow();
            winWindow.ShowDialog();
        }

        



        //private void IsGameOver()
        //{
        //    bool flag1 = true;
        //    bool flag2 = true;
        //    bool flag3 = true;



        //    while (flag1 == true)
        //    {
        //        if (Tubes.Count < 3)
        //        {
        //            lastChainTube = Tubes[0];
        //            continue;
        //        }
        //        else
        //        {
        //            foreach (var tube in Tubes)
        //            {
        //                if ((Math.Abs(tube.GameObjectPlace.XCoordinate - lastChainTube.GameObjectPlace.XCoordinate) == 70 && tube.GameObjectPlace.YCoordinate == lastChainTube.GameObjectPlace.YCoordinate)
        //                || (Math.Abs(tube.GameObjectPlace.YCoordinate - lastChainTube.GameObjectPlace.YCoordinate) == 70 && tube.GameObjectPlace.XCoordinate == lastChainTube.GameObjectPlace.XCoordinate))
        //                {
        //                    if (tube.GameObjectJoint[2] == 1)
        //                }
        //            }
        //        }
        //    }
        //}

        //private void IsGameOver()
        //{
        //    bool flag = false;
        //    for (int tube1 = 0; tube1 < Tubes.Count;)
        //    {
        //        for (int tube2 = 0; tube2 < Tubes.Count;)
        //        {
        //            if (Tubes[tube2].GameObjectPlace.XCoordinate - Tubes[tube1].GameObjectPlace.XCoordinate == 70 && Tubes[tube2].GameObjectPlace.YCoordinate == Tubes[tube1].GameObjectPlace.YCoordinate)
        //            {
        //                if (Tubes[tube2].GameObjectJoint[2] == 1 && Tubes[tube1].GameObjectJoint[0] == 1)
        //                {
        //                    Tubes[tube1].AmountOfJoint--;
        //                    Tubes[tube2].AmountOfJoint--;
        //                }
        //            }
        //            else if (Tubes[tube2].GameObjectPlace.XCoordinate - Tubes[tube1].GameObjectPlace.XCoordinate == -70 && Tubes[tube2].GameObjectPlace.YCoordinate == Tubes[tube1].GameObjectPlace.YCoordinate)
        //            {
        //                if (Tubes[tube1].GameObjectJoint[2] == 1 && Tubes[tube2].GameObjectJoint[0] == 1)
        //                {
        //                    Tubes[tube1].AmountOfJoint--;
        //                    Tubes[tube2].AmountOfJoint--;
        //                }
        //            }
        //            else if (Tubes[tube2].GameObjectPlace.YCoordinate - Tubes[tube1].GameObjectPlace.YCoordinate == 70 && Tubes[tube2].GameObjectPlace.XCoordinate == Tubes[tube1].GameObjectPlace.XCoordinate)
        //            {
        //                if (Tubes[tube2].GameObjectJoint[3] == 1 && Tubes[tube1].GameObjectJoint[1] == 1)
        //                {
        //                    Tubes[tube1].AmountOfJoint--;
        //                    Tubes[tube2].AmountOfJoint--;
        //                }
        //            }
        //            else if (Tubes[tube2].GameObjectPlace.YCoordinate - Tubes[tube1].GameObjectPlace.YCoordinate == -70 && Tubes[tube2].GameObjectPlace.XCoordinate == Tubes[tube1].GameObjectPlace.XCoordinate)
        //            {
        //                if (Tubes[tube1].GameObjectJoint[1] == 1 && Tubes[tube2].GameObjectJoint[3] == 1)
        //                {
        //                    Tubes[tube1].AmountOfJoint--;
        //                    Tubes[tube2].AmountOfJoint--;
        //                }
        //            }

        //            if (Tubes[tube2].AmountOfJoint == 0)
        //            {
        //                Tubes.RemoveAt(tube2);
        //            }
        //            else
        //            {
        //                tube2++;
        //            }
        //            if (tube1 >= Tubes.Count) break;
        //        }
        //        if (tube1 < Tubes.Count && Tubes[tube1].AmountOfJoint == 0)
        //        {
        //            Tubes.RemoveAt(tube1);
        //        }
        //        else
        //        {
        //            tube1++;
        //        }
        //    }
        //    if (Tubes.Count == 0)
        //    {
        //        GameOver = true;
        //    }
        //}

        //private void IsGameOver()
        //{
        //    bool flag = false;
        //    for (int tube1 = 0; tube1 < Tubes.Count;)
        //    {
        //        for (int tube2 = 0; tube2 < Tubes.Count;)
        //        {
        //            if ((Math.Abs(Tubes[tube2].GameObjectPlace.XCoordinate - Tubes[tube1].GameObjectPlace.XCoordinate) == 70 && Tubes[tube2].GameObjectPlace.YCoordinate == Tubes[tube1].GameObjectPlace.YCoordinate)
        //                || (Math.Abs(Tubes[tube2].GameObjectPlace.YCoordinate - Tubes[tube1].GameObjectPlace.YCoordinate) == 70 && Tubes[tube2].GameObjectPlace.XCoordinate == Tubes[tube1].GameObjectPlace.XCoordinate))
        //            if (Math.Abs(Tubes[tube2].GameObjectPlace.XCoordinate - Tubes[tube1].GameObjectPlace.XCoordinate) == 70 || Math.Abs(Tubes[tube2].GameObjectPlace.YCoordinate - Tubes[tube1].GameObjectPlace.YCoordinate) == 70)
        //            {
        //                for (int i = 0; i < Tubes[tube1].GameObjectJointCoordinate.Count; i++)
        //                {
        //                    for (int j = 0; j < Tubes[tube2].GameObjectJointCoordinate.Count;)
        //                    {
        //                        if (i >= Tubes[tube1].GameObjectJointCoordinate.Count) break;
        //                        if (Tubes[tube1].GameObjectJointCoordinate.Count > 0 && Tubes[tube1].GameObjectJointCoordinate[i] == Tubes[tube2].GameObjectJointCoordinate[j])
        //                        {
        //                            if ((Tubes[tube1].GameObjectPlace.XCoordinate == Tubes[tube2].GameObjectPlace.XCoordinate && Tubes[tube1].GameObjectPlace.XCoordinate == Tubes[tube1].GameObjectJointCoordinate[i])
        //                                || (Tubes[tube1].GameObjectPlace.YCoordinate == Tubes[tube2].GameObjectPlace.YCoordinate && Tubes[tube1].GameObjectPlace.YCoordinate == Tubes[tube1].GameObjectJointCoordinate[i])
        //                                || (Tubes[tube1].GameObjectPlace.XCoordinate - 70 == Tubes[tube2].GameObjectPlace.XCoordinate - 70 && Tubes[tube1].GameObjectPlace.XCoordinate - 70 == Tubes[tube1].GameObjectJointCoordinate[i])
        //                                || (Tubes[tube1].GameObjectPlace.XCoordinate - 70 == Tubes[tube2].GameObjectPlace.XCoordinate - 70 && Tubes[tube1].GameObjectPlace.XCoordinate - 70 == Tubes[tube1].GameObjectJointCoordinate[i]))
        //                            {
        //                                j++;
        //                            }
        //                            else
        //                            {
        //                                Tubes[tube1].GameObjectJointCoordinate.RemoveAt(i);
        //                                Tubes[tube2].GameObjectJointCoordinate.RemoveAt(j);
        //                            }

        //                            break;
        //                        }
        //                        else
        //                        {
        //                            j++;
        //                        }
        //                    }
        //                }
        //            }
        //            if (Tubes[tube2].GameObjectJointCoordinate.Count == 0)
        //            {
        //                Tubes.RemoveAt(tube2);
        //            }
        //            else
        //            {
        //                tube2++;
        //            }
        //            if (tube1 >= Tubes.Count) break;
        //        }
        //        if (tube1 < Tubes.Count && Tubes[tube1].GameObjectJointCoordinate.Count == 0)
        //        {
        //            Tubes.RemoveAt(tube1);
        //        }
        //        else
        //        {
        //            tube1++;
        //        }
        //    }
        //    if (Tubes.Count == 0)
        //    {
        //        GameOver = true;
        //    }
        //}


        //private void IsGameOver()
        //{
        //    foreach (var tube1 in Tubes)
        //    {
        //        foreach (var tube2 in Tubes)
        //        {
        //            if (Math.Abs(tube2.GameObjectPlace.XCoordinate - tube1.GameObjectPlace.XCoordinate) == 70 && Math.Abs(tube2.GameObjectPlace.YCoordinate - tube1.GameObjectPlace.YCoordinate) == 70)
        //            {
        //                for (int i = 0; i < tube1.GameObjectJointCoordinate.Count; i++)
        //                {
        //                    for (int j = 0; j < tube2.GameObjectJointCoordinate.Count; j++)
        //                    {
        //                        if (tube1.GameObjectJointCoordinate[i] == tube2.GameObjectJointCoordinate[j])
        //                        {
        //                            tube1.GameObjectJointCoordinate.RemoveAt(i);
        //                            tube2.GameObjectJointCoordinate.RemoveAt(j);
        //                        }
        //                    }
        //                }
        //            }
        //            if (tube2.GameObjectJointCoordinate.Count == 0)
        //            {
        //                Tubes.Remove(tube2);
        //            }
        //        }
        //        if (tube1.GameObjectJointCoordinate.Count == 0)
        //        {
        //            Tubes.Remove(tube1);
        //        }
        //    }
        //    if (Tubes.Count == 0)
        //    {
        //        GameOver = true;
        //    }
        //}

        //private void Flip_Click(object sender, RoutedEventArgs e)
        //{
        //    FlipImage++;
        //    scaleTransform = new ScaleTransform();
        //    switch (FlipImage)
        //    {
        //        case 0:
        //            scaleTransform.ScaleX = 1;
        //            scaleTransform.ScaleY = 1;
        //            break;
        //        case 1:
        //            scaleTransform.ScaleX = -1;
        //            scaleTransform.ScaleY = 1;
        //            break;
        //        case 2:
        //            scaleTransform.ScaleX = 1;
        //            scaleTransform.ScaleY = -1;
        //            break;
        //        case 3:
        //            scaleTransform.ScaleX = -1;
        //            scaleTransform.ScaleY = -1;
        //            break;
        //        default:
        //            FlipImage = 0;
        //            goto case 0;
        //    }
        //    NewTubeImage.RenderTransform = scaleTransform;
        //}
    }
}
