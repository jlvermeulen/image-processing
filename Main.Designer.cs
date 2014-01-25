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
            this.minComp = new System.Windows.Forms.NumericUpDown();
            this.maxComp = new System.Windows.Forms.NumericUpDown();
            this.minArea = new System.Windows.Forms.NumericUpDown();
            this.maxArea = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.structType = new System.Windows.Forms.ComboBox();
            this.structSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.inputImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shedThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.structSize)).BeginInit();
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
            this.saveButton.TabIndex = 2;
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
            this.step.Location = new System.Drawing.Point(1049, 522);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(80, 35);
            this.step.TabIndex = 15;
            this.step.Text = "Next step";
            this.step.UseVisualStyleBackColor = true;
            this.step.Click += new System.EventHandler(this.step_Click);
            // 
            // skip
            // 
            this.skip.Location = new System.Drawing.Point(1219, 522);
            this.skip.Name = "skip";
            this.skip.Size = new System.Drawing.Size(80, 35);
            this.skip.TabIndex = 17;
            this.skip.Text = "Apply all";
            this.skip.UseVisualStyleBackColor = true;
            this.skip.Click += new System.EventHandler(this.skip_Click);
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(1134, 522);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(80, 35);
            this.apply.TabIndex = 16;
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
            this.red.Location = new System.Drawing.Point(6, 35);
            this.red.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(75, 20);
            this.red.TabIndex = 3;
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
            this.green.Location = new System.Drawing.Point(87, 35);
            this.green.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(75, 20);
            this.green.TabIndex = 4;
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
            this.blue.Location = new System.Drawing.Point(168, 35);
            this.blue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(75, 20);
            this.blue.TabIndex = 5;
            this.blue.Value = new decimal(new int[] {
            722,
            0,
            0,
            262144});
            // 
            // lowerThresh
            // 
            this.lowerThresh.Location = new System.Drawing.Point(6, 35);
            this.lowerThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.lowerThresh.Name = "lowerThresh";
            this.lowerThresh.Size = new System.Drawing.Size(75, 20);
            this.lowerThresh.TabIndex = 6;
            // 
            // upperThresh
            // 
            this.upperThresh.Location = new System.Drawing.Point(87, 35);
            this.upperThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upperThresh.Name = "upperThresh";
            this.upperThresh.Size = new System.Drawing.Size(75, 20);
            this.upperThresh.TabIndex = 7;
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
            this.shedThresh.Location = new System.Drawing.Point(6, 35);
            this.shedThresh.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shedThresh.Name = "shedThresh";
            this.shedThresh.Size = new System.Drawing.Size(75, 20);
            this.shedThresh.TabIndex = 10;
            this.shedThresh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minComp
            // 
            this.minComp.DecimalPlaces = 2;
            this.minComp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.minComp.Location = new System.Drawing.Point(6, 35);
            this.minComp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minComp.Name = "minComp";
            this.minComp.Size = new System.Drawing.Size(75, 20);
            this.minComp.TabIndex = 11;
            // 
            // maxComp
            // 
            this.maxComp.DecimalPlaces = 2;
            this.maxComp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.maxComp.Location = new System.Drawing.Point(87, 35);
            this.maxComp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxComp.Name = "maxComp";
            this.maxComp.Size = new System.Drawing.Size(75, 20);
            this.maxComp.TabIndex = 12;
            this.maxComp.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // minArea
            // 
            this.minArea.Location = new System.Drawing.Point(6, 35);
            this.minArea.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minArea.Name = "minArea";
            this.minArea.Size = new System.Drawing.Size(75, 20);
            this.minArea.TabIndex = 13;
            // 
            // maxArea
            // 
            this.maxArea.Location = new System.Drawing.Point(87, 35);
            this.maxArea.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.maxArea.Name = "maxArea";
            this.maxArea.Size = new System.Drawing.Size(75, 20);
            this.maxArea.TabIndex = 14;
            this.maxArea.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.red);
            this.groupBox1.Controls.Add(this.green);
            this.groupBox1.Controls.Add(this.blue);
            this.groupBox1.Location = new System.Drawing.Point(1049, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 68);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grayscale conversion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Green weight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Blue weight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Red weight";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lowerThresh);
            this.groupBox2.Controls.Add(this.upperThresh);
            this.groupBox2.Location = new System.Drawing.Point(1049, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 68);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Window slicing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Min";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.shedThresh);
            this.groupBox3.Location = new System.Drawing.Point(1049, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 68);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Watershed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "DT Threshold";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.minComp);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.maxComp);
            this.groupBox4.Location = new System.Drawing.Point(1049, 341);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 68);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Compactness filter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Min";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.minArea);
            this.groupBox5.Controls.Add(this.maxArea);
            this.groupBox5.Location = new System.Drawing.Point(1049, 415);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 68);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Area filter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Max";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Min";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.structType);
            this.groupBox6.Controls.Add(this.structSize);
            this.groupBox6.Location = new System.Drawing.Point(1049, 193);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(250, 68);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Opening by reconstruction";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Size";
            // 
            // structType
            // 
            this.structType.FormattingEnabled = true;
            this.structType.Items.AddRange(new object[] {
            "Circle",
            "Cross",
            "Plus",
            "Square"});
            this.structType.Location = new System.Drawing.Point(87, 35);
            this.structType.Name = "structType";
            this.structType.Size = new System.Drawing.Size(75, 21);
            this.structType.TabIndex = 9;
            this.structType.Text = "Square";
            // 
            // structSize
            // 
            this.structSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.structSize.Location = new System.Drawing.Point(6, 35);
            this.structSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.structSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.structSize.Name = "structSize";
            this.structSize.Size = new System.Drawing.Size(75, 20);
            this.structSize.TabIndex = 8;
            this.structSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // INFOIBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 571);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.minComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.structSize)).EndInit();
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
        private System.Windows.Forms.NumericUpDown minComp;
        private System.Windows.Forms.NumericUpDown maxComp;
        private System.Windows.Forms.NumericUpDown minArea;
        private System.Windows.Forms.NumericUpDown maxArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox structType;
        private System.Windows.Forms.NumericUpDown structSize;

    }
}

