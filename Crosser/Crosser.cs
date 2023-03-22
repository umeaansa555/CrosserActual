using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Crosser
{
    internal class Crosser
    {
        public int x, y;
        public int speed;
        public int width = 20, height = 40;


        public Crosser(int _x, int _y, int _speed)
        {
            this.x = _x;
            this.y = _y;
            this.speed = _speed;
        }

        public void Move(string direction)
        {

            if(direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
            if (direction == "up")
            {
                y -= speed;
            }
            if (direction == "down")
            {
                y += speed;
            }

        }
    }
}
