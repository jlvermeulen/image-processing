using System;
using System.Drawing;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] DistanceTransform(Color[,] image)
        {
            int[,] dt = new int[image.GetLength(0), image.GetLength(1)];

            for (int y = 0; y < image.GetLength(1); y++)
                for (int x = 0; x < image.GetLength(0); x++)
                {
                    dt[x, y] = (image[x, y].R == 0 ? 0 : int.MaxValue - 2);

                    if (x > 0 && y > 0)
                        dt[x, y] = Math.Min(dt[x - 1, y - 1] + 2, dt[x, y]);
                    if (y > 0)
                    {
                        dt[x, y] = Math.Min(dt[x, y - 1] + 1, dt[x, y]);
                        if (x < image.GetLength(0) - 1)
                            dt[x, y] = Math.Min(dt[x + 1, y - 1] + 2, dt[x, y]);
                    }
                    if (x > 0)
                        dt[x, y] = Math.Min(dt[x - 1, y] + 1, dt[x, y]);
                }

            for (int y = image.GetLength(1) - 1; y >= 0; y--)
                for (int x = image.GetLength(0) - 1; x >= 0; x--)
                {
                    if (x < image.GetLength(0) - 1 && y < image.GetLength(1) - 1)
                        dt[x, y] = Math.Min(dt[x + 1, y + 1] + 2, dt[x, y]);
                    if (y < image.GetLength(1) - 1)
                    {
                        dt[x, y] = Math.Min(dt[x, y + 1] + 1, dt[x, y]);
                        if (x > 0)
                            dt[x, y] = Math.Min(dt[x - 1, y + 1] + 2, dt[x, y]);
                    }
                    if (x < image.GetLength(0) - 1)
                        dt[x, y] = Math.Min(dt[x + 1, y] + 1, dt[x, y]);
                }

            return dt;
        }

        public static List<Tuple<int, int>> GetLocalMaxima(int[,] dt)
        {
            UnionFind<Tuple<int, int>> unionFind = new UnionFind<Tuple<int, int>>();
            for (int x = 0; x < dt.GetLength(0); x++)
                for (int y = 0; y < dt.GetLength(1); y++)
                {
                    if (dt[x, y] == 0)
                        continue;

                    Tuple<int, int> xy = new Tuple<int, int>(x, y);
                    unionFind.Make(xy);
                    if (x > 0)
                        unionFind.Union(xy, new Tuple<int, int>(x - 1, y));
                    if (y > 0)
                        unionFind.Union(xy, new Tuple<int, int>(x, y - 1));
                }

            Dictionary<Tuple<int, int>, List<Tuple<int, int>>> sets = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();

            for (int x = 0; x < dt.GetLength(0); x++)
                for (int y = 0; y < dt.GetLength(1); y++)
                {
                    if (dt[x, y] == 0)
                        continue;

                    Tuple<int, int> xy = new Tuple<int, int>(x, y), set = unionFind.Find(xy);
                    List<Tuple<int, int>> list;
                    if (!sets.TryGetValue(set, out list))
                    {
                        list = new List<Tuple<int, int>>();
                        sets[set] = list;
                    }
                    list.Add(xy);
                }

            List<Tuple<int, int>> maxima = new List<Tuple<int,int>>();
            foreach (List<Tuple<int, int>> set in sets.Values)
            {
                int max = int.MinValue;
                Tuple<int, int> maximum = null;
                foreach (Tuple<int, int> t in set)
                    if (dt[t.Item1, t.Item2] > max)
                    {
                        max = dt[t.Item1, t.Item2];
                        maximum = t;
                    }
                maxima.Add(maximum);
            }

            return maxima;
        }

        public static bool[,] Watershed(Color[,] image, decimal threshold)
        {
            bool[,] shed = new bool[image.GetLength(0), image.GetLength(1)];
            int[,] dt = DistanceTransform(image), dt2 = new int[dt.GetLength(0), dt.GetLength(1)];

            int max = int.MinValue;
            for (int i = 0; i < dt.GetLength(0); i++)
                for (int j = 0; j < dt.GetLength(1); j++)
                    max = Math.Max(max, dt[i, j]);

            DMaxHeap<MPixel> heap = new DMaxHeap<MPixel>();
            MPixel[,] pixels = new MPixel[dt.GetLength(0), dt.GetLength(1)];

            for (int i = 0; i < dt.GetLength(0); i++)
                for (int j = 0; j < dt.GetLength(1); j++)
                    dt2[i, j] = dt[i, j] < threshold * max ? 0 : dt[i, j];

            List<Tuple<int, int>> maxima = GetLocalMaxima(dt2);

            int label = 1;
            foreach (Tuple<int, int> t in maxima)
            {
                MPixel p = new MPixel(t.Item1, t.Item2, label++, dt[t.Item1, t.Item2]);
                heap.Add(p);
                pixels[p.X, p.Y] = p;
            }

            while (heap.Count > 0)
            {
                MPixel p = heap.Extract();
                int[] labels = new int[4];
                if (p.X > 0 && pixels[p.X - 1, p.Y] != null)
                    labels[0] = pixels[p.X - 1, p.Y].Label;
                if (p.Y > 0 && pixels[p.X, p.Y - 1] != null)
                    labels[1] = pixels[p.X, p.Y - 1].Label;
                if (p.X < pixels.GetLength(0) - 1 && pixels[p.X + 1, p.Y] != null)
                    labels[2] = pixels[p.X + 1, p.Y].Label;
                if (p.Y < pixels.GetLength(1) - 1 && pixels[p.X, p.Y + 1] != null)
                    labels[3] = pixels[p.X, p.Y + 1].Label;

                Array.Sort(labels);

                int i = 0;
                while (i < 4 && labels[i] == 0)
                    i++;

                bool same = true;
                for (; i < 3; i++)
                    if (labels[i] != labels[i + 1])
                        same = false;

                if (same && p.Label == 0)
                    p.Label = labels[3];

                MPixel newPixel;
                if (p.X > 0 && pixels[p.X - 1, p.Y] == null)
                {
                    newPixel = new MPixel(p.X - 1, p.Y, 0, dt[p.X - 1, p.Y]);
                    heap.Add(newPixel);
                    pixels[p.X - 1, p.Y] = newPixel;
                }
                if (p.Y > 0 && pixels[p.X, p.Y - 1] == null)
                {
                    newPixel = new MPixel(p.X, p.Y - 1, 0, dt[p.X, p.Y - 1]);
                    heap.Add(newPixel);
                    pixels[p.X, p.Y - 1] = newPixel;
                }
                if (p.X < pixels.GetLength(0) - 1 && pixels[p.X + 1, p.Y] == null)
                {
                    newPixel = new MPixel(p.X + 1, p.Y, 0, dt[p.X + 1, p.Y]);
                    heap.Add(newPixel);
                    pixels[p.X + 1, p.Y] = newPixel;
                }
                if (p.Y < pixels.GetLength(1) - 1 && pixels[p.X, p.Y + 1] == null)
                {
                    newPixel = new MPixel(p.X, p.Y + 1, 0, dt[p.X, p.Y + 1]);
                    heap.Add(newPixel);
                    pixels[p.X, p.Y + 1] = newPixel;
                }
            }

            for (int x = 0; x < shed.GetLength(0); x++)
                for (int y = 0; y < shed.GetLength(1); y++)
                    shed[x, y] = pixels[x, y].Label != 0;

            return shed;
        }

        private class MPixel : IComparable<MPixel>
        {
            public int X, Y, Label, Value;

            public MPixel(int x, int y, int label, int value) { this.X = x; this.Y = y; this.Label = label; this.Value = value; }

            public int CompareTo(MPixel other) { return this.Value.CompareTo(other.Value); }
        }
    }
}