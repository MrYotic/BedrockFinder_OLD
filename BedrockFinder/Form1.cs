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
        BlockCoord[,,] blockCoordsArray = new BlockCoord[4, 16, 16];
        byte levelIndex = 3;
        string penType = "bedrock";
        public void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                ((Control)sender).Capture = false;
                var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
                WndProc(ref m);
            }
        }

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
            SharePath.SetRoundedShape(panel8, 5, true, true, true, true);
            label8.Location = MiddleLocation.FindMiddle(panel4, label8, true, false);
            panel2.Location = MiddleLocation.FindMiddle(panel4, panel2, true, false);
            label3.Location = MiddleLocation.FindMiddle(panel4, label3, true, false);
            panel3.Location = MiddleLocation.FindMiddle(panel4, panel3, true, false);
            label4.Location = MiddleLocation.FindMiddle(panel4, label4, true, false);
            label5.Location = MiddleLocation.FindMiddle(panel4, label5, true, false);
            this.MouseDown += Controls_MouseDown;
            panel1.MouseDown += Controls_MouseDown;  
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

        private void panel10_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawingGrid();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Point index = new Point((Cursor.Position.X - this.Location.X - panel1.Location.X - panel5.Location.X) / 16, (Cursor.Position.Y - this.Location.Y - panel1.Location.Y - panel5.Location.Y) / 16);
            Graphics g = panel5.CreateGraphics();
            Coordinates coordinates = new Coordinates() { x = index.X, z = index.Y };



            if (blockCoordsArray[levelIndex, index.X, index.Y] != null && blockCoordsArray[levelIndex, index.X, index.Y].block == false)
            {
                if (penType == "bedrock")
                {
                    g.DrawImage(new BlockImage().BlockDrawing(new BlockImage().bedrockColor), new Point(16 * index.X, 16 * index.Y));
                    blockCoordsArray[levelIndex, index.X, index.Y] = new BlockCoord() { block = true, coordinates = coordinates };
                }
                else if (penType == "stone")
                {
                    g.DrawImage(new BlockImage().BlockDrawing(new BlockImage().bedrockColor), new Point(16 * index.X, 16 * index.Y));
                    blockCoordsArray[levelIndex, index.X, index.Y] = new BlockCoord() { block = true, coordinates = coordinates };
                }
            }
            else if (blockCoordsArray[levelIndex, index.X, index.Y] != null && blockCoordsArray[levelIndex, index.X, index.Y].block == true)
            {
                if (penType == "bedrock")
                {
                    blockCoordsArray[levelIndex, index.X, index.Y] = null;
                    g.FillRectangle(new SolidBrush(Color.FromArgb(39, 39, 39)), new Rectangle(16 * index.X, 16 * index.Y, 16, 16));
                    g.DrawRectangle(new Pen(Color.Black), new Rectangle(16 * index.X, 16 * index.Y, 16, 16));
                }
                else if (penType == "stone")
                {
                    g.DrawImage(new BlockImage().BlockDrawing(new BlockImage().stoneColor), new Point(16 * index.X, 16 * index.Y));
                    blockCoordsArray[levelIndex, index.X, index.Y] = new BlockCoord() { block = false, coordinates = coordinates };
                }
            }
            else
            {
                if (penType == "bedrock")
                {
                    g.DrawImage(new BlockImage().BlockDrawing(new BlockImage().bedrockColor), new Point(16 * index.X, 16 * index.Y));
                    blockCoordsArray[levelIndex, index.X, index.Y] = new BlockCoord() { block = true, coordinates = coordinates };
                }
                else if (penType == "stone")
                {
                    g.DrawImage(new BlockImage().BlockDrawing(new BlockImage().stoneColor), new Point(16 * index.X, 16 * index.Y));
                    blockCoordsArray[levelIndex, index.X, index.Y] = new BlockCoord() { block = false, coordinates = coordinates };
                }
            }       
        }

        private void DrawingGrid()
        {
            Graphics g = panel5.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 39, 39, 39)), new Rectangle(0, 0, 256, 256));
            for (int x = 0; x < 16 + 1; x++)
                for (int z = 0; z < 16 + 1; z++)
                    g.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(16 * x, 16 * z, 16, 16));        
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {            
            Graphics graphics = panel6.CreateGraphics();
            graphics.DrawImage(new BlockImage().DrawingPen(new BlockImage().bedrockColor), 0, 0);
        }
        private void panel6_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel6.CreateGraphics();
            if (penType == "bedrock")
            {
                penType = "stone";
                graphics.DrawImage(new BlockImage().DrawingPen(new BlockImage().stoneColor), 0, 0);
            }
            else if (penType == "stone")
            {
                penType = "bedrock";
                graphics.DrawImage(new BlockImage().DrawingPen(new BlockImage().bedrockColor), 0, 0);
            }
        }

        private void panel11_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Click(object sender, EventArgs e)
        {

        }
    }
}
