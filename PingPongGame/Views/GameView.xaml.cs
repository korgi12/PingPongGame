using PingPongGame.BackProgram;
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

namespace PingPongGame.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        // Location Variables
        private double width, heigth;
        private GameLoop gameLoop;
        private Config config;

        public GameView()
        {
            InitializeComponent();
           
        }
        private void CustomConstructor()
        {
            config = new Config(width, heigth, ball, left, right, score);
            gameLoop = new GameLoop(config);
            gameLoop.start();
            var window1 = Window.GetWindow(this);
            window1.KeyDown += Window_KeyDown;
        }
        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            
            FrameworkElement window = this.Content as FrameworkElement;
            if (window != null)
            {
                width = window.ActualWidth;  // Получаем действительный размер окна
                heigth = window.ActualHeight;  // Получаем действительный размер окна
                CustomConstructor();
            }
           
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            gameLoop.setKey(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            gameLoop.setKey();
        }
    }
}
