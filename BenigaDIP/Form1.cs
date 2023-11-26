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

namespace BenigaImageProcessing1
{
    public partial class Form1 : Form
    {
        private ToolStripMenuItem selectedManipulateMenuItem;
        private PictureBox sourcePictureBox;
        private HistogramForm histogramForm;

        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // Initialize controls to set the selected picturebox to be manipulated by the operations
            // Default is to manipulate loaded image
            selectedManipulateMenuItem = menuManipulateOriginal;
            selectedManipulateMenuItem.Checked = true;

            menuManipulateOutput.Click += menuManipulateItem_Click;
            menuManipulateOriginal.Click += menuManipulateItem_Click;
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

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            pbOriginal.Image = null;
            pbOutput.Image = null;

            LoadImage();
        }

        private void menuFileLoad_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        public void LoadImage()
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
                        // Load the image into the PictureBox
                        pbOriginal.Image = Image.FromFile(selectedFileName);

                        // Fit the image in the PictureBox
                        pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;

                        // Clear output image if it exists
                        pbOutput.Image = null;
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
                // Check if the file is a valid image format
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
            if (pbOutput.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif|All Files|*.*";
                saveFileDialog.Title = "Save Image";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Save the image to the selected file format
                        pbOutput.Image.Save(saveFileDialog.FileName);
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
            // Check the selectedManipulateMenuItem to determine the source PictureBox
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

            // Create a Graphics object to draw on the new image
            using (Graphics g = Graphics.FromImage(grayscaleImage))
            {
                // Create a ColorMatrix to apply the greyscale filter
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

                // Create an ImageAttributes object and set its color matrix
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);

                    // Draw the original image with the greyscale filter applied
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

            // Initialize an array to store histogram data (256 bins for 8-bit grayscale)
            int[] histogram = new int[256];

            // Get the pixel data from the image
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                // Calculate the stride (bytes per row) of the image
                int stride = bitmapData.Stride;

                // Create byte array to hold pixel data
                byte[] pixels = new byte[stride * bitmap.Height];

                // Copy the pixel data from the image to the byte array
                Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);

                // Iterate through each pixel in the image and update the histogram
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        int index = y * stride + x * 4;

                        // Extract the intensity value (grayscale)
                        int intensity = (int)(pixels[index + 2] * 0.3 + pixels[index + 1] * 0.59 + pixels[index] * 0.11);

                        // Update the histogram
                        histogram[intensity]++;
                    }
                }
            }
            finally
            {
                // Unlock the bits of the image
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

            // Lock the bits of the original and sepia images
            BitmapData originalData = ((Bitmap)originalImage).LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData sepiaData = sepiaImage.LockBits(new Rectangle(0, 0, sepiaImage.Width, sepiaImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // Get the stride (bytes per row) of the images
            int strideOriginal = originalData.Stride;
            int strideSepia = sepiaData.Stride;

            // Create byte arrays to hold pixel data
            byte[] originalBytes = new byte[strideOriginal * originalImage.Height];
            byte[] sepiaBytes = new byte[strideSepia * sepiaImage.Height];

            // Copy the pixel data from the original image to the byte array
            Marshal.Copy(originalData.Scan0, originalBytes, 0, originalBytes.Length);

            // Iterate through each pixel in the image
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    // Calculate the index of the current pixel
                    int index = y * strideOriginal + x * 4;

                    // Get the color components of the current pixel
                    int pixelB = originalBytes[index];
                    int pixelG = originalBytes[index + 1];
                    int pixelR = originalBytes[index + 2];

                    // Calculate the sepia tone values
                    int sepiaR = (int)(pixelR * 0.393 + pixelG * 0.769 + pixelB * 0.189);
                    int sepiaG = (int)(pixelR * 0.349 + pixelG * 0.686 + pixelB * 0.168);
                    int sepiaB = (int)(pixelR * 0.272 + pixelG * 0.534 + pixelB * 0.131);

                    // Ensure values are in the valid range (0 to 255)
                    sepiaR = Clamp(sepiaR, 0, 255);
                    sepiaG = Clamp(sepiaG, 0, 255);
                    sepiaB = Clamp(sepiaB, 0, 255);

                    // Set the sepia tone color to the new pixel
                    sepiaBytes[index] = (byte)sepiaB;
                    sepiaBytes[index + 1] = (byte)sepiaG;
                    sepiaBytes[index + 2] = (byte)sepiaR;
                    sepiaBytes[index + 3] = originalBytes[index + 3]; // Alpha channel
                }
            }

            // Copy the modified byte array back to the sepia image
            Marshal.Copy(sepiaBytes, 0, sepiaData.Scan0, sepiaBytes.Length);

            // Unlock the bits of the images
            ((Bitmap)originalImage).UnlockBits(originalData);
            sepiaImage.UnlockBits(sepiaData);

            return sepiaImage;
        }

        private int Clamp(int value, int min, int max)
        {
            // Version doesn't have built in Math.Clamp, did this instead
            return Math.Min(Math.Max(value, min), max);
        }

    }
}
