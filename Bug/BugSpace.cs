using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bug
{
    public enum CellState
    {
        White,
        Gray,
        Black
    }

    public class BugSpace
    {
        private CellState[][] spaceMatrix;
        Bug bug = new Bug();
        private int spaceLength = 10;
        private int spaceWidth = 10;
        public BugSpace()
        {
            spaceMatrix = new CellState[spaceWidth][];
            for (int i = 0; i < spaceWidth; i++)
            {
                spaceMatrix[i] = new CellState[spaceLength];
            }

            for (int i = 0; i < spaceWidth; i++)
                for (int j = 0; j < spaceLength; j++)
                {
                    if (i > 2 && i < 7 && j > 2 && j < 7)
                    {
                        spaceMatrix[i][j] = CellState.Gray;
                    }
                    else
                    {
                        spaceMatrix[i][j] = CellState.White;
                    }
                }
        }

        public BugSpace(Bitmap bitmap)
        {
            spaceLength = bitmap.Height;
            spaceWidth = bitmap.Width;

            spaceMatrix = new CellState[spaceWidth][];
            for (int i = 0; i < spaceWidth; i++)
            {
                spaceMatrix[i] = new CellState[spaceLength];
            }

            for (int i = 0; i < spaceWidth; i++)
                for (int j = 0; j < spaceLength; j++)
                {
                    if(bitmap.GetPixel(i,j).GetBrightness() < 0.5)
                    {
                        spaceMatrix[i][j] = CellState.Gray;
                    }
                    else
                    {
                        spaceMatrix[i][j] = CellState.White;
                    }
                }
        }

        public void SaveToBitmap(string filename)
        {
            Bitmap bitmap = new Bitmap(spaceWidth, spaceLength);
            for(int i = 0; i < spaceWidth; i++)
                for(int j = 0; j< spaceLength; j++)
                {
                    if (spaceMatrix[i][j] == CellState.Black)
                        bitmap.SetPixel(i, j, Color.Black);
                    if (spaceMatrix[i][j] == CellState.White)
                        bitmap.SetPixel(i, j, Color.White);
                    if (spaceMatrix[i][j] == CellState.Gray)
                        bitmap.SetPixel(i, j, Color.Gray);
                }
            bitmap.Save(filename);
        }

        public void DefineBugStartPosition()
        {
            for (int i = 0; i < spaceWidth; i++)
                for (int j = 0; j < spaceLength; j++)
                {
                    if (spaceMatrix[i][j] == CellState.Gray)
                    {
                        bug.BugPositionX = i;
                        bug.BugPositionY = j;
                        return;
                    }
                }
        }

        public bool IsBugOnBorderPosition()
        {
            if (spaceMatrix[bug.BugPositionX][bug.BugPositionY] == CellState.White)
                return false;


            return false;
        }

        public bool IsBugInTheNotGraySpaceOrNotBorderElement()
        {
            if (bug.BugPositionX >= spaceWidth || bug.BugPositionY >= spaceLength
                || bug.BugPositionX < 0 || bug.BugPositionY < 0)
                return true;
            if (spaceMatrix[bug.BugPositionX][bug.BugPositionY] != CellState.Gray)
                return true;
            if (spaceMatrix[bug.BugPositionX - 1][bug.BugPositionY] == CellState.White ||
                spaceMatrix[bug.BugPositionX][bug.BugPositionY - 1] == CellState.White ||
                spaceMatrix[bug.BugPositionX + 1][bug.BugPositionY] == CellState.White ||
                spaceMatrix[bug.BugPositionX][bug.BugPositionY + 1] == CellState.White ||
                spaceMatrix[bug.BugPositionX+1][bug.BugPositionY + 1] == CellState.White ||
                spaceMatrix[bug.BugPositionX-1][bug.BugPositionY - 1] == CellState.White ||
                spaceMatrix[bug.BugPositionX-1][bug.BugPositionY + 1] == CellState.White ||
                spaceMatrix[bug.BugPositionX+1][bug.BugPositionY - 1] == CellState.White)
                return false;
            return true;
        }

        public void MoveBug()
        {
            DefineBugStartPosition();
            bug.BugState = MovingDirection.Down;
            while (spaceMatrix[bug.BugPositionX][bug.BugPositionY] != CellState.Black)
            {
                spaceMatrix[bug.BugPositionX][bug.BugPositionY] = CellState.Black;
                MovingDirection initialDirection = bug.BugState;
                do
                {
                    bug.Move();
                    if (IsBugInTheNotGraySpaceOrNotBorderElement())
                    {
                        bug.MoveBack();
                        bug.ChangeState();
                    }
                    else
                    {
                        break;
                    }
                } while (bug.BugState != initialDirection);
            }
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < spaceWidth; i++)
            {
                for (int j = 0; j < spaceLength; j++)
                {
                    Console.Write(spaceMatrix[i][j]);
                }
                Console.WriteLine(string.Empty);
            }
        }

    }
}
