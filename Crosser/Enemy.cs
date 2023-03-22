using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Crosser
{
    internal class Enemy
    {
        public int x = 0, y, width = 40 , height = 15, xSpeed;
        

        public Enemy( int _y, int _xSpeed)
        {
            //this.x = _x;
            this.y = _y;
            this.xSpeed = _xSpeed;
        }


        public void Move(int screenWidth, int screenHeight)
        {
            x += xSpeed;
        }
        public bool Collision(Crosser c)
        {
            Rectangle enemyRec = new Rectangle(x, y, width, height);
            Rectangle crosserRec = new Rectangle(c.x, c.y, c.width, c.height);

            if (enemyRec.IntersectsWith(crosserRec))
            {
                #region
                if (xSpeed > 0)
                {
                    x = c.x - width;
                }
                else
                {
                    y = c.y + c.height;
                }
                #endregion
                return true;
            }
            return false;
        }
    }
}
