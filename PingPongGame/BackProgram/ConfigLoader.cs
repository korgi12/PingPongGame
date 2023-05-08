using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongGame.BackProgram
{
    public class ConfigLoader
    {

        private string[] configuration;
        private double[] _speed = null;

        private List<double> speedRange;

        public ConfigLoader()
        {
            load();
            speedRange = new List<double>();
            foreach (string element in configuration[configuration.Length - 1].Split(','))
            {
                speedRange.Add(double.Parse(element.Trim()));
            }
        }

        public int fps
        {
            get
            {
                return int.Parse(configuration[0]);
            }
        }
        //скорость игрока
        public double playerSpeed
        {
            get
            {
                return double.Parse(configuration[1]);
            }
        }
        //скорость врага
        public double enemySpeed
        {
            get
            {
                return double.Parse(configuration[2]);
            }
        }

        public double[] speed
        {
            get
            {
                if (_speed != null)
                {
                    return _speed;
                }
                else
                {
                    _speed = new double[]
                    {
                        // выбирает рандомную скорость из всех элементов таким образом выбирается рандомно куда полетит шарик
                        speedRange[new Random().Next(speedRange.Count)],
                        speedRange[new Random().Next(speedRange.Count)]
                    };
                    return _speed;
                }
            }
            set
            {
                _speed = value;
            }
        }

        public void invertHorisontalSpeed()
        {
            if (_speed != null)
                _speed[0] = -_speed[0];
        }

        public void invertVertcalSpeed()
        {
            if (_speed != null)
                _speed[1] = -_speed[1];
        }

        private void load()
        {
            
            if (File.Exists("./config.txt") && new FileInfo("./config.txt").Length != 0)
            {
                configuration = File.ReadAllLines("./config.txt");
            }
            else
            {
                File.WriteAllLines("./config.txt", new string[] {
                    "90", "4", "2", "-5, -4, 4, 5" // Стандартный конфиг
                });
                load();
            }
        }

    }
}
