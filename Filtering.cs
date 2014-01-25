using System;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Dictionary<Tuple<int, int>, List<Tuple<int, int>>> FilterByCompactness(int[,] image, Dictionary<Tuple<int, int>, List<Tuple<int, int>>> objects, double min, double max)
        {
            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> filtered = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();

            foreach (KeyValuePair<Tuple<int, int>, List<Tuple<int, int>>> kvp in objects)
            {
                double comp = Operations.Compactness(image, kvp.Key.Item1, kvp.Key.Item2);

                if (comp >= min && comp <= max)
                    filtered[kvp.Key] = kvp.Value;
            }

            return filtered;
        }

        public static Dictionary<Tuple<int, int>, List<Tuple<int, int>>> FilterByArea(int[,] image, Dictionary<Tuple<int, int>, List<Tuple<int, int>>> objects, int min, int max)
        {
            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> filtered = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();

            foreach (KeyValuePair<Tuple<int, int>, List<Tuple<int, int>>> kvp in objects)
            {
                int area = Operations.Area(Operations.Perimeter(image, kvp.Key.Item1, kvp.Key.Item2));

                if (area >= min && area <= max)
                    filtered[kvp.Key] = kvp.Value;
            }

            return filtered;
        }

        public static Dictionary<Tuple<int, int>, List<Tuple<int, int>>> FilterByConvexity(int[,] image, Dictionary<Tuple<int, int>, List<Tuple<int, int>>> objects, double min, double max)
        {
            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> filtered = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();

            foreach (KeyValuePair<Tuple<int, int>, List<Tuple<int, int>>> kvp in objects)
            {
                double hullArea = Operations.PolygonArea(Operations.ConvexHull(kvp.Value));
                double area = Operations.Area(Operations.Perimeter(image, kvp.Key.Item1, kvp.Key.Item2));
                double ratio = area / hullArea;

                if (ratio >= min && ratio <= max)
                    filtered[kvp.Key] = kvp.Value;
            }

            return filtered;
        }
    }
}