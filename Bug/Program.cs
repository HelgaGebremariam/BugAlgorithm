using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bug
{
    class Program
    {
        static void Main(string[] args)
        {
            BugSpace bugSpace = new BugSpace(new Bitmap("G:\\1.bmp", true));
            bugSpace.MoveBug();
            bugSpace.SaveToBitmap("G://2.bmp");
        }
    }
}
