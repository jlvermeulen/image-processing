using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] Opening(int[,] original, bool[,] structuringElement)
        {
            int[,] result;
            result = Erosion(original, structuringElement);
            result = Dilation(result, structuringElement);
            return result;
        }

        public static int[,] Closing(int[,] original, bool[,] structuringElement)
        {
            int[,] result;
            result = Dilation(original, structuringElement);
            result = Erosion(result, structuringElement);
            return result;
        }

        public static int[,] OpeningByReconstruction(int[,] original, bool[,] structuringElement)
        {
            int[,] result;
            result = Erosion(original, structuringElement);
            result = Reconstruction(result, original);
            return result;
        }

        public static int[,] OpeningByReconstruction(int[,] original, bool[] structuringElementX, bool[] structuringElementY)
        {
            int[,] result;
            result = Erosion(original, structuringElementX, structuringElementY);
            result = Reconstruction(result, original);
            return result;
        }
    }
}