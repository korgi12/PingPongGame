using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PingPongGame.BackProgram
{
    class GameLoop : Window
    {

        private Config config;
        private Logic logic;

        private Thread gameThread;
        private bool running = false;

        private string _key = null;

        public GameLoop(Config config)
        {
            this.config = config;
        }

        public void start()
        {
            if (!running)  // Если игровой цикл не запущен
            {
                running = true;
                logic = new Logic(config);

                gameThread = new Thread(() => {
                    Dispatcher.Invoke(() => {
                        logic.setStartPosition();
                    });

                    Thread.Sleep(500);  // Ждем 500 милисекунд для того, чтобы передать управление после анимации
                    long lastUpdate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    while (running)
                    {
                        if (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - lastUpdate
                        >= 1000 / config.fps && config.canUpdate)
                        {
                            Dispatcher.Invoke(() => {
                                logic.move(_key);
                            });
                            lastUpdate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                        }
                    }
                });
                gameThread.Start();  // Запускаем игровой цикл
            }
        }

        public void stop()
        {
            Console.WriteLine("Try stop");
            Console.WriteLine(running);
            if (running)  // Если игровой цикл запущен
            {
                running = false;  // Завершаем работу game loop
                Application.Current.Shutdown();  // Завершаем работу приложения
            }
        }

        public void setKey()
        {
            _key = null;
        }

       

        public void setKey(Key key)
        {
            if (key == Key.Up)
            {
                _key = "up";
            }
            else if (key == Key.Down)
            {
                _key = "down";
            }
        }

    }
}
