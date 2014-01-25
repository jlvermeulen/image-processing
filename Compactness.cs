using System.Text;
using System;

namespace INFOIBV
{
    public static partial class Operations
    {
        // builds a 4-neighbour perimeter code for an object
        public static string Perimeter(int[,] image, int x, int y)
        {
            int w = image.GetLength(0) - 1, h = image.GetLength(1) - 1;
            while (image[x, y] != 0 && x > 0) // move to boundary pixel
                x--;
            if (image[x, y] == 0)
                x++;

            bool[] startNeighbours = new bool[] { y > 0 && image[x, y - 1] != 0, x < w && image[x + 1, y] != 0, y < h && image[x, y + 1] != 0, x > 0 && image[x - 1, y] != 0 };

            StringBuilder builder = new StringBuilder();
            int direction = 1, xx = x, yy = y;
            for (int k = 0; k < 4; k++) // annoying fix for when the perimeter passes through the startpoint more then once
            {
                if (!startNeighbours[k] || k != (direction + 3) % 4)
                {
                    direction++;
                    direction %= 4;
                    continue;
                }

                do
                {
                    direction = (direction + 3) % 4; // one step counterclockwise from last direction
                    bool[] mayGoDirection = new bool[] { y > 0 && image[x, y - 1] != 0, x < w && image[x + 1, y] != 0, y < h && image[x, y + 1] != 0, x > 0 && image[x - 1, y] != 0 };
                    for (int i = 0; i < 4; i++)
                    {
                        // check possible directions in clockwise order
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

                    if (xx == x && yy == y)
                        startNeighbours[(direction + 2) % 4] = false; // remove incoming direction
                }
                while (xx != x || yy != y);
            }

            return builder.ToString();
        }

        // calculate area from perimeter code
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

        public static double Compactness(int[,] image, int x, int y)
        {
            string perimeter = Perimeter(image, x, y);
            int area = Area(perimeter);
            return (perimeter.Length * perimeter.Length) / (Math.PI * 4 * area);
        }
    }
}