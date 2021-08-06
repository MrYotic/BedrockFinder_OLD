using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BedrockFinder
{
    class MiddleLocation
    {
        public static Point FindMiddle(Control ownControl, Control memControl, bool x, bool y)
        {
            return new Point(x ? ownControl.Width / 2 - memControl.Width / 2 : memControl.Location.X, y ? ownControl.Height / 2 - memControl.Height / 2 : memControl.Location.Y);
        }
    }
}