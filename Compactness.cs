using System.Text;
using System;

namespace INFOIBV
{
    public static partial class Operations
    {
        public static string Perimeter(bool[,] image, int x, int y)
        {
            int w = image.GetLength(0) - 1, h = image.GetLength(1) - 1;
            while (image[x, y] && x > 0)
                x--;
            if (!image[x, y])
                x++;

            StringBuilder builder = new StringBuilder();
            int direction = 1, xx = x, yy = y;
            do
            {
                direction = (direction + 3) % 4;
                bool[] mayGoDirection = new bool[] { y > 0 && image[x, y - 1], x < w && image[x + 1, y], y < h && image[x, y + 1], x > 0 && image[x - 1, y] };
                for (int i = 0; i < 4; i++)
                {
                    if (mayGoDirection[(direction + i) % 4])
                    {
                        direction = (direction + i) % 4;
                        builder.Append(direction);
                        if (direction == 0)
                            y--;
                        else if (direction == 1)
                            x++;
                        else if (direction == 2)
                            y++;
                        else if (direction == 3)
                            x--;
                        break;
                    }
                }
            }
            while (xx != x || yy != y);

            return builder.ToString();
        }

        public static int Area(string perimeter)
        {
            int area = 0, y = 0;
            for (int i = 0; i < perimeter.Length; i++)
            {
                if (perimeter[i] == '0')
                    y--;
                else if (perimeter[i] == '1')
                    area -= y;
                else if (perimeter[i] == '2')
                    y++;
                else if (perimeter[i] == '3')
                    area += y;
            }
            return area;
        }

        public static double Compactness(bool[,] image, int x, int y)
        {
            string perimeter = Perimeter(image, x, y);
            int area = Area(perimeter);
            return (perimeter.Length * perimeter.Length) / (Math.PI * 4 * area);
        }
    }
}