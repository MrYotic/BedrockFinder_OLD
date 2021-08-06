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

namespace BedrockFinder
{
    public partial class Form1 : Form
    {
        Size paintGrid = new Size();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparencyKey = Color.Lime;
            SharePath.SetRoundedShape(panel1, 10, false, false, true, true);
            SharePath.SetRoundedShape(button2, 10, true, true, false, false);
            SharePath.SetRoundedShape(button1, 5, true, true, false, false);
            SharePath.SetRoundedShape(panel4, 15, true, true, true, true);
            SharePath.SetRoundedShape(panel5, 5, true, true, true, true);
            SharePath.SetRoundedShape(panel7, 5, true, true, true, true);
            SharePath.SetRoundedShape(panel8, 5, true, true, true, true);
            label8.Location = MiddleLocation.FindMiddle(panel4, label8, true, false);
            panel2.Location = MiddleLocation.FindMiddle(panel4, panel2, true, false);
            label3.Location = MiddleLocation.FindMiddle(panel4, label3, true, false);
            panel3.Location = MiddleLocation.FindMiddle(panel4, panel3, true, false);
            label4.Location = MiddleLocation.FindMiddle(panel4, label4, true, false);
            label5.Location = MiddleLocation.FindMiddle(panel4, label5, true, false);
            label12.Location = MiddleLocation.FindMiddle(trackBar6, label12, true, false);
            label13.Location = MiddleLocation.FindMiddle(trackBar5, label13, false, true);
        }

        Config.RectangleCoordinates CRC = new Config.RectangleCoordinates();

        private void button1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            CRC.x = new Point(trackBar1.Value - (trackBar1.Value * 2), trackBar2.Value);
            textBox2.Text = CRC.x.X.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            CRC.x = new Point(trackBar1.Value - (trackBar1.Value * 2), trackBar2.Value);
            textBox3.Text = CRC.x.Y.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            CRC.y = new Point(trackBar4.Value - (trackBar4.Value * 2), trackBar3.Value);
            textBox5.Text = CRC.y.X.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            CRC.y = new Point(trackBar4.Value - (trackBar4.Value * 2), trackBar3.Value);
            textBox4.Text = CRC.y.Y.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "▼")
            {
                button4.Text = "▲";
            }
            else if (button4.Text == "▲")
            {
                button4.Text = "▼";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "▼")
            {
                button5.Text = "▲";
            }
            else if (button5.Text == "▲")
            {
                button5.Text = "▼";
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            GrawingGrid();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            GrawingGrid();
        }

        private void GrawingGrid()
        {
            paintGrid = new Size(trackBar6.Value, trackBar5.Value);
            Graphics g = panel5.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 39, 39, 39)), new Rectangle(0, 0, 256, 256));
            int size = 256 / (paintGrid.Width > paintGrid.Height ? paintGrid.Width : paintGrid.Height);
            for (int x = 0; x < 16 + 1; x++)
            {
                for (int z = 0; z < paintGrid.Height + 1; z++)
                {
                    g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(size * x, size * z, size, size));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
