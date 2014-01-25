using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace INFOIBV
{
    public partial class INFOIBV : Form
    {
        const int STEPS = 7;

        private Bitmap inputImage;
        private Bitmap outputImage;
        private int currentStep = 0, inputStep = 0;
        private int[,] prevData, data;
        private Dictionary<Tuple<int, int>, List<Tuple<int, int>>> groups, filtered;
        private bool applied = false;

        public INFOIBV()
        {
            InitializeComponent();
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
           if (openImageDialog.ShowDialog() == DialogResult.OK) // Open File Dialog
            {
                string file = openImageDialog.FileName; // Get the file name
                this.imageFileName.Text = file; // Show file name
                if (this.inputImage != null)
                    this.inputImage.Dispose(); // Reset image
                this.inputImage = new Bitmap(file); // Create new Bitmap from file
                if (this.inputImage.Size.Height <= 0 || this.inputImage.Size.Width <= 0 ||
                    this.inputImage.Size.Height > 512 || this.inputImage.Size.Width > 512) // Dimension check
                    MessageBox.Show("Error in image dimensions (have to be > 0 and <= 512)");
                else
                {
                    this.inputImageBox.Image = this.inputImage; // Display input image
                    this.currentStep = this.inputStep = 0;
                    this.prevData = this.data = null;
                    this.groups = this.filtered = null;
                    this.outputImage = null;
                    this.outputImageBox.Image = null;
                    this.applied = false;
                }
            }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.outputImage == null) // Get out if no output image
                return;
            if (this.saveImageDialog.ShowDialog() == DialogResult.OK) // Save the output image
                this.outputImage.Save(this.saveImageDialog.FileName);
        }

        private void step_Click(object sender, EventArgs e)
        {
            if (currentStep >= STEPS || this.inputImage == null)
                return;

            if (!this.applied)
                this.apply.PerformClick();

            this.inputImage.Dispose();
            this.inputImageBox.Image = this.inputImage = this.outputImage;
            this.outputImageBox.Image = this.outputImage = null;

            this.prevData = this.data;
            this.groups = this.filtered;

            this.inputStep++;
            this.currentStep++;

            this.applied = false;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            if (this.inputImage == null)
                return;

            switch (currentStep)
            {
                case 0:
                    Color[,] image = new Color[this.inputImage.Size.Width, this.inputImage.Size.Height]; // Create array to speed up operations (Bitmap functions are very slow)
                    // Copy input Bitmap to array            
                    for (int x = 0; x < this.inputImage.Size.Width; x++)
                        for (int y = 0; y < this.inputImage.Size.Height; y++)
                            image[x, y] = this.inputImage.GetPixel(x, y); // Set pixel color in array at (x,y)

                    this.data = Operations.ConvertToGreyscale(image, red.Value, green.Value, blue.Value);
                    break;

                case 1:
                    this.data = Operations.WindowSlicing(this.prevData, (int)lowerThresh.Value, (int)upperThresh.Value);
                    break;

                case 2:
                    bool[,] structElem = this.MakeStructuringElement((int)structSize.Value, structType.Text);
                    this.data = Operations.OpeningByReconstruction(this.prevData, structElem);
                    this.data = Operations.Invert(this.data);
                    this.data = Operations.OpeningByReconstruction(this.data, structElem);
                    this.data = Operations.Invert(this.data);
                    break;

                case 3:
                    this.data = Operations.Mask(this.prevData, Operations.Watershed(this.prevData, shedThresh.Value));
                    break;

                case 4:
                    this.groups = this.filtered = Operations.Groups(this.prevData);
                    this.data = Operations.Label(this.groups, this.prevData.GetLength(0), this.prevData.GetLength(1));
                    break;

                case 5:
                    this.filtered = Operations.FilterByCompactness(this.prevData, this.groups, (double)minComp.Value, (double)maxComp.Value);
                    this.data = Operations.Label(this.filtered, this.prevData.GetLength(0), this.prevData.GetLength(1));
                    break;

                case 6:
                    this.filtered = Operations.FilterByArea(this.prevData, this.groups, (int)minArea.Value, (int)maxArea.Value);
                    this.data = Operations.Label(this.filtered, this.prevData.GetLength(0), this.prevData.GetLength(1));
                    break;

                case 7:
                    this.filtered = Operations.FilterByConvexity(this.prevData, this.groups, (double)minConv.Value, (double)maxConv.Value);
                    this.data = Operations.Label(this.filtered, this.prevData.GetLength(0), this.prevData.GetLength(1));
                    break;

                default:
                    break;
            }

            this.outputImageBox.Image = this.outputImage = Operations.CreateImage(this.data);
            this.applied = true;
        }

        private void skip_Click(object sender, EventArgs e)
        {
            if (this.inputImage == null)
                return;

            do
            {
                this.apply.PerformClick();
                this.prevData = this.data;
                this.groups = this.filtered;
            }
            while (currentStep++ < STEPS);

            this.currentStep = this.inputStep;
            this.applied = false;
        }

        private bool[,] MakeStructuringElement(int size, string type)
        {
            bool[,] elem = new bool[size, size];
            int half = size / 2;

            switch (type)
            {
                case "Circle":
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            if (Math.Sqrt((i - half) * (i - half) + (j - half) * (j - half)) <= half)
                                elem[i, j] = true;
                    break;

                case "Cross":
                    for (int i = 0; i < size; i++)
                        elem[i, i] = elem[size - i - 1, i] = true;
                    break;

                case "Plus":
                    for (int i = 0; i < size; i++)
                        elem[i, half] = elem[half, i] = true;
                    break;

                case "Square":
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            elem[i, j] = true;
                    break;

                default:
                    break;
            }

            return elem;
        }
    }
}
