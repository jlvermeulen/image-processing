using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Color[,] Union(Color[,] one, Color[,] two)
        {
            Color[,] result = new Color[one.GetLength(0), one.GetLength(1)];

            for (int x = 0; x < one.GetLength(0); x++)
                for (int y = 0; y < one.GetLength(1); y++)
                {
                    byte val = Math.Max(one[x, y].R, two[x, y].R);
                    result[x, y] = Color.FromArgb(val, val, val);
                }

            return result;
        }

        public static Color[,] Union(Color[][,] images)
        {
            Color[,] result = new Color[images[0].GetLength(0), images[0].GetLength(1)];

            for (int x = 0; x < images[0].GetLength(0); x++)
                for (int y = 0; y < images[0].GetLength(1); y++)
                {
                    byte val = byte.MinValue;
                    foreach (Color[,] i in images)
                        val = Math.Max(i[x, y].R, val);
                    result[x, y] = Color.FromArgb(val, val, val);
                }

            return result;
        }

        public static Color[,] Mask(Color[,] image, bool[,] mask)
        {
            Color[,] result = new Color[image.GetLength(0), image.GetLength(1)];

            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                    result[x, y] = mask[x, y] ? image[x, y] : Color.Black;

            return result;
        }
    }
}