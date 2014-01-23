using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        // actually correlation
        public static int[,] Convolution(int[,] original, double[,] kernel)
        {
            int[,] result = new int[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double value = 0;
                    for (int i = kernel.GetLength(0) - 1; i >= 0; i--)
                        for (int j = kernel.GetLength(1) - 1; j >= 0; j--)
                        {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - kernel.GetLength(0) / 2, original.GetLength(0) - 1), 0);
                            int pxy = Math.Max(Math.Min(y + j - kernel.GetLength(1) / 2, original.GetLength(1) - 1), 0);

                            value += kernel[i, j] * original[pxx, pxy];
                        }
                    result[x, y] = (byte)Math.Round(Math.Max(Math.Min(value, 255), 0)); ;
                }

            return result;
        }

        public static int[,] Convolution(int[,] original, double[] kernelX, double[] kernelY)
        {
            int[,] pass1 = new int[original.GetLength(0), original.GetLength(1)];
            int[,] pass2 = new int[original.GetLength(0), original.GetLength(1)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double value = 0;
                    for (int i = kernelX.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxx = Math.Max(Math.Min(x + i - kernelX.Length / 2, original.GetLength(0) - 1), 0);

                        value += kernelX[i] * original[pxx, y];
                    }
                    pass1[x, y] = (byte)Math.Round(Math.Max(Math.Min(value, 255), 0));
                }

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double value = 0;
                    for (int i = kernelX.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxy = Math.Max(Math.Min(y + i - kernelY.Length / 2, original.GetLength(1) - 1), 0);

                        value += kernelY[i] * original[x, pxy];
                    }
                    pass2[x, y] = (byte)Math.Round(Math.Max(Math.Min(value, 255), 0));
                }

            return pass2;
        }
    }
}