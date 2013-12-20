using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Color[,] Erosion(Color[,] original, bool[,] structuringElement)
        {
            Color[,] processed = new Color[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    byte min = byte.MaxValue;
                    for (int i = structuringElement.GetLength(0) - 1; i >= 0; i--)
                        for (int j = structuringElement.GetLength(1) - 1; j >= 0; j--)
                        {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - structuringElement.GetLength(0) / 2, original.GetLength(0) - 1), 0);
                            int pxy = Math.Max(Math.Min(y + j - structuringElement.GetLength(1) / 2, original.GetLength(1) - 1), 0);

                            if (structuringElement[i, j])
                                min = Math.Min(min, original[pxx, pxy].R);
                        }

                    processed[x, y] = Color.FromArgb(min, min, min);
                }

            return processed;
        }

        public static Color[,] Erosion(Color[,] original, bool[] structuringElementX, bool[] structuringElementY)
        {
            Color[,] pass1 = new Color[original.GetLength(0), original.GetLength(1)];
            Color[,] pass2 = new Color[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    byte min = byte.MaxValue;
                    for (int i = structuringElementX.Length - 1; i >= 0; i--)
                    {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - structuringElementX.Length / 2, original.GetLength(0) - 1), 0);

                            if (structuringElementX[i])
                                min = Math.Min(min, original[pxx, y].R);
                        }

                    pass1[x, y] = Color.FromArgb(min, min, min);
                }

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    byte min = byte.MaxValue;
                    for (int i = structuringElementX.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxy = Math.Max(Math.Min(y + i - structuringElementX.Length / 2, original.GetLength(0) - 1), 0);

                        if (structuringElementX[i])
                            min = Math.Min(min, original[x, pxy].R);
                    }

                    pass2[x, y] = Color.FromArgb(min, min, min);
                }

            return pass2;
        }
    }
}