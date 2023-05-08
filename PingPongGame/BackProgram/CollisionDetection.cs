using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
namespace PingPongGame.BackProgram
{
    class CollisionDetection
    {
        
        private Config config;

        public CollisionDetection(Config config)
        {
            this.config = config;
        }

        public bool topCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Top <= 0 + offset;
        }

        public bool bottomCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Top + element.Height >= config.heigth - offset;
        }

        public bool leftCollision(Rectangle element, double offset = 35)
        {
            if (element.Margin.Left <= 0 + offset == true)
                return true;
            else return false;
        }
        //Margin="левый_отступ, верхний_отступ, правый_отступ, нижний_отступ"
        public bool rightCollision(Rectangle element, double offset = 35)
        {
            return element.Margin.Left + element.Width >= config.width - offset;
        }

        public bool rightPadCollision()
        {
            if (((config.right.Margin.Left < config.ball.Margin.Left + config.ball.Width) &&
                (config.right.Margin.Top - config.ball.Height / 2 <= config.ball.Margin.Top) &&
                (config.right.Margin.Top + config.right.Height >= config.ball.Margin.Top)) == true)
                return true;
            else
                return false;

        }

        public bool leftPadCollision()
        {
            // 1. условие это проверка дотронулся ли шарик до ракетки (отступ слева + ширина)
            // 2. условие это проверка находится ли шарик на внутри границы ракетки(отсчет сверху
            // 2. условие это проверка находится ли шарик на внутри границы ракетки(отсчет снизу
            if (((config.left.Margin.Left + config.left.Width >= config.ball.Margin.Left) &&
                ((config.left.Margin.Top - (config.ball.Height / 2)) < config.ball.Margin.Top) &&
                (config.left.Margin.Top + config.left.Height >= config.ball.Margin.Top)) == true)
                return true;
            else
                return false;
        }
        public bool leftPadCornerCollision()
        {
            if ((((config.left.Margin.Left + config.left.Width > config.ball.Margin.Left + config.ball.RadiusX * 0.3) &&
                (config.left.Margin.Top + config.left.Height-20 >= config.ball.Margin.Top + config.ball.RadiusX * 0.71)) ||

                ((config.left.Margin.Left + config.left.Width > config.ball.Margin.Left + config.ball.RadiusX * 0.3) &&
                (config.left.Margin.Top <= config.ball.Margin.Top + config.ball.RadiusX * 1.69))) == true)
                return true;
            else
            
                
                return false;
            
        }
    }
}
