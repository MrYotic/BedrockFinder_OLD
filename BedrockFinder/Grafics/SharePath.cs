using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BedrockFinder
{
    public class SharePath
    {
        public static void SetRoundedShape(Control control, int radius, bool topLeft, bool topRight, bool bottomLeft, bool bottomRight)
        {
            try
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                if (topRight)
                {
                    path.AddLine(radius, 0, control.Width - radius, 0);
                    path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                }
                else
                    path.AddLine(0, 0, control.Width, 0);
                if (bottomRight)
                {
                    path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                    path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                }
                else
                    path.AddLine(control.Width, 0, control.Width, control.Height);
                if (bottomLeft)
                {
                    path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                    path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                }
                else
                    path.AddLine(control.Width, control.Height, 0, control.Height);
                if (topLeft)
                {
                    path.AddLine(0, control.Height - radius, 0, radius);
                    path.AddArc(0, 0, radius, radius, 180, 90);
                }
                else
                    path.AddLine(0, control.Height, 0, 0);
                control.Region = new System.Drawing.Region(path);
                Console.WriteLine("Элемент " + control.Name + " был прорисован.");
            }
            catch (Exception e) { Console.WriteLine("При прорисовке элемента: " + control.Name + " Произошла ошибка: " + e ); }
        }
    }
}
