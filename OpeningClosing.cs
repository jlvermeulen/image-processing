using System;
using System.Drawing;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Color[,] Opening(Color[,] original, bool[,] structuringElement)
        {
            Color[,] processed;
            processed = Erosion(original, structuringElement);
            processed = Dilation(processed, structuringElement);
            return processed;
        }

        public static Color[,] Closing(Color[,] original, bool[,] structuringElement)
        {
            Color[,] processed;
            processed = Dilation(original, structuringElement);
            processed = Erosion(processed, structuringElement);
            return processed;
        }
    }
}