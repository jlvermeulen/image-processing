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
    }
}