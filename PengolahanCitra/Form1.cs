using System;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    public partial class Form1 : Form
    {
        #region Fields & Constants

        // Images
        private Bitmap originalImage; // Gambar asli saat di-load
        private Bitmap currentImage;  // Gambar yang sudah di-apply filter
        private Bitmap selectedPreview; // Gambar sementara untuk preview

        // Storage Matrix
        private byte[,,] rgbMatrix;
        private byte[,] grayMatrix;
        private int imageWidth;
        private int imageHeight;

        // Preview thumbnails
        private Bitmap previewOriginal;
        private Bitmap previewRed, previewGreen, previewBlue;
        private Bitmap previewGray, previewThreshold, previewNegative;

        // State
        private bool isFilterPanelVisible;
        private bool isAritmatikPanelVisible;
        private int currentBrightnessValue = 0;
        private string selectedFilterType = "Original";

        // Constants
        private const int THUMBNAIL_SIZE = 60;
        private const int HISTOGRAM_WIDTH = 220;
        private const int HISTOGRAM_HEIGHT = 90;
        private const int THRESHOLD_VALUE = 128;

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers - Image Operations

        private void btnBukaGambar_Click(object sender, EventArgs e)
            => LoadImageFromDialog();

        private void btnSave_Click(object sender, EventArgs e)
            => SaveCurrentImage();

        private void btnSaveToTxt_Click(object sender, EventArgs e)
            => SaveImageAsTextMatrix();

        #endregion

        #region Event Handlers - Filter Operations

        private void BtnFilter_Click(object sender, EventArgs e)
            => ToggleFilterPanel();

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Original";
            HighlightSelectedThumbnail(pictureBoxOriginal);
            UpdateMainPreview();
        }

        private void pictureBoxRed_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Red";
            HighlightSelectedThumbnail(pictureBoxRed);
            UpdateMainPreview();
        }

        private void pictureBoxGreen_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Green";
            HighlightSelectedThumbnail(pictureBoxGreen);
            UpdateMainPreview();
        }

        private void pictureBoxBlue_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Blue";
            HighlightSelectedThumbnail(pictureBoxBlue);
            UpdateMainPreview();
        }

        private void pictureBoxGray_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Gray";
            HighlightSelectedThumbnail(pictureBoxGray);
            UpdateMainPreview();
        }

        private void pictureBoxThreshold_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Threshold";
            HighlightSelectedThumbnail(pictureBoxThreshold);
            UpdateMainPreview();
        }

        private void pictureBoxNegative_Click(object sender, EventArgs e)
        {
            selectedFilterType = "Negative";
            HighlightSelectedThumbnail(pictureBoxNegative);
            UpdateMainPreview();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
            => ApplySelectedFilter();

        #endregion

        #region Event Handlers - Brightness Operations

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            currentBrightnessValue = trackBarBrightness.Value;
            labelBrightnessValue.Text = currentBrightnessValue.ToString();
            UpdateMainPreview(); // Panggil fungsi preview gabungan
        }

        private void btnResetBrightness_Click(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 0;
            currentBrightnessValue = 0;
            labelBrightnessValue.Text = "0";
            UpdateMainPreview(); // Panggil fungsi preview gabungan
        }

        #endregion

        #region Event Handlers - UI & Navigation

        private void btnHome_Click(object sender, EventArgs e)
            => ResetToHome();

        private void Button_MouseEnter(object sender, EventArgs e)
            => HandleButtonHover((Button)sender, isEnter: true);

        private void Button_MouseLeave(object sender, EventArgs e)
            => HandleButtonHover((Button)sender, isEnter: false);

        private void labelImageInfo_Click(object sender, EventArgs e) { }
        private void panelSidebarRight_Paint(object sender, PaintEventArgs e) { }
        private void pictureBoxHistogramR_Click(object sender, EventArgs e) { }
        private void labelHistogram_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramGray_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramB_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramG_Click(object sender, EventArgs e) { }

        #endregion

        #region Core Logic - Image Operations

        private void LoadImageFromDialog()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Title = "Pilih Gambar";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImageFromPath(dialog.FileName);
                }
            }
        }

        private void LoadImageFromPath(string filePath)
        {
            try
            {
                originalImage?.Dispose();
                currentImage?.Dispose();
                originalImage = new Bitmap(filePath);
                currentImage = new Bitmap(originalImage);
                BitmapToMatrix(currentImage);
                UpdateMainImage(currentImage);
                if (isFilterPanelVisible)
                {
                    HideFilterPanel();
                }
                ShowHistogram();
            }
            catch (Exception ex)
            {
                ShowError($"Error loading image: {ex.Message}");
            }
        }

        private void SaveCurrentImage()
        {
            if (!ValidateImageLoaded()) return;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
                dialog.Title = "Save Image";
                dialog.FileName = "image.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var format = GetImageFormat(dialog.FileName);
                        currentImage.Save(dialog.FileName, format);
                        ShowSuccess($"Image saved successfully:\n{dialog.FileName}");
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error saving image: {ex.Message}");
                    }
                }
            }
        }

        private void SaveImageAsTextMatrix()
        {
            if (!ValidateImageLoaded()) return;
            if (rgbMatrix == null)
            {
                ShowError("Matrix data is not available.");
                return;
            }
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.Title = "Save Image as RGB Matrix";
                dialog.FileName = "image_matrix.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        WriteImageMatrixFromMatrix(dialog.FileName);
                        ShowSuccess($"Image saved as RGB matrix!\nFile: {dialog.FileName}");
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error saving file: {ex.Message}");
                    }
                }
            }
        }

        private void WriteImageMatrixFromMatrix(string filePath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                file.WriteLine($"Width: {imageWidth}");
                file.WriteLine($"Height: {imageHeight}");
                file.WriteLine("Format: R,G,B per pixel");
                file.WriteLine();
                for (int y = 0; y < imageHeight; y++)
                {
                    for (int x = 0; x < imageWidth; x++)
                    {
                        byte r = rgbMatrix[y, x, 0];
                        byte g = rgbMatrix[y, x, 1];
                        byte b = rgbMatrix[y, x, 2];
                        file.Write($"({r},{g},{b})".PadRight(15));
                    }
                    file.WriteLine();
                }
            }
        }

        #endregion

        #region Core Logic - Filter Operations

        private void ToggleFilterPanel()
        {
            if (!ValidateImageLoaded("Silakan buka gambar terlebih dahulu!")) return;

            HideAritmatikPanel();

            if (isFilterPanelVisible)
            {
                HideFilterPanel();
                ShowHistogram();
            }
            else
            {
                GenerateFilterPreviews();
                ShowFilterPanel();

                selectedFilterType = "Original";
                HighlightSelectedThumbnail(pictureBoxOriginal);
                trackBarBrightness.Value = 0;
                currentBrightnessValue = 0;
                labelBrightnessValue.Text = "0";

                UpdateMainPreview();
            }
        }

        private void UpdateMainPreview()
        {
            if (currentImage == null) return;

            selectedPreview?.Dispose();

            byte[,,] filteredMatrix = ApplyFilter(selectedFilterType);

            selectedPreview = ApplyBrightness(filteredMatrix, currentBrightnessValue);

            pictureBoxMain.Image = selectedPreview;
        }

        private void GenerateFilterPreviews()
        {
            previewOriginal?.Dispose();
            previewRed?.Dispose();
            previewGreen?.Dispose();
            previewBlue?.Dispose();
            previewGray?.Dispose();
            previewThreshold?.Dispose();
            previewNegative?.Dispose();

            // Ini memperbaiki bug "lompat" ke gambar asli
            previewOriginal = CreateThumbnail(currentImage);

            previewRed = CreateFilterPreview(previewOriginal, "Red");
            previewGreen = CreateFilterPreview(previewOriginal, "Green");
            previewBlue = CreateFilterPreview(previewOriginal, "Blue");
            previewGray = CreateFilterPreview(previewOriginal, "Gray");
            previewThreshold = CreateFilterPreview(previewOriginal, "Threshold");
            previewNegative = CreateFilterPreview(previewOriginal, "Negative");

            pictureBoxOriginal.Image = previewOriginal;
            pictureBoxRed.Image = previewRed;
            pictureBoxGreen.Image = previewGreen;
            pictureBoxBlue.Image = previewBlue;
            pictureBoxGray.Image = previewGray;
            pictureBoxThreshold.Image = previewThreshold;
            pictureBoxNegative.Image = previewNegative;
        }


        private void ApplySelectedFilter()
        {
            if (selectedPreview == null)
            {
                ShowWarning("Pilih filter terlebih dahulu!");
                return;
            }

            currentImage?.Dispose();

            currentImage = new Bitmap(selectedPreview);

            // Perbarui matriks global (Ini sudah benar)
            BitmapToMatrix(currentImage);

            // Reset panel (Ini juga sudah benar)
            selectedFilterType = "Original";
            trackBarBrightness.Value = 0;
            currentBrightnessValue = 0;
            labelBrightnessValue.Text = "0";

            HideFilterPanel();
            ShowHistogram();
            ShowSuccess("Filter applied successfully!");
        }

        private void HighlightSelectedThumbnail(PictureBox selected)
        {
            ResetAllThumbnailBorders();
            selected.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ResetAllThumbnailBorders()
        {
            pictureBoxOriginal.BorderStyle = BorderStyle.None;
            pictureBoxGreen.BorderStyle = BorderStyle.None;
            pictureBoxBlue.BorderStyle = BorderStyle.None;
            pictureBoxGray.BorderStyle = BorderStyle.None;
            pictureBoxThreshold.BorderStyle = BorderStyle.None;
            pictureBoxNegative.BorderStyle = BorderStyle.None;
            pictureBoxRed.BorderStyle = BorderStyle.None;
        }

        #endregion

        #region Image Processing - Filters (Fast & Separated)

        private byte[,,] ApplyFilter(string filterType)
        {
            // Jika "Original", langsung kembalikan matriks global (super cepat)
            if (filterType == "Original")
            {
                // Pastikan matriks ada
                if (rgbMatrix == null) BitmapToMatrix(currentImage);
                return rgbMatrix;
            }

            // Jika filter lain, buat matriks hasil sementara
            byte[,,] resultMatrix = new byte[imageHeight, imageWidth, 3];

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    // Ambil data dari global
                    byte r = rgbMatrix[y, x, 0];
                    byte g = rgbMatrix[y, x, 1];
                    byte b = rgbMatrix[y, x, 2];
                    byte gray = grayMatrix[y, x];

                    Color processedColor = ProcessPixelFromMatrix(r, g, b, gray, filterType);

                    // Simpan hasilnya ke matriks sementara
                    resultMatrix[y, x, 0] = processedColor.R;
                    resultMatrix[y, x, 1] = processedColor.G;
                    resultMatrix[y, x, 2] = processedColor.B;
                }
            }
            return resultMatrix; // Kembalikan matriks sementara
        }

        
        private Color ProcessPixelFromMatrix(byte r, byte g, byte b, byte gray, string filterType)
        {
            switch (filterType)
            {
                case "Red":
                    return Color.FromArgb(r, 0, 0);
                case "Green":
                    return Color.FromArgb(0, g, 0);
                case "Blue":
                    return Color.FromArgb(0, 0, b);
                case "Gray":
                    return Color.FromArgb(gray, gray, gray);
                case "Threshold":
                    return gray > THRESHOLD_VALUE ? Color.White : Color.Black;
                case "Negative":
                    byte inverted = (byte)(255 - gray);
                    return Color.FromArgb(inverted, inverted, inverted);

                default:
                    return Color.FromArgb(r, g, b);
            }
        }

        #endregion
        
        #region Image Processing - Brightness (Fast & Separated)

        
        private Bitmap ApplyBrightness(byte[,,] sourceMatrix, int brightnessValue)
        {
            Bitmap result = new Bitmap(imageWidth, imageHeight);

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    int r = sourceMatrix[y, x, 0];
                    int g = sourceMatrix[y, x, 1];
                    int b = sourceMatrix[y, x, 2];

                    int newR = Clamp(r + brightnessValue, 0, 255);
                    int newG = Clamp(g + brightnessValue, 0, 255);
                    int newB = Clamp(b + brightnessValue, 0, 255);


                    // 3. Set piksel
                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }
            return result; // Kembalikan Bitmap final
        }

        #endregion

        #region Image Processing - Thumbnails

        private Bitmap CreateFilterPreview(Bitmap thumbnailSource, string filterType)
        {
            // Buat salinan thumbnail
            Bitmap thumbResult = new Bitmap(thumbnailSource);
            int thumbW = thumbResult.Width;
            int thumbH = thumbResult.Height;
            byte[,,] thumbMatrix = new byte[thumbH, thumbW, 3];
            byte[,] thumbGrayMatrix = new byte[thumbH, thumbW];

            for (int y = 0; y < thumbH; y++)
            {
                for (int x = 0; x < thumbW; x++)
                {
                    Color pixel = thumbResult.GetPixel(x, y); // Cepat karena gambar kecil
                    thumbMatrix[y, x, 0] = pixel.R;
                    thumbMatrix[y, x, 1] = pixel.G;
                    thumbMatrix[y, x, 2] = pixel.B;
                    thumbGrayMatrix[y, x] = (byte)CalculateGrayscale(pixel);
                }
            }

            for (int y = 0; y < thumbH; y++)
            {
                for (int x = 0; x < thumbW; x++)
                {
                    byte r = thumbMatrix[y, x, 0];
                    byte g = thumbMatrix[y, x, 1];
                    byte b = thumbMatrix[y, x, 2];
                    byte gray = thumbGrayMatrix[y, x];
                    Color processed = ProcessPixelFromMatrix(r, g, b, gray, filterType);
                    thumbResult.SetPixel(x, y, processed);
                }
            }
            return thumbResult;
        }

        private Bitmap CreateThumbnail(Bitmap src)
        {
            Bitmap thumb = new Bitmap(THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            }
            return thumb;
        }

        #endregion

        #region Image Processing - Histogram

        private void GenerateHistograms(Bitmap image)
        {
            if (image == null) return;

            int w = image.Width;
            int h = image.Height;
            byte[,,] histRgbMatrix = new byte[h, w, 3];
            byte[,] histGrayMatrix = new byte[h, w];

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    histRgbMatrix[y, x, 0] = pixel.R;
                    histRgbMatrix[y, x, 1] = pixel.G;
                    histRgbMatrix[y, x, 2] = pixel.B;
                    histGrayMatrix[y, x] = (byte)CalculateGrayscale(pixel);
                }
            }

            pictureBoxHistogramR.Image?.Dispose();
            pictureBoxHistogramG.Image?.Dispose();
            pictureBoxHistogramB.Image?.Dispose();
            pictureBoxHistogramGray.Image?.Dispose();

            pictureBoxHistogramR.Image = CreateHistogramImage(histRgbMatrix, histGrayMatrix, "R", Color.Red);
            pictureBoxHistogramG.Image = CreateHistogramImage(histRgbMatrix, histGrayMatrix, "G", Color.Lime);
            pictureBoxHistogramB.Image = CreateHistogramImage(histRgbMatrix, histGrayMatrix, "B", Color.Blue);
            pictureBoxHistogramGray.Image = CreateHistogramImage(histRgbMatrix, histGrayMatrix, "Gray", Color.White);
        }

        private Bitmap CreateHistogramImage(byte[,,] rgb, byte[,] gray, string channel, Color color)
        {
            int[] histogram = CalculateHistogram(rgb, gray, channel);
            return DrawHistogram(histogram, color);
        }

        private int[] CalculateHistogram(byte[,,] rgb, byte[,] gray, string channel)
        {
            int[] histogram = new int[256];
            int h = gray.GetLength(0);
            int w = gray.GetLength(1);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int value = 0;
                    switch (channel)
                    {
                        case "R": value = rgb[y, x, 0]; break;
                        case "G": value = rgb[y, x, 1]; break;
                        case "B": value = rgb[y, x, 2]; break;
                        case "Gray": value = gray[y, x]; break;
                    }
                    histogram[value]++;
                }
            }
            return histogram;
        }

        private Bitmap DrawHistogram(int[] histogram, Color color)
        {
            Bitmap bmp = new Bitmap(HISTOGRAM_WIDTH, HISTOGRAM_HEIGHT);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(28, 28, 28));
                double[] logHistogram = CalculateLogHistogram(histogram);
                double maxLogValue = GetMaxValue(logHistogram);
                if (maxLogValue == 0) return bmp;
                DrawHistogramBars(g, logHistogram, maxLogValue, color);
                DrawHistogramGrid(g);
                DrawHistogramBorder(g);
                DrawHistogramLabel(g, color);
            }
            return bmp;
        }

        private double[] CalculateLogHistogram(int[] histogram)
        {
            double[] logHistogram = new double[256];
            for (int i = 0; i < histogram.Length; i++)
            {
                logHistogram[i] = Math.Log10(1 + histogram[i]);
            }
            return logHistogram;
        }

        private double GetMaxValue(double[] values)
        {
            double max = 0;
            foreach (double value in values)
            {
                if (value > max) max = value;
            }
            return max;
        }

        private void DrawHistogramBars(Graphics g, double[] logHistogram, double maxValue, Color color)
        {
            using (Pen pen = new Pen(color, 1))
            {
                for (int i = 0; i < 256; i++)
                {
                    float x = (float)i * HISTOGRAM_WIDTH / 256f;
                    float barHeight = (float)(logHistogram[i] / maxValue) * (HISTOGRAM_HEIGHT - 10);
                    if (barHeight > 0)
                    {
                        g.DrawLine(pen, x, HISTOGRAM_HEIGHT, x, HISTOGRAM_HEIGHT - barHeight);
                    }
                }
            }
        }

        private void DrawHistogramGrid(Graphics g)
        {
            using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50), 1))
            {
                g.DrawLine(gridPen, 0, HISTOGRAM_HEIGHT / 2, HISTOGRAM_WIDTH, HISTOGRAM_HEIGHT / 2);
            }
        }

        private void DrawHistogramBorder(Graphics g)
        {
            using (Pen borderPen = new Pen(Color.FromArgb(60, 60, 60), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, HISTOGRAM_WIDTH - 1, HISTOGRAM_HEIGHT - 1);
            }
        }

        private void DrawHistogramLabel(Graphics g, Color color)
        {
            using (Font font = new Font("Segoe UI", 7, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(color))
            {
                string label = GetColorLabel(color);
                g.DrawString(label, font, brush, 5, 5);
            }
        }

        private string GetColorLabel(Color color)
        {
            if (color == Color.Red) return "Red";
            if (color == Color.Lime) return "Green";
            if (color == Color.Blue) return "Blue";
            if (color == Color.White) return "Grayscale";
            return "";
        }

        #endregion

        #region Matrix Operations

        private void BitmapToMatrix(Bitmap image)
        {
            if (image == null)
            {
                rgbMatrix = null;
                grayMatrix = null;
                return;
            }

            imageWidth = image.Width;
            imageHeight = image.Height;

            rgbMatrix = new byte[imageHeight, imageWidth, 3];
            grayMatrix = new byte[imageHeight, imageWidth];

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    Color pixel = image.GetPixel(x, y); 
                    rgbMatrix[y, x, 0] = pixel.R;
                    rgbMatrix[y, x, 1] = pixel.G;
                    rgbMatrix[y, x, 2] = pixel.B;
                    grayMatrix[y, x] = (byte)CalculateGrayscale(pixel);
                }
            }
        }

        #endregion

        #region UI Helper Methods

        private void UpdateMainImage(Bitmap image)
        {
            pictureBoxMain.Image = image;
            GenerateHistograms(image);
        }

        private void ShowFilterPanel()
        {
            panelFilterContainer.Visible = true;
            isFilterPanelVisible = true;
        }

        private void HideFilterPanel()
        {
            panelFilterContainer.Visible = false;
            isFilterPanelVisible = false;
            UpdateMainImage(currentImage);
            selectedPreview?.Dispose();
            selectedPreview = null;
        }

        private void ShowHistogram()
        {
            if (currentImage == null) return;
            labelHistogram.Visible = true;
            pictureBoxHistogramR.Visible = true;
            pictureBoxHistogramG.Visible = true;
            pictureBoxHistogramB.Visible = true;
            pictureBoxHistogramGray.Visible = true;
        }

        private void ShowAritmatikPanel()
        {
            // Sembunyikan panel filter
            HideFilterPanel();
            
            // Tampilkan panel aritmatika
            panelAritmatikContainer.Visible = true;
            isAritmatikPanelVisible = true;
        }

        private void HideAritmatikPanel()
        {
            panelAritmatikContainer.Visible = false;
            isAritmatikPanelVisible = false;
        }

        private void ResetToHome()
        {
            if (isFilterPanelVisible)
            {
                HideFilterPanel();
            }
            if (isAritmatikPanelVisible)
            {
                HideAritmatikPanel();
            }
            if (currentImage != null)
            {
                ShowHistogram();
            }
        }

        private void HandleButtonHover(Button btn, bool isEnter)
        {
            if (btn == btnBukaGambar)
            {
                btn.BackColor = Color.FromArgb(75, 0, 130);
            }
            else if (btn == BtnSetColor)
            {
                if (isEnter)
                {
                    btn.BackColor = isFilterPanelVisible
                        ? Color.FromArgb(138, 43, 226)
                        : Color.FromArgb(75, 0, 130);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(75, 0, 130);
                }
            }
            else if (btn == Aritmathic)
            {
                if (isEnter)
                {
                    btn.BackColor = isAritmatikPanelVisible
                        ? Color.FromArgb(138, 43, 226)
                        : Color.FromArgb(75, 0, 130);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(75, 0, 130);
                }
            }
            else
            {
                btn.BackColor = isEnter
                    ? Color.FromArgb(138, 43, 226)
                    : Color.FromArgb(75, 0, 130);
            }
        }

        #endregion

        #region Utility Methods
        
        private int CalculateGrayscale(Color pixel)
        {
            return (int)((pixel.R + pixel.G + pixel.B) / 3);
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private System.Drawing.Imaging.ImageFormat GetImageFormat(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg")
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            if (ext == ".bmp")
                return System.Drawing.Imaging.ImageFormat.Bmp;
            return System.Drawing.Imaging.ImageFormat.Png;
        }

        #endregion

        #region Event Handlers - Aritmatika Operations

        private void BtnAritmathic_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded("Silakan buka gambar terlebih dahulu!")) return;

            if (isAritmatikPanelVisible)
            {
                HideAritmatikPanel();
                ShowHistogram();
            }
            else
            {
                ShowAritmatikPanel();
            }
        }

        #endregion

        #region Validation & Error Handling

        private bool ValidateImageLoaded(string errorMessage = "Please load an image first.")
        {
            if (currentImage == null)
            {
                ShowWarning(errorMessage);
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}