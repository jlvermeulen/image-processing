using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] ConvertToGreyscale(Color[,] colors)
        {
            int[,] grey = new int[colors.GetLength(0), colors.GetLength(1)];
            for (int x = 0; x < colors.GetLength(0); x++)
                for (int y = 0; y < colors.GetLength(1); y++)
                    grey[x, y] = (int)(0.2126 * colors[x, y].R + 0.7152 * colors[x, y].G + 0.0722 * colors[x, y].B);
            return grey;
        }
    }
}