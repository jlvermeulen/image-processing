using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] Union(int[,] one, int[,] two)
        {
            int[,] result = new int[one.GetLength(0), one.GetLength(1)];

            for (int x = 0; x < one.GetLength(0); x++)
                for (int y = 0; y < one.GetLength(1); y++)
                {
                    int val = Math.Max(one[x, y], two[x, y]);
                    result[x, y] = val;
                }

            return result;
        }

        public static int[,] Union(int[][,] images)
        {
            int[,] result = new int[images[0].GetLength(0), images[0].GetLength(1)];

            for (int x = 0; x < images[0].GetLength(0); x++)
                for (int y = 0; y < images[0].GetLength(1); y++)
                {
                    int val = int.MinValue;
                    foreach (int[,] i in images)
                        val = Math.Max(i[x, y], val);
                    result[x, y] = val;
                }

            return result;
        }

        public static int[,] Mask(int[,] image, bool[,] mask)
        {
            int[,] result = new int[image.GetLength(0), image.GetLength(1)];

            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                    result[x, y] = mask[x, y] ? image[x, y] : 0;

            return result;
        }
    }
}