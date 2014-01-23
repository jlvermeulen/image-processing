namespace INFOIBV
{
    public static partial class Operations
    {
        public static int[,] WindowSlicing(int[,] image, int lower, int upper)
        {
            int[,] slice = new int[image.GetLength(0), image.GetLength(1)];
            for (int x = 0; x < image.GetLength(0); x++)
                for (int y = 0; y < image.GetLength(1); y++)
                    slice[x, y] = (image[x, y] >= lower && image[x, y] <= upper) ? 255 : 0;
            return slice;
        }
    }
}