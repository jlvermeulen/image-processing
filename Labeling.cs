using System;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] Label(int[,] image)
        {
            int[,] result = new int[image.GetLength(0), image.GetLength(1)];
            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> labels = Groups(image);

            double step = 200.0 / labels.Count;
            int i = 1;
            foreach (List<Tuple<int, int>> set in labels.Values)
            {
                foreach (Tuple<int, int> p in set)
                    result[p.Item1, p.Item2] = 50 + (int)(i * step);
                i++;
            }

            return result;
        }

        public static int[,] Label(Dictionary<Tuple<int, int>, List<Tuple<int, int>>> labels, int width, int height)
        {
            int[,] result = new int[width, height];

            double step = 200.0 / labels.Count;
            int i = 1;
            foreach (List<Tuple<int, int>> set in labels.Values)
            {
                foreach (Tuple<int, int> p in set)
                    result[p.Item1, p.Item2] = 50 + (int)(i * step);
                i++;
            }

            return result;
        }

        public static Dictionary<Tuple<int, int>, List<Tuple<int, int>>> Groups(int[,] image)
        {
            UnionFind<Tuple<int, int>> unionFind = new UnionFind<Tuple<int, int>>();
            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                {
                    if (image[x, y] == 0)
                        continue;

                    Tuple<int, int> xy = new Tuple<int, int>(x, y);
                    unionFind.Make(xy);
                    if (x > 0)
                        unionFind.Union(xy, new Tuple<int, int>(x - 1, y));
                    if (y > 0)
                        unionFind.Union(xy, new Tuple<int, int>(x, y - 1));
                }

            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> labels = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();

            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                {
                    if (image[x, y] == 0)
                        continue;

                    Tuple<int, int> xy = new Tuple<int, int>(x, y), label = unionFind.Find(xy);
                    List<Tuple<int, int>> list;
                    if (!labels.TryGetValue(label, out list))
                    {
                        list = new List<Tuple<int, int>>();
                        labels[label] = list;
                    }
                    list.Add(xy);
                }

            return labels;
        }
    }
}