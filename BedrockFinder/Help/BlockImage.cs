using System.Drawing;

namespace BedrockFinder
{
    internal class BlockImage
    {
        internal Color[] bedrockColor = new Color[4] { Color.FromArgb(151, 151, 151), Color.FromArgb(87, 87, 87), Color.FromArgb(51, 51, 51), Color.FromArgb(7, 7, 7) };
        internal Color[] stoneColor = new Color[4] { Color.FromArgb(143, 143, 143), Color.FromArgb(127, 127, 127), Color.FromArgb(161, 161, 161), Color.FromArgb(106, 106, 106) };

        internal byte[,] signatureBlock = new byte[16, 16]
        {
            { 1, 2, 2, 2, 2, 1, 0, 0, 3, 0, 1, 2, 2, 2, 2, 1},
            { 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 3, 1, 1, 2},
            { 1, 3, 2, 2, 3, 2, 2, 2, 0, 2, 1, 1, 1, 0, 1, 1},
            { 1, 0, 1, 1, 1, 3, 1, 0, 1, 1, 2, 2, 2, 2, 2, 1},
            { 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 3},
            { 2, 2, 1, 1, 1, 2, 2, 2, 1, 3, 1, 1, 2, 2, 3, 1},
            { 0, 0, 1, 1, 1, 2, 0, 0, 1, 1, 1, 1, 0, 0, 0, 3},
            { 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 1, 1},
            { 1, 0, 0, 3, 0, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
            { 1, 2, 2, 2, 2, 2, 2, 1, 3, 1, 1, 2, 2, 2, 0, 1},
            { 1, 1, 0, 2, 2, 0, 0, 2, 3, 2, 0, 0, 0, 0, 0, 0},
            { 3, 1, 1, 1, 2, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 3},
            { 1, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 1},
            { 1, 0, 2, 0, 3, 1, 1, 2, 2, 2, 3, 2, 1, 1, 0, 0},
            { 1, 1, 1, 2, 2 ,2, 2, 2, 1, 1, 0, 0, 1, 2, 2, 1},
            { 2, 2, 2, 2, 3, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1}
        };

        internal Bitmap BlockDrawing(Color[] colors)
        {
            Bitmap bitmap = new Bitmap(16, 16);
            BlockImage block = new BlockImage();
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    switch (block.signatureBlock[y, x])
                    {
                        case 0x0:
                            bitmap.SetPixel(x, y, colors[0]);
                            break;
                        case 0x01:
                            bitmap.SetPixel(x, y, colors[1]);
                            break;
                        case 0x02:
                            bitmap.SetPixel(x, y, colors[2]);
                            break;
                        case 0x03:
                            bitmap.SetPixel(x, y, colors[3]);
                            break;
                    }
                }
            }
            return bitmap;
        }
        internal Bitmap DrawingPen(Color[] colors)
        {
            Bitmap bitmap = new Bitmap(32, 32);
            BlockImage block = new BlockImage();

            for (int x = 0; x < 32; x += 2)
            {
                for (int y = 0; y < 32; y += 2)
                {
                    switch (block.signatureBlock[y / 2, x / 2])
                    {
                        case 0x0:
                            bitmap.SetPixel(x + 1, y, colors[0]);
                            bitmap.SetPixel(x + 1, y + 1, colors[0]);
                            bitmap.SetPixel(x, y + 1, colors[0]);
                            bitmap.SetPixel(x, y, colors[0]);
                            break;
                        case 0x01:
                            bitmap.SetPixel(x + 1, y, colors[1]);
                            bitmap.SetPixel(x + 1, y + 1, colors[1]);
                            bitmap.SetPixel(x, y + 1, colors[1]);
                            bitmap.SetPixel(x, y, colors[1]);
                            break;
                        case 0x02:
                            bitmap.SetPixel(x + 1, y, colors[2]);
                            bitmap.SetPixel(x + 1, y + 1, colors[2]);
                            bitmap.SetPixel(x, y + 1, colors[2]);
                            bitmap.SetPixel(x, y, colors[2]);
                            break;
                        case 0x03:
                            bitmap.SetPixel(x + 1, y, colors[3]);
                            bitmap.SetPixel(x + 1, y + 1, colors[3]);
                            bitmap.SetPixel(x, y + 1, colors[3]);
                            bitmap.SetPixel(x, y, colors[3]);
                            break;
                    }
                }
            }
            return bitmap;
        }
    }
}
