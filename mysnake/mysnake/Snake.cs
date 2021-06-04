using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    class Snake
    {
        public int _forX;
        public int _forY;
        private int sizesnake = 40;
        Fruit fruit = new Fruit();

        public void Run(object sender, KeyEventArgs a)
        {
            switch (a.KeyCode.ToString())
            {
                case "Right":

                    _forX = 1;
                    _forY = 0;

                    break;

                case "Left":

                    _forX = -1;
                    _forY = 0;

                    break;
                case "Up":

                    _forY = -1;
                    _forX = 0;

                    break;
                case "Down":

                    _forY = 1;
                    _forX = 0;

                    break;
            }

        }
        public void moveSnake(PictureBox[] snake,int score)
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = new Point(snake[i - 1].Location.X, snake[i - 1].Location.Y);

            }

            snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, snake[0].Location.Y + _forY * sizesnake);

            if (snake[0].Location.X < 0)
            {
                snake[0].Location = new Point(560, snake[0].Location.Y + _forY * sizesnake);

            }
            if (snake[0].Location.X > 560)
            {
                snake[0].Location = new Point(0, snake[0].Location.Y + _forY * sizesnake);
            }

            if (snake[0].Location.Y < 0)
            {
                snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, 560);
            }

            if (snake[0].Location.Y > 560)
            {
                snake[0].Location = new Point(snake[0].Location.X + _forX * sizesnake, 0);
            }


        }

        public void eatItself(PictureBox[] snake, int score, Panel panel1, Label labelScore)
        {

            if (score >= 2)
            {

                if (snake[0].Location == snake[2].Location)
                {
                    for (int j = 1; j <= score; j++)
                        panel1.Controls.Remove(snake[j]);
                    score = 0;
                    labelScore.Text = "Score: "+score;
                }
            }
            for (int i = 1; i <= score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for (int j = i; j <= score; j++)
                        panel1.Controls.Remove(snake[j]);
                    score = score - (score - i + 1);
                    labelScore.Text = "Score: " + score;
                }

            }


        }
    }
}
