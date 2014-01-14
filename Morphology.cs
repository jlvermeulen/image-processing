using System;
using System.Drawing;

namespace INFOIBV
{
    public static class Morphology
    {
        const int MARKER_COUNT = 2;

        //public static string Perimeter(Color[,] image, int xMarker, int yMarker)
        //{

        //}

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

        public static bool[,] Watershed(Color[,] image)
        {
            bool[,] shed = new bool[image.GetLength(0), image.GetLength(1)];
            int[,] dt = DistanceTransform(image);

            DMaxHeap<Pixel> heap = new DMaxHeap<Pixel>();
            Random random = new Random();
            Pixel[,] pixels = new Pixel[dt.GetLength(0), dt.GetLength(1)];

            //for (int i = 1; i <= MARKER_COUNT; i++)
            //{
            //    int x = random.Next(0, dt.GetLength(0)), y = random.Next(0, dt.GetLength(1));
            //    if (dt[x, y] != 0)
            //    {
            //        i--;
            //        continue;
            //    }
            //    Pixel p = new Pixel(x, y, i, dt[x,y]);
            //    heap.Add(p);
            //    pixels[x, y] = p;
            //}

            {
                Pixel p = new Pixel(160, 180, 1, dt[160, 180]);
                heap.Add(p);
                pixels[160, 180] = p;

                p = new Pixel(340, 285, 2, dt[340, 285]);
                heap.Add(p);
                pixels[340, 285] = p;
            }

            while (heap.Count > 0)
            {
                Pixel p = heap.Extract();
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

                Pixel newPixel;
                if (p.X > 0 && pixels[p.X - 1, p.Y] == null)
                {
                    newPixel = new Pixel(p.X - 1, p.Y, 0, dt[p.X - 1, p.Y]);
                    heap.Add(newPixel);
                    pixels[p.X - 1, p.Y] = newPixel;
                }
                if (p.Y > 0 && pixels[p.X, p.Y - 1] == null)
                {
                    newPixel = new Pixel(p.X, p.Y - 1, 0, dt[p.X, p.Y - 1]);
                    heap.Add(newPixel);
                    pixels[p.X, p.Y - 1] = newPixel;
                }
                if (p.X < pixels.GetLength(0) - 1 && pixels[p.X + 1, p.Y] == null)
                {
                    newPixel = new Pixel(p.X + 1, p.Y, 0, dt[p.X + 1, p.Y]);
                    heap.Add(newPixel);
                    pixels[p.X + 1, p.Y] = newPixel;
                }
                if (p.Y < pixels.GetLength(1) - 1 && pixels[p.X, p.Y + 1] == null)
                {
                    newPixel = new Pixel(p.X, p.Y + 1, 0, dt[p.X, p.Y + 1]);
                    heap.Add(newPixel);
                    pixels[p.X, p.Y + 1] = newPixel;
                }
            }

            for (int x = 0; x < shed.GetLength(0); x++)
                for (int y = 0; y < shed.GetLength(1); y++)
                    shed[x, y] = pixels[x, y].Label != 0;

            return shed;
        }

        private class Pixel : IComparable<Pixel>
        {
            public int X, Y, Label, Value;

            public Pixel(int x, int y, int label, int value) { this.X = x; this.Y = y; this.Label = label; this.Value = value; }

            public int CompareTo(Pixel other) { return this.Value.CompareTo(other.Value); }
        }
    }
}