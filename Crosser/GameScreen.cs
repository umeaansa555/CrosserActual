using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Crosser
{
    public partial class GameScreen : UserControl
    {
        public int score = 0;

        SolidBrush yellowBrush = new SolidBrush(Color.Gold);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Crosser crosser; // create main character from blueprint
        public static Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        Random randGen = new Random();
        List<Enemy> enemies = new List<Enemy>();

        public GameScreen()
        {
            InitializeComponent();
            //bg sound is here rather than in InitializeGame in order to have it play continuously on this screen
            SoundPlayer trafficPlayer = new SoundPlayer(Properties.Resources.traffichorns);
            trafficPlayer.Play();
            InitializeGame();
        }

        public void InitializeGame()
        {
            crosser = new Crosser(300, 300, 10);

            enemies.Clear();

            for (int i = 1; i <= score; i++)
            {
                newEnemy();
            }

            scoreLabel.Text = $"{score}";

        }

        public void newEnemy()
        {
            int y = randGen.Next(50, this.Height - 30);
            int xSpeed = randGen.Next(1, 10);
            Enemy newEnemy = new Enemy(y, xSpeed);
            enemies.Add(newEnemy);
        }

        private void engine_Tick(object sender, EventArgs e)
        {
            #region shmovement
            if (leftArrowDown && crosser.x > 0)
            {
                crosser.Move("left");
            }
            if (rightArrowDown && crosser.x < this.Width - crosser.width)
            {
                crosser.Move("right");
            }
            if (upArrowDown && crosser.y > 0)
            {
                crosser.Move("up");
            }
            if (downArrowDown && crosser.y < this.Height - crosser.height)
            {
                crosser.Move("down");
            }
            #endregion


            foreach (Enemy n in enemies)
            {
                n.Move(this.Width, this.Height);
            }

            foreach (Enemy n in enemies)
            {
                // check if n is > width of screen
                // and remove enemy if it is
                if (n.x > this.Width - n.width || n.x < 0)
                {
                    enemies.Remove(n);
                    break;
                }
            }

            foreach (Enemy n in enemies)
            {
                if (n.Collision(crosser))
                {

                    engine.Stop();
                    
                    Form1.ChangeScreen(this, new EndScreen());
                    break;
                }
            }


            if (crosser.y == 0)
            {
                score++;
                scoreLabel.Text = $"{score}";
                InitializeGame();
            }


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(yellowBrush, crosser.x, crosser.y, crosser.width, crosser.height);
            foreach (Enemy n in enemies)
            {
                e.Graphics.FillRectangle(redBrush, n.x, n.y, n.width, n.height);
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }
    }
}
