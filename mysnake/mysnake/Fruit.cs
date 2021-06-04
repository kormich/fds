using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    class Fruit
    {
        public Point Location => fruit.Location;
        public int score = 0;

        private PictureBox fruit = new PictureBox();
        private Control _control;
        private int _width = 15;
        private int _height = 15;
        private int _sizesnake = 40;

        public Fruit(Control control)
        {
            _control = control;
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(_sizesnake, _sizesnake);
            CreateFruit();
            _control.Controls.Add(fruit);
        }

        private void CreateFruit()
        {
            var random = new Random();
            var X = random.Next(0, _width);
            var Y = random.Next(0, _height);
            
            fruit.Location = new Point(X * _sizesnake, Y * _sizesnake);
        }

        public void Eat() => CreateFruit();

        public void Createfruit(PictureBox[] snake, PictureBox fruit, Panel panel1, int rXX, int rYY)
        {
            //Random r = new Random();
            //_rX = r.Next(0, width );
            //int tempI = _rX % _sizesnake;
            //_rX -= tempI;
            //_rY = r.Next(0, width);
            //int tempJ = _rY % _sizesnake;
            //_rY -= tempJ;

            //for (int i = 0; i <= score; i++)
            //{
            //    if (snake[i].Location.X == _rX && snake[i].Location.Y == _rY || _rX == rXX && _rY == rYY)
            //    {
            //        Createfruit(snake, fruit, panel1, rXX, rYY);
            //    }
            //}

            //fruit.Location = new Point(_rX, _rY);
            //panel1.Controls.Add(fruit);

        }

        public void eatFruit(Snake snake, PictureBox fruit, Panel panel1, int _forX, int _forY, int rXX, int rYY, Timer timer1 , Label labelScore )
        {
            if (score == 195)
            {
                timer1.Stop();
                Form3 form3 = new Form3();
                form3.Show();
            //}

            //if (snake[0].Location.X == _rX && snake[0].Location.Y ==_rY)
            //{
            //    score += 1;
            //    labelScore.Text = "Score: " + score;
            //    snake[score] = new PictureBox();
            //    snake[score].Location = new Point(snake[score - 1].Location.X - 40*_forX , snake[score - 1].Location.Y - 40*_forY) ;
            //    snake[score].Size = new Size(_sizesnake, _sizesnake);
            //    snake[score].BackColor = Color.Green;
            //    panel1.Controls.Add(snake[score]);
            //    Createfruit(snake, fruit, panel1, rXX, rYY);
            }
        }
    }
}
