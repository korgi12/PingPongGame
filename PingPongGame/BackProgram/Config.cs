using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System;

namespace PingPongGame.BackProgram
{
    public class Config : ConfigLoader
    {

        private double _width, _heigth;
        private Rectangle _ball, _left, _right;
        private Label _score;
        private double[] points = new double[] { 0, 0 };

        public bool canUpdate = false;

        public Config(double width, double heigth, Rectangle ball, Rectangle left,
            Rectangle right, Label score) : base()
        {
            this.width = width;
            this.heigth = heigth;
            this.ball = ball;
            this.left = left;
            this.right = right;
            this._score = score;
        }

        public double width
        {
            get
            {
                return _width;
            }
            private set
            {
                _width = value;
            }
        }

        public double heigth
        {
            get
            {
                return _heigth;
            }
            private set
            {
                _heigth = value;
            }
        }

        public Rectangle ball
        {
            get
            {
                return _ball;
            }
            private set
            {
                _ball = value;
            }
        }

        public Rectangle left
        {
            get
            {
                return _left;
            }
            private set
            {
                _left = value;
            }
        }

        public Rectangle right
        {
            get
            {
                return _right;
            }
            private set
            {
                _right = value;
            }
        }

        public void score(bool leftPlus)
        {
            if (leftPlus)
            {
                points[0] += 1;
            }
            else
            {
                points[1] += 1;
            }
            _score.Content = String.Format("{0} : {1}", points[0], points[1]);
        }

        public double[] ballPosition
        {
            get
            {
                return new double[]
                {
                    width / 2 - ball.Width / 2,
                    heigth / 2 - ball.Height / 2
                };
            }
        }

        public double[] leftPosition
        {
            get
            {
                return new double[]
                {
                    10,
                    heigth / 2 - left.Height / 2
                };
            }
        }

        public double[] rightPosition
        {
            get
            {
                return new double[]
                {
                    width - right.Width - 10,
                    heigth / 2 - right.Height / 2
                };
            }
        }
    }
}
