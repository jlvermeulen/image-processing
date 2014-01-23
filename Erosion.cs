using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] Erosion(int[,] original, bool[,] structuringElement)
        {
            int[,] result = new int[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    int min = int.MaxValue;
                    for (int i = structuringElement.GetLength(0) - 1; i >= 0; i--)
                        for (int j = structuringElement.GetLength(1) - 1; j >= 0; j--)
                        {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - structuringElement.GetLength(0) / 2, original.GetLength(0) - 1), 0);
                            int pxy = Math.Max(Math.Min(y + j - structuringElement.GetLength(1) / 2, original.GetLength(1) - 1), 0);

                            if (structuringElement[i, j])
                                min = Math.Min(min, original[pxx, pxy]);
                        }

                    result[x, y] = min;
                }

            return result;
        }

        public static int[,] Erosion(int[,] original, bool[] structuringElementX, bool[] structuringElementY)
        {
            int[,] pass1 = new int[original.GetLength(0), original.GetLength(1)];
            int[,] pass2 = new int[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    int min = int.MaxValue;
                    for (int i = structuringElementX.Length - 1; i >= 0; i--)
                    {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - structuringElementX.Length / 2, original.GetLength(0) - 1), 0);

                            if (structuringElementX[i])
                                min = Math.Min(min, original[pxx, y]);
                        }

                    pass1[x, y] = min;
                }

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    int min = int.MaxValue;
                    for (int i = structuringElementY.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxy = Math.Max(Math.Min(y + i - structuringElementY.Length / 2, original.GetLength(1) - 1), 0);

                        if (structuringElementY[i])
                            min = Math.Min(min, pass1[x, pxy]);
                    }

                    pass2[x, y] = min;
                }

            return pass2;
        }
    }
}