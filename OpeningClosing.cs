using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Color[,] Opening(Color[,] original, bool[,] structuringElement)
        {
            Color[,] result;
            result = Erosion(original, structuringElement);
            result = Dilation(result, structuringElement);
            return result;
        }

        public static Color[,] Closing(Color[,] original, bool[,] structuringElement)
        {
            Color[,] result;
            result = Dilation(original, structuringElement);
            result = Erosion(result, structuringElement);
            return result;
        }

        public static Color[,] OpeningByReconstruction(Color[,] original, bool[,] structuringElement)
        {
            Color[,] result;
            result = Erosion(original, structuringElement);
            result = Reconstruction(result, original);
            return result;
        }

        public static Color[,] OpeningByReconstruction(Color[,] original, bool[] structuringElementX, bool[] structuringElementY)
        {
            Color[,] result;
            result = Erosion(original, structuringElementX, structuringElementY);
            result = Reconstruction(result, original);
            return result;
        }
    }
}