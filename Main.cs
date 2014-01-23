using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace INFOIBV
{
    public partial class INFOIBV : Form
    {
        private Bitmap inputImage;
        private Bitmap outputImage;
        private int currentStep = 0;
        private int[,] prevData, data;
        private Dictionary<Tuple<int, int>, List<Tuple<int, int>>> groups;

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
                    this.inputImageBox.Image = this.inputImage; // Display input image
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
            this.inputImage.Dispose();
            this.inputImageBox.Image = this.inputImage = this.outputImage;
            this.outputImageBox.Image = this.outputImage = null;

            this.prevData = this.data;

            this.currentStep++;
        }

        private void apply_Click(object sender, EventArgs e)
        {
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
                    this.data = Operations.Convolution(this.prevData, new double[] { 1 }, new double[] { 1 });
                    break;

                case 2:
                    this.data = Operations.WindowSlicing(this.prevData, (int)lowerThresh.Value, (int)upperThresh.Value);
                    break;

                case 3:
                    this.data = Operations.OpeningByReconstruction(this.prevData, new bool[,] { { true, true, true }, { true, true, true }, { true, true, true } });
                    break;

                case 4:
                    this.data = Operations.Mask(this.prevData, Operations.Watershed(this.prevData, shedThresh.Value));
                    break;

                case 5:
                    this.groups = Operations.Groups(this.prevData);
                    this.data = Operations.Label(this.groups, this.prevData.GetLength(0), this.prevData.GetLength(1));
                    break;

                default:
                    break;
            }

            this.outputImageBox.Image = this.outputImage = Operations.CreateImage(this.data);
        }
    }
}
