using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        // actually correlation
        public static Color[,] Convolution(Color[,] original, double[,] kernel)
        {
            Color[,] result = new Color[original.GetLength(0), original.GetLength(0)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double[] value = new double[3];
                    for (int i = kernel.GetLength(0) - 1; i >= 0; i--)
                        for (int j = kernel.GetLength(1) - 1; j >= 0; j--)
                        {
                            // current pixel, extrapolate if necessary
                            int pxx = Math.Max(Math.Min(x + i - kernel.GetLength(0) / 2, original.GetLength(0) - 1), 0);
                            int pxy = Math.Max(Math.Min(y + j - kernel.GetLength(1) / 2, original.GetLength(1) - 1), 0);

                            value[0] += kernel[i, j] * original[pxx, pxy].R;
                            value[1] += kernel[i, j] * original[pxx, pxy].G;
                            value[2] += kernel[i, j] * original[pxx, pxy].B;
                        }
                    for (int i = 0; i < value.Length; i++)
                        value[i] = Math.Max(Math.Min(value[i], 255), 0);

                    result[x, y] = Color.FromArgb((byte)Math.Round(value[0]), (byte)Math.Round(value[1]), (byte)Math.Round(value[2]));
                }

            return result;
        }

        public static Color[,] Convolution(Color[,] original, double[] kernelX, double[] kernelY)
        {
            Color[,] pass1 = new Color[original.GetLength(0), original.GetLength(0)];
            Color[,] pass2 = new Color[original.GetLength(0), original.GetLength(0)];

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double[] value = new double[3];
                    for (int i = kernelX.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxx = Math.Max(Math.Min(x + i - kernelX.Length / 2, original.GetLength(0) - 1), 0);

                        value[0] += kernelX[i] * original[pxx, y].R;
                        value[1] += kernelX[i] * original[pxx, y].G;
                        value[2] += kernelX[i] * original[pxx, y].B;
                    }
                    for (int i = 0; i < value.Length; i++)
                        value[i] = Math.Max(Math.Min(value[i], 255), 0);

                    pass1[x, y] = Color.FromArgb((byte)Math.Round(value[0]), (byte)Math.Round(value[1]), (byte)Math.Round(value[2]));
                }

            for (int x = 0; x < original.GetLength(0); x++)
                for (int y = 0; y < original.GetLength(1); y++)
                {
                    double[] value = new double[3];
                    for (int i = kernelX.Length - 1; i >= 0; i--)
                    {
                        // current pixel, extrapolate if necessary
                        int pxy = Math.Max(Math.Min(y + i - kernelY.Length / 2, original.GetLength(1) - 1), 0);

                        value[0] += kernelX[i] * pass1[x, pxy].R;
                        value[1] += kernelX[i] * pass1[x, pxy].G;
                        value[2] += kernelX[i] * pass1[x, pxy].B;
                    }
                    for (int i = 0; i < value.Length; i++)
                        value[i] = Math.Max(Math.Min(value[i], 255), 0);

                    pass2[x, y] = Color.FromArgb((byte)Math.Round(value[0]), (byte)Math.Round(value[1]), (byte)Math.Round(value[2]));
                }

            return pass2;
        }
    }
}