using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace INFOIBV
{
    public partial class INFOIBV : Form
    {
        private Bitmap inputImage;
        private Bitmap outputImage;

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
                    this.pictureBox1.Image = this.inputImage; // Display input image
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (this.inputImage == null) // Get out if no input image
                return;
            if (this.outputImage != null) // Reset output image
                this.outputImage.Dispose();
            this.outputImage = new Bitmap(this.inputImage.Size.Width, this.inputImage.Size.Height); // Create new output image
            Color[,] image = new Color[this.inputImage.Size.Width, this.inputImage.Size.Height]; // Create array to speed-up operations (Bitmap functions are very slow)

            // Setup progress bar
            this.progressBar.Visible = true;
            this.progressBar.Minimum = 1;
            this.progressBar.Maximum = inputImage.Size.Width * inputImage.Size.Height;
            this.progressBar.Value = 1;
            this.progressBar.Step = 1;

            // Copy input Bitmap to array            
            for (int x = 0; x < this.inputImage.Size.Width; x++)
                for (int y = 0; y < this.inputImage.Size.Height; y++)
                    image[x, y] = this.inputImage.GetPixel(x, y); // Set pixel color in array at (x,y)
            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[,] greyValues = Operations.ConvertToGreyscale(image);
            int[,] smoothed = Operations.Convolution(greyValues, SmoothingKernel1D, SmoothingKernel1D);
            int[,] thresh = Operations.WindowSlicing(smoothed, 0, 180);
            int[,] opening = Operations.OpeningByReconstruction(thresh, new bool[,] { { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true } });
            int[,] shed = Operations.Mask(opening, Operations.Watershed(opening, 0.6m));

            sw.Stop();

            this.Text = sw.ElapsedMilliseconds.ToString();
            this.outputImage = Operations.CreateImage(shed);

            this.pictureBox2.Image = this.outputImage; // Display output image
            this.progressBar.Visible = false; // Hide progress bar
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.outputImage == null) // Get out if no output image
                return;
            if (this.saveImageDialog.ShowDialog() == DialogResult.OK) // Save the output image
                this.outputImage.Save(this.saveImageDialog.FileName);
        }

        private static double[] SmoothingKernel1D = new double[] { 1 / 16.0, 4 / 16.0, 6 / 16.0, 4 / 16.0, 1 / 16.0 }; 
    }
}
