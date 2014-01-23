namespace INFOIBV
{
    partial class INFOIBV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageFileName = new System.Windows.Forms.TextBox();
            this.inputImageBox = new System.Windows.Forms.PictureBox();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.outputImageBox = new System.Windows.Forms.PictureBox();
            this.step = new System.Windows.Forms.Button();
            this.skip = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.NumericUpDown();
            this.green = new System.Windows.Forms.NumericUpDown();
            this.blue = new System.Windows.Forms.NumericUpDown();
            this.lowerThresh = new System.Windows.Forms.NumericUpDown();
            this.upperThresh = new System.Windows.Forms.NumericUpDown();
            this.shedThresh = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.inputImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shedThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(12, 12);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(98, 23);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load image...";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "Bitmap files (*.bmp;*.gif;*.jpg;*.png;*.tiff;*.jpeg)|*.bmp;*.gif;*.jpg;*.png;*.ti" +
    "ff;*.jpeg";
            this.openImageDialog.InitialDirectory = "..\\..\\images";
            // 
            // imageFileName
            // 
            this.imageFileName.Location = new System.Drawing.Point(116, 14);
            this.imageFileName.Name = "imageFileName";
            this.imageFileName.ReadOnly = true;
            this.imageFileName.Size = new System.Drawing.Size(316, 20);
            this.imageFileName.TabIndex = 1;
            // 
            // inputImageBox
            // 
            this.inputImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputImageBox.Location = new System.Drawing.Point(13, 45);
            this.inputImageBox.Name = "inputImageBox";
            this.inputImageBox.Size = new System.Drawing.Size(512, 512);
            this.inputImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.inputImageBox.TabIndex = 2;
            this.inputImageBox.TabStop = false;
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "Bitmap file (*.bmp)|*.bmp";
            this.saveImageDialog.InitialDirectory = "..\\..\\images";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(948, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save as BMP...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // outputImageBox
            // 
            this.outputImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputImageBox.Location = new System.Drawing.Point(531, 45);
            this.outputImageBox.Name = "outputImageBox";
            this.outputImageBox.Size = new System.Drawing.Size(512, 512);
            this.outputImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.outputImageBox.TabIndex = 5;
            this.outputImageBox.TabStop = false;
            // 
            // step
            // 
            this.step.Location = new System.Drawing.Point(1050, 521);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(75, 35);
            this.step.TabIndex = 6;
            this.step.Text = "Next step";
            this.step.UseVisualStyleBackColor = true;
            this.step.Click += new System.EventHandler(this.step_Click);
            // 
            // skip
            // 
            this.skip.Location = new System.Drawing.Point(1131, 521);
            this.skip.Name = "skip";
            this.skip.Size = new System.Drawing.Size(75, 35);
            this.skip.TabIndex = 7;
            this.skip.Text = "Apply all";
            this.skip.UseVisualStyleBackColor = true;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(1050, 402);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 35);
            this.apply.TabIndex = 8;
            this.apply.Text = "Apply step";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // red
            // 
            this.red.DecimalPlaces = 4;
            this.red.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.red.Location = new System.Drawing.Point(1050, 65);
            this.red.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(75, 20);
            this.red.TabIndex = 9;
            this.red.Value = new decimal(new int[] {
            2126,
            0,
            0,
            262144});
            // 
            // green
            // 
            this.green.DecimalPlaces = 4;
            this.green.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.green.Location = new System.Drawing.Point(1131, 65);
            this.green.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(75, 20);
            this.green.TabIndex = 10;
            this.green.Value = new decimal(new int[] {
            7152,
            0,
            0,
            262144});
            // 
            // blue
            // 
            this.blue.DecimalPlaces = 4;
            this.blue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.blue.Location = new System.Drawing.Point(1212, 65);
            this.blue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(75, 20);
            this.blue.TabIndex = 11;
            this.blue.Value = new decimal(new int[] {
            722,
            0,
            0,
            262144});
            // 
            // lowerThresh
            // 
            this.lowerThresh.Location = new System.Drawing.Point(1050, 136);
            this.lowerThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.lowerThresh.Name = "lowerThresh";
            this.lowerThresh.Size = new System.Drawing.Size(75, 20);
            this.lowerThresh.TabIndex = 12;
            // 
            // upperThresh
            // 
            this.upperThresh.Location = new System.Drawing.Point(1131, 136);
            this.upperThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upperThresh.Name = "upperThresh";
            this.upperThresh.Size = new System.Drawing.Size(75, 20);
            this.upperThresh.TabIndex = 13;
            this.upperThresh.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // shedThresh
            // 
            this.shedThresh.DecimalPlaces = 2;
            this.shedThresh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.shedThresh.Location = new System.Drawing.Point(1050, 231);
            this.shedThresh.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shedThresh.Name = "shedThresh";
            this.shedThresh.Size = new System.Drawing.Size(75, 20);
            this.shedThresh.TabIndex = 14;
            this.shedThresh.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // INFOIBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 568);
            this.Controls.Add(this.shedThresh);
            this.Controls.Add(this.upperThresh);
            this.Controls.Add(this.lowerThresh);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.skip);
            this.Controls.Add(this.step);
            this.Controls.Add(this.outputImageBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.inputImageBox);
            this.Controls.Add(this.imageFileName);
            this.Controls.Add(this.LoadImageButton);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "INFOIBV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INFOIBV";
            ((System.ComponentModel.ISupportInitialize)(this.inputImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shedThresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.TextBox imageFileName;
        private System.Windows.Forms.PictureBox inputImageBox;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox outputImageBox;
        private System.Windows.Forms.Button step;
        private System.Windows.Forms.Button skip;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.NumericUpDown red;
        private System.Windows.Forms.NumericUpDown green;
        private System.Windows.Forms.NumericUpDown blue;
        private System.Windows.Forms.NumericUpDown lowerThresh;
        private System.Windows.Forms.NumericUpDown upperThresh;
        private System.Windows.Forms.NumericUpDown shedThresh;

    }
}

