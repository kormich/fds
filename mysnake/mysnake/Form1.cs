using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysnake
{
    public partial class Form1 : Form
    {
        public Label labelScore;
        public int width = 600;
        public int height = 600;
        public int sizesnake = 40;
        public int forX, forY;
        public int rX, rY;
        public int rXX, rYY;
        public PictureBox fruit;
        public PictureBox bomb;
        public PictureBox[] snake = new PictureBox[400];
        int h, m, s;
        Snake snakee = new Snake();
        Fruit fruit1 = new Fruit();
        Bomb bomba = new Bomb();


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {

            InitializeComponent();
            this.Width = width + 60;
            this.Height = height + 120;
            Map map = new Map(this.width, this.height, sizesnake, panel1);


            timer2.Interval = 1000;
            h = 0; m = 0;  s = 0;  

            label1.Text = "00 :";
            label2.Text = "00";
            label3.Text = "00 :";
            timer2.Start();

            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(170, 10);
            this.Controls.Add(labelScore);


            snake[0] = new PictureBox();
            snake[0].Location = new Point(400, 400);
            snake[0].Size = new Size(sizesnake, sizesnake);
            snake[0].BackColor = Color.Green;
            panel1.Controls.Add(snake[0]);


            forX = 1;
            forY = 0;


            timer1.Tick += new EventHandler(update);
            timer1.Interval = 300;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(snakee.Run);


            bomb = new PictureBox();
            bomb.BackColor = Color.Black;
            bomb.Size = new Size(sizesnake, sizesnake);
            bomba.Bomba( width,  sizesnake,  fruit1._rX, fruit1._rY,  fruit1.score, snake, bomb,  panel1);



            fruit = new PictureBox();
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(sizesnake, sizesnake);
            fruit1.Createfruit(snake, fruit, panel1, bomba.rXX, bomba.rYY);


        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (s < 59)
            {
                s++;
                if (s < 10)
                    label2.Text = "0" + s.ToString();
                else
                    label2.Text = s.ToString();
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)
                        label1.Text = "0" + m.ToString() + ":";
                    else
                        label1.Text = m.ToString() + ":";
                    s = 0;
                    label2.Text = "00";

                }
                else
                {
                    m = 0;
                    label1.Text = "00 :";
                }
            }
            if (m==59 && s==59)
            {
                h++;
                if (h < 10)
                    label3.Text = "0" + h.ToString() + ":";
                else
                    label3.Text = h.ToString() + ":";

            }
        }

        public void update(Object myObject, EventArgs eventsArgs)
        {

            snakee.eatItself(snake, fruit1.score, panel1, labelScore);
            fruit1.eatFruit(snake, fruit, panel1, snakee._forX, snakee._forY, rXX, rYY, timer1, labelScore);
            snakee.moveSnake(snake,fruit1.score);
            bomba.TouchBomb(width, sizesnake, fruit1._rX, fruit1._rY, fruit1.score, snake, bomb, panel1, timer1);
        }

      

        //private void Bomb()
        //{

        //    Random a = new Random();
        //    rXX = a.Next(40, width - 40);
        //    int tempII = rXX % sizesnake;
        //    rXX -= tempII;
        //    rYY = a.Next(80, width - 40);
        //    int tempJJ = rYY % sizesnake;
        //    rYY -= tempJJ;
        //    if (rX == rXX && rY == rYY)
        //    {
        //        Bomb();
        //    }
        //    for (int k = 0; k <= score; k++)
        //    {
        //        if (snake[k].Location.X == rXX && snake[k].Location.Y == rYY )
        //        {
        //            Bomb();
        //        }
        //    }
        //    bomb.Location = new Point(rXX, rYY);
        //    this.Controls.Add(bomb);
        //}

        //private void Fruit()
        //{
        //    Random r = new Random();
        //    rX = r.Next(40, width - 40);
        //    int tempI = rX % sizesnake;
        //    rX -= tempI;
        //    rY = r.Next(80, width - 40);
        //    int tempJ = rY % sizesnake;
        //    rY -= tempJ;

        //    for (int i = 0; i <= score; i++)
        //    {
        //        if (snake[i].Location.X == rX && snake[i].Location.Y == rY || rX == rXX && rY== rYY)
        //        {
        //            Fruit();
        //        }
        //    }

        //     fruit.Location = new Point(rX, rY);
        //     this.Controls.Add(fruit);
            
        //}



        //private void eatFruit()
        //{
        //    if (score == 195)
        //    {
        //        timer1.Stop();
        //        Form3 form3 = new Form3();
        //        form3.Show();
        //    }
        //    if (snake[0].Location.X == rX && snake[0].Location.Y == rY)
        //    {
        //        labelScore.Text = "Score: " + ++score;
        //        snake[score] = new PictureBox();
        //        snake[score].Location = new Point(snake[score - 1].Location.X + 40 * forX, snake[score - 1].Location.Y - 40 * forY);
        //        snake[score].Size = new Size(sizesnake, sizesnake);
        //        snake[score].BackColor = Color.Green;
        //        this.Controls.Add(snake[score]);
        //        Fruit();

        //    }
        //    if (snake[0].Location.X == rXX && snake[0].Location.Y == rYY)
        //    {
        //        timer1.Stop();
        //        Form2 form2 = new Form2();
        //        form2.Show();

        //    }
        //    if (score % 5 == 0 && score != p && score > 0 && score <70)
        //    {
        //        p = score;
        //        Bomb();
        //    }
        //    if (score == 70)
        //    {
        //        bomb.Visible=false;
        //        rYY = 0;
        //        rXX = 0;
        //    }
        //}



     

        //private void eatItself()
        //{  
        //    if (score >= 2)
        //    {

        //        if (snake[0].Location == snake[2].Location)
        //        {
        //            for (int j = 1; j <= score; j++)
        //                this.Controls.Remove(snake[j]);
        //            score = 0;
        //            labelScore.Text = "Score: " + score;
        //        }
        //    }
        //    for (int i = 1; i <= score; i++)
        //    {
        //        if (snake[0].Location == snake[i].Location)
        //        {
        //            for (int j = i; j <= score; j++)
        //                this.Controls.Remove(snake[j]);
        //            score = score - (score - i + 1);
        //            labelScore.Text = "Score: " + score;
        //        }

        //    }


        //}


    }
}
