using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace INFOIBV
{
    public partial class INFOIBV : Form
    {
        private Bitmap InputImage;
        private Bitmap OutputImage;

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
                if (this.InputImage != null)
                    this.InputImage.Dispose(); // Reset image
                this.InputImage = new Bitmap(file); // Create new Bitmap from file
                if (this.InputImage.Size.Height <= 0 || this.InputImage.Size.Width <= 0 ||
                    this.InputImage.Size.Height > 512 || this.InputImage.Size.Width > 512) // Dimension check
                    MessageBox.Show("Error in image dimensions (have to be > 0 and <= 512)");
                else
                    this.pictureBox1.Image = this.InputImage; // Display input image
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (this.InputImage == null) // Get out if no input image
                return;
            if (this.OutputImage != null) // Reset output image
                this.OutputImage.Dispose();
            this.OutputImage = new Bitmap(this.InputImage.Size.Width, this.InputImage.Size.Height); // Create new output image
            Color[,] Image = new Color[this.InputImage.Size.Width, this.InputImage.Size.Height]; // Create array to speed-up operations (Bitmap functions are very slow)

            // Setup progress bar
            this.progressBar.Visible = true;
            this.progressBar.Minimum = 1;
            this.progressBar.Maximum = InputImage.Size.Width * InputImage.Size.Height;
            this.progressBar.Value = 1;
            this.progressBar.Step = 1;

            // Copy input Bitmap to array            
            for (int x = 0; x < this.InputImage.Size.Width; x++)
            {
                for (int y = 0; y < this.InputImage.Size.Height; y++)
                {
                    Image[x, y] = this.InputImage.GetPixel(x, y); // Set pixel color in array at (x,y)
                }
            }

            //==========================================================================================
            // TODO: include here your own code
            // example: create a negative image
            //for (int x = 0; x < this.InputImage.Size.Width; x++)
            //{
            //    for (int y = 0; y < this.InputImage.Size.Height; y++)
            //    {
            //        Color pixelColor = Image[x, y]; // Get the pixel color at coordinate (x,y)
            //        Color updatedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B); // Negative image
            //        Image[x, y] = updatedColor; // Set the new pixel color at coordinate (x,y)
            //        this.progressBar.PerformStep(); // Increment progress bar
            //    }
            //}

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Color[,] marker = new Color[512, 512];
            marker[0, 0] = Color.White;
            Color[,] processed = Operations.Reconstruction(marker, Image);
            Image = processed;
            sw.Stop();
            this.Text = sw.ElapsedMilliseconds.ToString();

            //==========================================================================================

            // Copy array to output Bitmap
            for (int x = 0; x < this.InputImage.Size.Width; x++)
            {
                for (int y = 0; y < this.InputImage.Size.Height; y++)
                {
                    this.OutputImage.SetPixel(x, y, Image[x, y]); // Set the pixel color at coordinate (x,y)
                }
            }

            this.pictureBox2.Image = this.OutputImage; // Display output image
            this.progressBar.Visible = false; // Hide progress bar
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.OutputImage == null) // Get out if no output image
                return;
            if (this.saveImageDialog.ShowDialog() == DialogResult.OK) // Save the output image
                this.OutputImage.Save(this.saveImageDialog.FileName);
        }

        private static double[,] SmoothingKernel2D = new double[,] { { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 } };
        private static double[] SmoothingKernel1D = new double[] { 1 / 5.0, 1 / 5.0, 1 / 5.0, 1 / 5.0, 1 / 5.0 };
        private static double[,] SharpenKernel2D = new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }; 
    }
}
