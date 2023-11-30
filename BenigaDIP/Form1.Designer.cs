namespace BenigaDIP
{
    partial class Form1
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
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManipulate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManipulateOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManipulateOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControls = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlsGreyscale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlsInversion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlsHistogram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlsSepia = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPart2 = new System.Windows.Forms.Button();
            this.pbSubtractOutput = new System.Windows.Forms.PictureBox();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnLoadBg = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.lblColorPicker = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.menuWebcam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWebcamOn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWebcamOff = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtractOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginal
            // 
            this.pbOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginal.Location = new System.Drawing.Point(12, 35);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(400, 400);
            this.pbOriginal.TabIndex = 0;
            this.pbOriginal.TabStop = false;
            // 
            // pbOutput
            // 
            this.pbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOutput.Location = new System.Drawing.Point(418, 35);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(400, 400);
            this.pbOutput.TabIndex = 1;
            this.pbOutput.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuManipulate,
            this.menuControls,
            this.menuWebcam});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileLoad,
            this.menuFileSave});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(100, 22);
            this.menuFileNew.Text = "New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileLoad
            // 
            this.menuFileLoad.Name = "menuFileLoad";
            this.menuFileLoad.Size = new System.Drawing.Size(100, 22);
            this.menuFileLoad.Text = "Load";
            this.menuFileLoad.Click += new System.EventHandler(this.menuFileLoad_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(100, 22);
            this.menuFileSave.Text = "Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuManipulate
            // 
            this.menuManipulate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManipulateOriginal,
            this.menuManipulateOutput});
            this.menuManipulate.Name = "menuManipulate";
            this.menuManipulate.Size = new System.Drawing.Size(79, 20);
            this.menuManipulate.Text = "Manipulate";
            // 
            // menuManipulateOriginal
            // 
            this.menuManipulateOriginal.Name = "menuManipulateOriginal";
            this.menuManipulateOriginal.Size = new System.Drawing.Size(116, 22);
            this.menuManipulateOriginal.Text = "Original";
            // 
            // menuManipulateOutput
            // 
            this.menuManipulateOutput.Name = "menuManipulateOutput";
            this.menuManipulateOutput.Size = new System.Drawing.Size(116, 22);
            this.menuManipulateOutput.Text = "Output";
            // 
            // menuControls
            // 
            this.menuControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuControlsCopy,
            this.menuControlsGreyscale,
            this.menuControlsInversion,
            this.menuControlsHistogram,
            this.menuControlsSepia});
            this.menuControls.Name = "menuControls";
            this.menuControls.Size = new System.Drawing.Size(64, 20);
            this.menuControls.Text = "Controls";
            // 
            // menuControlsCopy
            // 
            this.menuControlsCopy.Name = "menuControlsCopy";
            this.menuControlsCopy.Size = new System.Drawing.Size(180, 22);
            this.menuControlsCopy.Text = "Basic Copy";
            this.menuControlsCopy.Click += new System.EventHandler(this.menuControlsCopy_Click);
            // 
            // menuControlsGreyscale
            // 
            this.menuControlsGreyscale.Name = "menuControlsGreyscale";
            this.menuControlsGreyscale.Size = new System.Drawing.Size(180, 22);
            this.menuControlsGreyscale.Text = "Greyscale";
            this.menuControlsGreyscale.Click += new System.EventHandler(this.menuControlsGreyscale_Click);
            // 
            // menuControlsInversion
            // 
            this.menuControlsInversion.Name = "menuControlsInversion";
            this.menuControlsInversion.Size = new System.Drawing.Size(180, 22);
            this.menuControlsInversion.Text = "Color Inversion";
            this.menuControlsInversion.Click += new System.EventHandler(this.menuControlsInversion_Click);
            // 
            // menuControlsHistogram
            // 
            this.menuControlsHistogram.Name = "menuControlsHistogram";
            this.menuControlsHistogram.Size = new System.Drawing.Size(180, 22);
            this.menuControlsHistogram.Text = "Histogram";
            this.menuControlsHistogram.Click += new System.EventHandler(this.menuControlsHistogram_Click);
            // 
            // menuControlsSepia
            // 
            this.menuControlsSepia.Name = "menuControlsSepia";
            this.menuControlsSepia.Size = new System.Drawing.Size(180, 22);
            this.menuControlsSepia.Text = "Sepia";
            this.menuControlsSepia.Click += new System.EventHandler(this.menuControlsSepia_Click);
            // 
            // btnPart2
            // 
            this.btnPart2.Location = new System.Drawing.Point(1174, 441);
            this.btnPart2.Name = "btnPart2";
            this.btnPart2.Size = new System.Drawing.Size(50, 23);
            this.btnPart2.TabIndex = 3;
            this.btnPart2.Text = "<<";
            this.btnPart2.UseVisualStyleBackColor = true;
            this.btnPart2.Click += new System.EventHandler(this.btnPart2_Click);
            // 
            // pbSubtractOutput
            // 
            this.pbSubtractOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSubtractOutput.Location = new System.Drawing.Point(824, 35);
            this.pbSubtractOutput.Name = "pbSubtractOutput";
            this.pbSubtractOutput.Size = new System.Drawing.Size(400, 400);
            this.pbSubtractOutput.TabIndex = 4;
            this.pbSubtractOutput.TabStop = false;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(70, 441);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(120, 23);
            this.btnLoadImg.TabIndex = 5;
            this.btnLoadImg.Text = "Load Image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnLoadBg
            // 
            this.btnLoadBg.Location = new System.Drawing.Point(550, 441);
            this.btnLoadBg.Name = "btnLoadBg";
            this.btnLoadBg.Size = new System.Drawing.Size(120, 23);
            this.btnLoadBg.TabIndex = 6;
            this.btnLoadBg.Text = "Load Background";
            this.btnLoadBg.UseVisualStyleBackColor = true;
            this.btnLoadBg.Click += new System.EventHandler(this.btnLoadBg_Click);
            // 
            // pbColor
            // 
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbColor.Location = new System.Drawing.Point(322, 441);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(23, 23);
            this.pbColor.TabIndex = 9;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pbColor_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(905, 441);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(120, 23);
            this.btnSubtract.TabIndex = 10;
            this.btnSubtract.Text = "Subtract";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // lblColorPicker
            // 
            this.lblColorPicker.AutoSize = true;
            this.lblColorPicker.Location = new System.Drawing.Point(200, 446);
            this.lblColorPicker.Name = "lblColorPicker";
            this.lblColorPicker.Size = new System.Drawing.Size(116, 13);
            this.lblColorPicker.TabIndex = 11;
            this.lblColorPicker.Text = "Pick a color to remove:";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(1031, 446);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(93, 13);
            this.lblThreshold.TabIndex = 12;
            this.lblThreshold.Text = "Threshold (0-255):";
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(1121, 443);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(25, 20);
            this.tbThreshold.TabIndex = 13;
            this.tbThreshold.TextChanged += new System.EventHandler(this.tbThreshold_TextChanged);
            this.tbThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbThreshold_KeyPress);
            // 
            // menuWebcam
            // 
            this.menuWebcam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWebcamOn,
            this.menuWebcamOff});
            this.menuWebcam.Name = "menuWebcam";
            this.menuWebcam.Size = new System.Drawing.Size(66, 20);
            this.menuWebcam.Text = "Webcam";
            // 
            // menuWebcamOn
            // 
            this.menuWebcamOn.Name = "menuWebcamOn";
            this.menuWebcamOn.Size = new System.Drawing.Size(180, 22);
            this.menuWebcamOn.Text = "On";
            // 
            // menuWebcamOff
            // 
            this.menuWebcamOff.Name = "menuWebcamOff";
            this.menuWebcamOff.Size = new System.Drawing.Size(180, 22);
            this.menuWebcamOff.Text = "Off";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 471);
            this.Controls.Add(this.tbThreshold);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblColorPicker);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.btnLoadBg);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pbSubtractOutput);
            this.Controls.Add(this.btnPart2);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.pbOriginal);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Beniga Digital Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtractOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileLoad;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuControls;
        private System.Windows.Forms.ToolStripMenuItem menuControlsCopy;
        private System.Windows.Forms.ToolStripMenuItem menuControlsGreyscale;
        private System.Windows.Forms.ToolStripMenuItem menuControlsInversion;
        private System.Windows.Forms.ToolStripMenuItem menuControlsHistogram;
        private System.Windows.Forms.ToolStripMenuItem menuControlsSepia;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuManipulate;
        private System.Windows.Forms.ToolStripMenuItem menuManipulateOriginal;
        private System.Windows.Forms.ToolStripMenuItem menuManipulateOutput;
        private System.Windows.Forms.Button btnPart2;
        private System.Windows.Forms.PictureBox pbSubtractOutput;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnLoadBg;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Label lblColorPicker;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.ToolStripMenuItem menuWebcam;
        private System.Windows.Forms.ToolStripMenuItem menuWebcamOn;
        private System.Windows.Forms.ToolStripMenuItem menuWebcamOff;
    }
}

