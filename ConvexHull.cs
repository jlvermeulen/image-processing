using System;
using System.Collections.Generic;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static List<Tuple<int, int>> ConvexHull(IEnumerable<Tuple<int, int>> input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            List<Tuple<int, int>> points = new List<Tuple<int, int>>(input);

            Tuple<int, int> start = new Tuple<int, int>(int.MaxValue, int.MaxValue);
            List<int> indexes = new List<int>();
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Item2 < start.Item2 || points[i].Item2 == start.Item2 && points[i].Item1 < start.Item1)
                {
                    start = points[i];
                    indexes.Clear();
                    indexes.Add(i);
                }
                else if (points[i] == start)
                    indexes.Add(i);
            }
            for (int i = 0; i < indexes.Count; i++)
                points.RemoveAt(indexes[i] - i);

            AngleComparer comp = new AngleComparer(start);
            points.Sort(comp);

            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
            for (int i = 0; i < points.Count; i++)
            {
                while (i < points.Count - 1 && comp.Compare(points[i], points[i + 1]) == 0)
                {
                    if (Distance(points[i], start) - Distance(points[i + 1], start) <= 0)
                        i++;
                    else
                    {
                        Tuple<int, int> t = points[i];
                        points[i] = points[i + 1];
                        points[i + 1] = t;
                        i++;
                    }
                }
                temp.Add(points[i]);
            }
            points = temp;

            if (points.Count < 2)
                return null;

            Stack<Tuple<int, int>> hull = new Stack<Tuple<int, int>>();
            hull.Push(start);
            hull.Push(points[0]);
            hull.Push(points[1]);

            Tuple<int, int> top, belowTop;
            for (int i = 2; i < points.Count; i++)
            {
                top = hull.Pop();
                belowTop = hull.Pop();
                while (!LeftTurn(belowTop, top, points[i]))
                {
                    top = belowTop;
                    belowTop = hull.Pop();
                }
                hull.Push(belowTop);
                hull.Push(top);
                hull.Push(points[i]);
            }

            points.Clear();
            while (hull.Count > 0)
                points.Add(hull.Pop());
            return points;
        }

        public static double PolygonArea(List<Tuple<int, int>> polygon)
        {
            double area = 0;
            for (int i = 0; i < polygon.Count - 1; i++)
                area += polygon[i].Item1 * polygon[i + 1].Item2 - polygon[i + 1].Item1 * polygon[i].Item2;
            return area / 2;
        }

        private static bool LeftTurn(Tuple<int, int> p1, Tuple<int, int> p2, Tuple<int, int> p3) { return Cross(Subtract(p2, p1), Subtract(p3, p1)) < 0; }

        private class AngleComparer : IComparer<Tuple<int, int>>
        {
            Tuple<int, int> origin;

            public AngleComparer(Tuple<int, int> origin) { this.origin = origin; }

            public int Compare(Tuple<int, int> vector1, Tuple<int, int> vector2)
            {
                double c = Cross(Subtract(vector1, this.origin), Subtract(vector2, this.origin));
                if (c < 0)
                    return -1;
                if (c > 0)
                    return 1;
                return 0;
            }
        }

        private static int Cross(Tuple<int, int> vector1, Tuple<int, int> vector2) { return vector1.Item1 * vector2.Item2 - vector2.Item1 * vector1.Item2; }

        private static Tuple<int, int> Subtract(Tuple<int, int> one, Tuple<int, int> two) { return new Tuple<int, int>(one.Item1 - two.Item1, one.Item2 - two.Item2); }

        private static double Distance(Tuple<int, int> one, Tuple<int, int> two) { Tuple<int, int> diff = Subtract(one, two); return Math.Sqrt(diff.Item1 * diff.Item1 + diff.Item2 * diff.Item2); }
    }
}