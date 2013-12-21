using System;
using System.Drawing;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static Color[,] Reconstruction(Color[,] markers, Color[,] mask)
        {
            Color[,] processed = new Color[markers.GetLength(0), markers.GetLength(1)];

            DMaxHeap<Pixel> heap = new DMaxHeap<Pixel>(5);

            for (int x = 0; x < markers.GetLength(0); x++)
                for (int y = 0; y < markers.GetLength(0); y++)
                {
                    if (markers[x, y].R > 0 && mask[x, y].R > 0)
                    {
                        Pixel p = new Pixel(x, y, Math.Min(markers[x, y].R, mask[x, y].R));
                        heap.Add(p);
                    }
                    processed[x, y] = Color.Black;
                }

            while (heap.Count > 0)
            {
                Pixel p = heap.Extract();
                if (p.Value <= processed[p.X, p.Y].R)
                    continue;
                processed[p.X, p.Y] = Color.FromArgb(p.Value, p.Value, p.Value);

                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                    {
                        int pxx = p.X + i, pxy = p.Y + j;

                        if (pxx < 0 || pxx >= markers.GetLength(0) || pxy < 0 || pxy >= markers.GetLength(1))
                            continue;

                        byte val = Math.Min(mask[pxx, pxy].R, p.Value);
                        if (val == processed[pxx, pxy].R)
                            continue;

                        heap.Add(new Pixel(pxx, pxy, val));
                    }
            }

            return processed;
        }

        private struct Pixel : IComparable<Pixel>
        {
            public int X, Y;
            public byte Value;

            public Pixel(int x, int y, byte value) { this.X = x; this.Y = y; this.Value = value; }

            public int CompareTo(Pixel other) { return this.Value.CompareTo(other.Value); }
        }
    }
}