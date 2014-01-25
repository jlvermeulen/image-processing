using System;
using System.Drawing;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        // geodesic dilation from markers
        public static int[,] Reconstruction(int[,] markers, int[,] mask)
        {
            int[,] result = new int[markers.GetLength(0), markers.GetLength(1)];

            DMaxHeap<Pixel> heap = new DMaxHeap<Pixel>(5);

            // add markers to heap
            for (int x = 0; x < markers.GetLength(0); x++)
                for (int y = 0; y < markers.GetLength(1); y++)
                {
                    if (markers[x, y] > 0 && mask[x, y] > 0)
                    {
                        Pixel p = new Pixel(x, y, Math.Min(markers[x, y], mask[x, y]));
                        heap.Add(p);
                    }
                    result[x, y] = 0;
                }

            // process heap in order of value
            while (heap.Count > 0)
            {
                Pixel p = heap.Extract();
                if (p.Value <= result[p.X, p.Y]) // not a higher value than already determined
                    continue;
                result[p.X, p.Y] = p.Value;

                // add neighbours
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                    {
                        int pxx = p.X + i, pxy = p.Y + j;

                        if (pxx < 0 || pxx >= markers.GetLength(0) || pxy < 0 || pxy >= markers.GetLength(1)) // no pixel
                            continue;

                        int val = Math.Min(mask[pxx, pxy], p.Value);
                        if (val == result[pxx, pxy]) // no loops of pixels adding each other
                            continue;

                        heap.Add(new Pixel(pxx, pxy, val));
                    }
            }

            return result;
        }

        private struct Pixel : IComparable<Pixel>
        {
            public int X, Y;
            public int Value;

            public Pixel(int x, int y, int value) { this.X = x; this.Y = y; this.Value = value; }

            public int CompareTo(Pixel other) { return this.Value.CompareTo(other.Value); }
        }
    }
}