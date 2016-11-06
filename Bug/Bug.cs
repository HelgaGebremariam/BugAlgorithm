using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug
{
    public enum MovingDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Bug
    {
        public MovingDirection BugState { get; set; } = MovingDirection.Down;
        public int BugPositionX { get; set; }
        public int BugPositionY { get; set; }

        public void Move()
        {
            switch (BugState)
            {
                case MovingDirection.Down:
                    BugPositionY ++;
                    break;
                case MovingDirection.Left:
                    BugPositionX --;
                    break;
                case MovingDirection.Right:
                    BugPositionX ++;
                    break;
                case MovingDirection.Up:
                    BugPositionY --;
                    break;
            }
        }

        public void MoveBack()
        {
            switch (BugState)
            {
                case MovingDirection.Down:
                    BugPositionY--;
                    break;
                case MovingDirection.Left:
                    BugPositionX++;
                    break;
                case MovingDirection.Right:
                    BugPositionX--;
                    break;
                case MovingDirection.Up:
                    BugPositionY++;
                    break;
            }
        }

        public void ChangeState()
        {
            switch (BugState)
            {
                case MovingDirection.Down:
                    BugState = MovingDirection.Right;
                    break;
                case MovingDirection.Left:
                    BugState = MovingDirection.Down;
                    break;
                case MovingDirection.Right:
                    BugState = MovingDirection.Up;
                    break;
                case MovingDirection.Up:
                    BugState = MovingDirection.Left;
                    break;
            }
        }
    }
}
