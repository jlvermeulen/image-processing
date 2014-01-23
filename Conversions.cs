using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] ConvertToGreyscale(Color[,] colors, decimal redWeight, decimal greenWeight, decimal blueWeight)
        {
            int[,] grey = new int[colors.GetLength(0), colors.GetLength(1)];
            for (int x = 0; x < colors.GetLength(0); x++)
                for (int y = 0; y < colors.GetLength(1); y++)
                    grey[x, y] = (int)(redWeight * colors[x, y].R + greenWeight * colors[x, y].G + blueWeight * colors[x, y].B);
            return grey;
        }

        public static Bitmap CreateImage(Color[,] values)
        {
            Bitmap result = new Bitmap(values.GetLength(0), values.GetLength(1));

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    result.SetPixel(x, y, values[x, y]);

            return result;
        }

        public static Bitmap CreateImage(int[,] values)
        {
            Bitmap result = new Bitmap(values.GetLength(0), values.GetLength(1));

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                {
                    byte value = (byte)values[x, y];
                    result.SetPixel(x, y, Color.FromArgb(value, value, value));
                }

            return result;
        }

        public static Bitmap CreateImage(bool[,] values)
        {
            Bitmap result = new Bitmap(values.GetLength(0), values.GetLength(1));

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    result.SetPixel(x, y, values[x, y] ? Color.White : Color.Black);

            return result;
        }
    }
}