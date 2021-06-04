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
        private Control _control;
        private static MoveShake move = MoveShake.Rigth;
        private LinkedList<PictureBox> snakeList = new LinkedList<PictureBox>();
        private Dictionary<MoveShake, Action<PictureBox>> Moving = new Dictionary<MoveShake, Action<PictureBox>>()
        {
            {MoveShake.Down, (head) => { head.Location = new Point(head.Location.X, head.Location.Y + sizesnake); } },
            {MoveShake.Up, (head) => { head.Location = new Point(head.Location.X, head.Location.Y - sizesnake); } },
            {MoveShake.Left, (head) => { head.Location = new Point(head.Location.X - sizesnake, head.Location.Y); } },
            {MoveShake.Rigth, (head) => { head.Location = new Point(head.Location.X + sizesnake, head.Location.Y); } },
        };
        private static MoveShake nextMove = MoveShake.Rigth; 
        private Dictionary<MoveShake, Action> ChangeMoving = new Dictionary<MoveShake, Action>()
        {
            { MoveShake.Rigth, () => { if (move == MoveShake.Left) return; move = MoveShake.Rigth; } },
            { MoveShake.Left, () => { if (move == MoveShake.Rigth) return; move = MoveShake.Left; } },
            { MoveShake.Up, () => { if (move == MoveShake.Down) return; move = MoveShake.Up; } },
            { MoveShake.Down, () => { if (move == MoveShake.Up) return; move = MoveShake.Down; }}
        };
        private Dictionary<Keys, Action> NextMoving = new Dictionary<Keys, Action>()
        {
            { Keys.Right, () => nextMove = MoveShake.Rigth },
            { Keys.Left, () =>  nextMove = MoveShake.Left },
            { Keys.Up, () =>  nextMove = MoveShake.Up },
            { Keys.Down, () => nextMove = MoveShake.Down }
        };
        private bool isEatGruit = false;

        public int Score = 0;
        public PictureBox Head;
        public static int sizesnake = 40;

        public Snake(int x , int y, Control control)    
        {
            _control = control;
            CreateHead(new Point(x, y));
        }

        public void Run(object sender, KeyEventArgs a)
        {
            if (NextMoving.ContainsKey(a.KeyCode))
                NextMoving[a.KeyCode]?.Invoke();
        } 
           

        private PictureBox CreateHead(Point p)
        {
            var head = new PictureBox();
            head.BackColor = Color.Green;
            head.Location = new Point(p.X, p.Y);
            head.Size = new Size(sizesnake, sizesnake);
            _control.Controls.Add(head);
            snakeList.AddLast(head);

            Head = snakeList.Last.Value;
            return head;
        }

        public void moveSnake()
        {
            ChangeMoving[nextMove].Invoke();
            PictureBox head;
            if (isEatGruit)
            {
                head = CreateHead(snakeList.Last.Value.Location);
                isEatGruit = false;
            }
            else
            {
                head = snakeList.First.Value;
                if (snakeList.Count > 1)
                    head.Location = snakeList.Last.Value.Location;
                snakeList.RemoveFirst();
                snakeList.AddLast(head);
                Head = snakeList.Last.Value;
            }           

            Moving[move](head);

            if (IsTouch())
            {
                if (move == MoveShake.Down || move == MoveShake.Up)
                    head.Location = new Point(head.Location.X, Math.Abs(560 - head.Location.Y) - sizesnake);
                else
                    head.Location = new Point(Math.Abs(560 - head.Location.X) - sizesnake, head.Location.Y);
            }
            var deleteCount = 0;
            if (IsTouchWithSelf(out deleteCount))
            {
                Score -= deleteCount;
                for (var i = deleteCount; i > 0; i--)
                {
                    snakeList.First.Value.Dispose();
                    snakeList.RemoveFirst();
                }               
            }                
        }

        private bool IsTouchWithSelf(out int count)
        {
            count = 0;
            foreach (var i in snakeList)
            {
                if (Head.Location == i.Location && Head != i)
                        return true;
                count += 1;                
            }

            return false;
        }

        public void Eat()
        {
            isEatGruit = true;
            Score += 1;
        }

        private bool IsTouch() 
        {
            var headLocation = snakeList.Last.Value.Location;
            return headLocation.X < 0 || headLocation.X > 560
                || headLocation.Y < 0 || headLocation.Y > 560;
        } 

        public enum MoveShake
        {
            Down,
            Up,
            Left,
            Rigth
        }
    }
}
