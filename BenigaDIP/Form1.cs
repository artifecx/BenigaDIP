using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace BenigaDIP
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem selectedManipulateMenuItem, selectedWebcamMenuItem;
        private PictureBox sourcePictureBox;
        private HistogramForm histogramForm;
        private bool isExpanded;
        private Color colorPick;
        private Bitmap imageA, imageB, resultImage;
        private int threshold;
        private VideoCaptureDevice videoSource;

        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
            HidePart2();

            tbThreshold.Text = "100";
            threshold = int.Parse(tbThreshold.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopWebcam();
            base.OnFormClosing(e);
        }

        private void InitializeMenu()
        {
            selectedManipulateMenuItem = menuManipulateOriginal;
            selectedManipulateMenuItem.Checked = true;

            selectedWebcamMenuItem = menuWebcamOff;
            selectedWebcamMenuItem.Checked = true;

            menuManipulateOutput.Click += menuManipulateItem_Click;
            menuManipulateOriginal.Click += menuManipulateItem_Click;

            menuWebcamOn.Click += menuWebcamItem_Click;
            menuWebcamOff.Click += menuWebcamItem_Click;
        }

        private void HidePart2()
        {
            isExpanded = false;
            this.Size = new System.Drawing.Size(845, 510);
            switchMenuWebcamToOff();
            StopWebcam();
            ClearPictureBoxes();

            menuManipulate.Visible = true;
            menuControls.Visible = true;
            menuFileLoad.Visible = true;
            menuWebcam.Visible = false;

            btnPart2.Text = ">>";
            btnPart2.Location = new Point(768, 441);
            
            btnLoadImg.Hide();
            lblColorPicker.Hide();
            btnLoadBg.Hide();
            btnSubtract.Hide();

            pbColor.Hide();
            pbColor.BackColor = Control.DefaultBackColor;
            pbSubtractOutput.Hide();

            lblThreshold.Hide();
            tbThreshold.Hide();
        }

        private void ShowPart2()
        {
            isExpanded = true;
            this.Size = new System.Drawing.Size(1250, 510);
            switchMenuWebcamToOff();
            ClearPictureBoxes();

            menuManipulate.Visible = false;
            menuControls.Visible = false;
            menuFileLoad.Visible = false;
            menuWebcam.Visible = true;

            btnPart2.Text = "<<";
            btnPart2.Location = new Point(1174, 441);

            btnLoadImg.Show();
            lblColorPicker.Show();
            btnLoadBg.Show();
            btnSubtract.Show();

            pbColor.Show();
            pbColor.BackColor = Control.DefaultBackColor;
            pbSubtractOutput.Show();

            lblThreshold.Show();
            tbThreshold.Show();
        }

        private void menuManipulateItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;

            if (selectedManipulateMenuItem != menuItem)
            {
                selectedManipulateMenuItem.Checked = false;
                selectedManipulateMenuItem = menuItem;
            }

            selectedManipulateMenuItem.Checked = true;
        }

        private void menuWebcamItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;

            if (selectedWebcamMenuItem != menuItem)
            {
                selectedWebcamMenuItem.Checked = false;
                selectedWebcamMenuItem = menuItem;
            }

            selectedWebcamMenuItem.Checked = true;

            if (selectedWebcamMenuItem == menuWebcamOn)
            {
                StartWebcam();
            }
            else
            {
                StopWebcam();
            }
        }

        private void switchMenuWebcamToOff()
        {
            menuWebcamOn.Checked = false;
            menuWebcamOff.Checked = true;
        }

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            ClearPictureBoxes();

            if (!isExpanded)
            {
                LoadImage(0);
            }
        }

        private void ClearPictureBoxes()
        {
            pbOriginal.Image = null;
            pbOutput.Image = null;
            pbSubtractOutput.Image = null;
            pbColor.Image = null;
        }

        private void menuFileLoad_Click(object sender, EventArgs e)
        {
            LoadImage(0);
        }

        public void LoadImage(int type)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;

                    if (IsValidImage(selectedFileName))
                    {
                        if (type == 0 || type == 1)
                        {
                            pbOriginal.Image = Image.FromFile(selectedFileName);

                            pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;

                            if(type == 0)
                            {
                                pbOutput.Image = null;
                            }
                            else
                            {
                                imageA = new Bitmap(pbOriginal.Image);
                                pbSubtractOutput.Image = null;
                            }
                        } 
                        else
                        {
                            pbOutput.Image = Image.FromFile(selectedFileName);
                            pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                            imageB = new Bitmap(pbOutput.Image);
                            pbSubtractOutput.Image = null;
                        }

                        if (isExpanded && pbColor.BackColor == Control.DefaultBackColor)
                        {
                            colorPick = Color.FromArgb(0, 255, 0);
                            pbColor.BackColor = colorPick;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid image format. Please select a valid image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidImage(string filePath)
        {
            try
            {
                using (Image img = Image.FromFile(filePath))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            PictureBox sourcePB = isExpanded ? pbSubtractOutput : pbOutput;

            if (sourcePB.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif|All Files|*.*";
                saveFileDialog.Title = "Save Image";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sourcePB.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to save. Please generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuControlsCopy_Click(object sender, EventArgs e)
        {
            SetSourcePictureBox();

            if (sourcePictureBox.Image != null)
            {
                pbOutput.Image = new Bitmap(sourcePictureBox.Image);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("No image to copy. Please load or generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSourcePictureBox()
        {
            if (selectedManipulateMenuItem == menuManipulateOriginal)
            {
                sourcePictureBox = pbOriginal;
            }
            else
            {
                sourcePictureBox = pbOutput;
                pbOriginal.Image = sourcePictureBox.Image;
                pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void menuControlsGreyscale_Click(object sender, EventArgs e)
        {
            SetSourcePictureBox();

            if (sourcePictureBox.Image != null)
            {
                pbOutput.Image = ApplyGreyscaleFilter(sourcePictureBox.Image);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("No image to apply greyscale. Please load or generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ApplyGreyscaleFilter(Image originalImage)
        {
            Bitmap grayscaleImage = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(grayscaleImage))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);

                    g.DrawImage(originalImage, new Rectangle(0, 0, grayscaleImage.Width, grayscaleImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
                }
            }

            return grayscaleImage;
        }

        private void menuControlsInversion_Click(object sender, EventArgs e)
        {
            SetSourcePictureBox();

            if (sourcePictureBox.Image != null)
            {
                pbOutput.Image = ApplyInversionFilter(sourcePictureBox.Image);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("No image to apply inversion. Please load or generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ApplyInversionFilter(Image originalImage)
        {
            Bitmap invertedImage = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(invertedImage))
            {
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                        {
                            new float[] { -1, 0, 0, 0, 0 },
                            new float[] { 0, -1, 0, 0, 0 },
                            new float[] { 0, 0, -1, 0, 0 },
                            new float[] { 0, 0, 0, 1, 0 },
                            new float[] { 1, 1, 1, 0, 1 }
                        });

                    attributes.SetColorMatrix(colorMatrix);

                    g.DrawImage(originalImage, new Rectangle(0, 0, invertedImage.Width, invertedImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
                }
            }

            return invertedImage;
        }

        private void menuControlsHistogram_Click(object sender, EventArgs e)
        {
            SetSourcePictureBox();

            if (sourcePictureBox.Image != null)
            {
                int[] histogram = GenerateHistogram(sourcePictureBox.Image);

                ShowHistogramForm(histogram);
            }
            else
            {
                MessageBox.Show("No image to generate histogram. Please load or generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GenerateHistogram(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            int[] histogram = new int[256];

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int stride = bitmapData.Stride;

                byte[] pixels = new byte[stride * bitmap.Height];

                Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        int index = y * stride + x * 4;

                        int intensity = (int)(pixels[index + 2] * 0.3 + pixels[index + 1] * 0.59 + pixels[index] * 0.11);

                        histogram[intensity]++;
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            return histogram;
        }


        private void ShowHistogramForm(int[] histogram)
        {
            if (histogramForm == null || histogramForm.IsDisposed)
            {
                histogramForm = new HistogramForm();
            }

            histogramForm.DisplayHistogram(histogram);

            histogramForm.Show();
            histogramForm.BringToFront();
        }

        private void menuControlsSepia_Click(object sender, EventArgs e)
        {
            SetSourcePictureBox();

            if (sourcePictureBox.Image != null)
            {
                pbOutput.Image = ApplySepiaTone(sourcePictureBox.Image);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("No image to apply sepia tone. Please load or generate an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ApplySepiaTone(Image originalImage)
        {
            Bitmap sepiaImage = new Bitmap(originalImage.Width, originalImage.Height);

            BitmapData originalData = ((Bitmap)originalImage).LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData sepiaData = sepiaImage.LockBits(new Rectangle(0, 0, sepiaImage.Width, sepiaImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int strideOriginal = originalData.Stride;
            int strideSepia = sepiaData.Stride;

            byte[] originalBytes = new byte[strideOriginal * originalImage.Height];
            byte[] sepiaBytes = new byte[strideSepia * sepiaImage.Height];

            Marshal.Copy(originalData.Scan0, originalBytes, 0, originalBytes.Length);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    int index = y * strideOriginal + x * 4;

                    int pixelB = originalBytes[index];
                    int pixelG = originalBytes[index + 1];
                    int pixelR = originalBytes[index + 2];

                    int sepiaR = (int)(pixelR * 0.393 + pixelG * 0.769 + pixelB * 0.189);
                    int sepiaG = (int)(pixelR * 0.349 + pixelG * 0.686 + pixelB * 0.168);
                    int sepiaB = (int)(pixelR * 0.272 + pixelG * 0.534 + pixelB * 0.131);

                    sepiaR = Clamp(sepiaR, 0, 255);
                    sepiaG = Clamp(sepiaG, 0, 255);
                    sepiaB = Clamp(sepiaB, 0, 255);

                    sepiaBytes[index] = (byte)sepiaB;
                    sepiaBytes[index + 1] = (byte)sepiaG;
                    sepiaBytes[index + 2] = (byte)sepiaR;
                    sepiaBytes[index + 3] = originalBytes[index + 3];
                }
            }

            Marshal.Copy(sepiaBytes, 0, sepiaData.Scan0, sepiaBytes.Length);

            ((Bitmap)originalImage).UnlockBits(originalData);
            sepiaImage.UnlockBits(sepiaData);

            return sepiaImage;
        }

        private int Clamp(int value, int min, int max)
        {
            // Version doesn't have built in Math.Clamp, did this instead
            return Math.Min(Math.Max(value, min), max);
        }

        private void btnPart2_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                HidePart2();
            }
            else
            {
                ShowPart2();
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            LoadImage(1);
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            pbColor = (PictureBox)sender;

            ShowColorPicker();
        }
        private void ShowColorPicker()
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pbColor.BackColor = colorDialog.Color;

                colorPick = pbColor.BackColor;
            }
        }

        private void btnLoadBg_Click(object sender, EventArgs e)
        {
            LoadImage(2);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (imageA != null && imageB != null)
            {
                if (imageA.Width == imageB.Width && imageA.Height == imageB.Height)
                {
                    resultImage = ImageSubtraction(imageA, imageB, colorPick);

                    pbSubtractOutput.Image = resultImage;

                    pbSubtractOutput.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("Images must have the same dimensions for subtraction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please load both the original and background images before subtracting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ImageSubtraction(Bitmap imageA, Bitmap imageB, Color colorToRemove)
        {
            Bitmap result = new Bitmap(imageA.Width, imageA.Height);

            int greycolor = (colorToRemove.R + colorToRemove.G + colorToRemove.B) / 3;

            BitmapData dataA = imageA.LockBits(new Rectangle(0, 0, imageA.Width, imageA.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataB = imageB.LockBits(new Rectangle(0, 0, imageB.Width, imageB.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try
            {
                int strideA = dataA.Stride;
                int strideB = dataB.Stride;
                int strideResult = dataResult.Stride;

                byte[] pixelsA = new byte[strideA * imageA.Height];
                byte[] pixelsB = new byte[strideB * imageB.Height];
                byte[] pixelsResult = new byte[strideResult * result.Height];

                Marshal.Copy(dataA.Scan0, pixelsA, 0, pixelsA.Length);
                Marshal.Copy(dataB.Scan0, pixelsB, 0, pixelsB.Length);

                for (int y = 0; y < imageA.Height; y++)
                {
                    for (int x = 0; x < imageA.Width; x++)
                    {
                        int index = y * strideA + x * 4;

                        int pixelAR = pixelsA[index + 2];
                        int pixelAG = pixelsA[index + 1];
                        int pixelAB = pixelsA[index];

                        int pixelBR = pixelsB[index + 2];
                        int pixelBG = pixelsB[index + 1];
                        int pixelBB = pixelsB[index];

                        bool withinThreshold = Math.Abs(pixelAR - colorToRemove.R) <= threshold &&
                                               Math.Abs(pixelAG - colorToRemove.G) <= threshold &&
                                               Math.Abs(pixelAB - colorToRemove.B) <= threshold;

                        if (withinThreshold)
                        {
                            pixelsResult[index + 2] = (byte)pixelBR;
                            pixelsResult[index + 1] = (byte)pixelBG;
                            pixelsResult[index] = (byte)pixelBB;
                            pixelsResult[index + 3] = 255;
                        }
                        else
                        {
                            pixelsResult[index + 2] = (byte)pixelAR;
                            pixelsResult[index + 1] = (byte)pixelAG;
                            pixelsResult[index] = (byte)pixelAB;
                            pixelsResult[index + 3] = 255;
                        }
                    }
                }

                Marshal.Copy(pixelsResult, 0, dataResult.Scan0, pixelsResult.Length);
            }
            finally
            {
                imageA.UnlockBits(dataA);
                imageB.UnlockBits(dataB);
                result.UnlockBits(dataResult);
            }

            return result;
        }

        private void tbThreshold_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbThreshold.Text))
            {
                if (int.TryParse(tbThreshold.Text, out int value) && value <= 255)
                {
                    threshold = value;
                }
                else
                {
                    MessageBox.Show("Invalid threshold value or value exceeds 255, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbThreshold.Text = "";
                    threshold = 0;
                }
            }
            else
            {
                threshold = 0;
            }
        }

        private void tbThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                if (tbThreshold.SelectionLength > 0)
                {
                    tbThreshold.SelectedText = e.KeyChar.ToString();
                    e.Handled = true;
                }
                e.Handled = true;
            }

            if (int.TryParse(tbThreshold.Text + e.KeyChar, out int value) && value > 255)
            {
                e.Handled = true;
            }
        }

        private void StartWebcam()
        {
            StopWebcam();
            btnLoadImg.Enabled = false;
            btnSubtract.Enabled = false;

            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                using (var deviceDialog = new VideoCaptureDeviceForm())
                {
                    if (deviceDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        videoSource = new VideoCaptureDevice(deviceDialog.VideoDeviceMoniker);
                        videoSource.NewFrame += VideoSource_NewFrame;
                        videoSource.Start();
                    }
                    else
                    {
                        MessageBox.Show("Webcam device selection canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        switchMenuWebcamToOff();
                        btnLoadImg.Enabled = true;
                        btnSubtract.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No video devices found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                switchMenuWebcamToOff();
                btnLoadImg.Enabled = true;
                btnSubtract.Enabled = true;
            }
        }

        private async void StopWebcam()
        {
            btnLoadImg.Enabled = true;
            btnSubtract.Enabled = true;

            if (videoSource != null && videoSource.IsRunning)
            {
                await Task.Run(() =>
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                });

                pbOriginal.Image = null;
            }

            pbSubtractOutput.Image = null;
            pbOutput.Image = null;
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap resizedFrame = (Bitmap)eventArgs.Frame.Clone();
            // Display original frame in pbOriginal
            if (pbOriginal.InvokeRequired)
            {
                pbOriginal.Invoke(new Action(() =>
                {
                    pbOriginal.Image?.Dispose();  // Dispose the previous image to avoid memory leaks
                    pbOriginal.Image = (Bitmap)resizedFrame.Clone();
                    pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
                }));
            }
            else
            {
                pbOriginal.Image?.Dispose();  // Dispose the previous image to avoid memory leaks
                pbOriginal.Image = (Bitmap)resizedFrame.Clone();
                pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (imageB != null)
            {
                if (resizedFrame.Width == imageB.Width && resizedFrame.Height == imageB.Height)
                {
                    // Perform live subtraction
                    resultImage = ImageSubtraction(resizedFrame, imageB, colorPick);

                    // Display the result in pbSubtractionOutput
                    if (pbSubtractOutput.InvokeRequired)
                    {
                        pbSubtractOutput.Invoke(new Action(() =>
                        {
                            pbSubtractOutput.Image?.Dispose();  // Dispose the previous image to avoid memory leaks
                            pbSubtractOutput.Image = (Bitmap)resultImage.Clone();
                            pbSubtractOutput.SizeMode = PictureBoxSizeMode.Zoom;
                        }));
                    }
                    else
                    {
                        pbSubtractOutput.Image?.Dispose();  // Dispose the previous image to avoid memory leaks
                        pbSubtractOutput.Image = (Bitmap)resultImage.Clone();
                        pbSubtractOutput.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    int height = resizedFrame.Height;
                    int width = resizedFrame.Width;
                    MessageBox.Show("Background image must be " + width + "x" + height + " to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    imageB = null;
                    pbOutput.Image = null;
                }
            }
        }
    }
}
