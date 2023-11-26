namespace BenigaImageProcessing1
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
            this.File = new System.Windows.Forms.MenuStrip();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.File.SuspendLayout();
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
            this.pbOutput.Location = new System.Drawing.Point(422, 35);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(400, 400);
            this.pbOutput.TabIndex = 1;
            this.pbOutput.TabStop = false;
            // 
            // File
            // 
            this.File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuManipulate,
            this.menuControls});
            this.File.Location = new System.Drawing.Point(0, 0);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(834, 24);
            this.File.TabIndex = 2;
            this.File.Text = "menuStrip1";
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
            this.menuControlsCopy.Size = new System.Drawing.Size(154, 22);
            this.menuControlsCopy.Text = "Basic Copy";
            this.menuControlsCopy.Click += new System.EventHandler(this.menuControlsCopy_Click);
            // 
            // menuControlsGreyscale
            // 
            this.menuControlsGreyscale.Name = "menuControlsGreyscale";
            this.menuControlsGreyscale.Size = new System.Drawing.Size(154, 22);
            this.menuControlsGreyscale.Text = "Greyscale";
            this.menuControlsGreyscale.Click += new System.EventHandler(this.menuControlsGreyscale_Click);
            // 
            // menuControlsInversion
            // 
            this.menuControlsInversion.Name = "menuControlsInversion";
            this.menuControlsInversion.Size = new System.Drawing.Size(154, 22);
            this.menuControlsInversion.Text = "Color Inversion";
            this.menuControlsInversion.Click += new System.EventHandler(this.menuControlsInversion_Click);
            // 
            // menuControlsHistogram
            // 
            this.menuControlsHistogram.Name = "menuControlsHistogram";
            this.menuControlsHistogram.Size = new System.Drawing.Size(154, 22);
            this.menuControlsHistogram.Text = "Histogram";
            this.menuControlsHistogram.Click += new System.EventHandler(this.menuControlsHistogram_Click);
            // 
            // menuControlsSepia
            // 
            this.menuControlsSepia.Name = "menuControlsSepia";
            this.menuControlsSepia.Size = new System.Drawing.Size(154, 22);
            this.menuControlsSepia.Text = "Sepia";
            this.menuControlsSepia.Click += new System.EventHandler(this.menuControlsSepia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 446);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.pbOriginal);
            this.Controls.Add(this.File);
            this.MainMenuStrip = this.File;
            this.Name = "Form1";
            this.Text = "Beniga Digital Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.File.ResumeLayout(false);
            this.File.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.MenuStrip File;
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
    }
}

