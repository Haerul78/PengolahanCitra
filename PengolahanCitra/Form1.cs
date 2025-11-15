using System;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    public partial class Form1 : Form
    {
        #region Fields & Constants

        // Images
        private Bitmap originalImage;
        private Bitmap currentImage;
        private Bitmap selectedPreview;

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
        private int currentRotationAngle = 0;
        private int currentZoomPercent = 100;

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

        private void btnBukaGambar_Click(object sender, EventArgs e) => LoadImageFromDialog();

        private void btnSave_Click(object sender, EventArgs e) => SaveCurrentImage();

        private void btnSaveToTxt_Click(object sender, EventArgs e) => SaveImageAsTextMatrix();

        #endregion

        #region Event Handlers - Filter Operations

        private void BtnFilter_Click(object sender, EventArgs e) => ToggleFilterPanel();

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            SelectFilter("Original", pictureBoxOriginal);
        }

        private void pictureBoxRed_Click(object sender, EventArgs e)
        {
            SelectFilter("Red", pictureBoxRed);
        }

        private void pictureBoxGreen_Click(object sender, EventArgs e)
        {
            SelectFilter("Green", pictureBoxGreen);
        }

        private void pictureBoxBlue_Click(object sender, EventArgs e)
        {
            SelectFilter("Blue", pictureBoxBlue);
        }

        private void pictureBoxGray_Click(object sender, EventArgs e)
        {
            SelectFilter("Gray", pictureBoxGray);
        }

        private void pictureBoxThreshold_Click(object sender, EventArgs e)
        {
            SelectFilter("Threshold", pictureBoxThreshold);
        }

        private void pictureBoxNegative_Click(object sender, EventArgs e)
        {
            SelectFilter("Negative", pictureBoxNegative);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e) => ApplySelectedFilter();

        private void SelectFilter(string filterType, PictureBox pictureBox)
        {
            selectedFilterType = filterType;
            HighlightSelectedThumbnail(pictureBox);
            UpdateMainPreview();
        }

        #endregion

        #region Event Handlers - Brightness Operations

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            
            currentBrightnessValue = trackBarBrightness.Value;
            labelBrightnessValue.Text = currentBrightnessValue.ToString();
            UpdateMainPreview();
        }

        private void btnResetBrightness_Click(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 0;
            currentBrightnessValue = 0;
            labelBrightnessValue.Text = "0";
            UpdateMainPreview();
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

        private void btnRotate45_Click(object sender, EventArgs e) => RotateImage(45);

        private void btnRotate90_Click(object sender, EventArgs e) => RotateImage(90);

        private void btnRotate180_Click(object sender, EventArgs e) => RotateImage(180);

        private void btnRotateCustom_Click(object sender, EventArgs e)
        {
            int customDegree = (int)numericUpDownDegree.Value;
            RotateImage(customDegree);
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                int offsetX = (int)numericUpDownTranslateX.Value;
                int offsetY = (int)numericUpDownTranslateY.Value;

                Bitmap translated = TranslateImage(currentImage, offsetX, offsetY);
                UpdateCurrentImage(translated);
                ShowSuccess($"Translasi berhasil! X: {offsetX}, Y: {offsetY}");
            }
            catch (Exception ex)
            {
                ShowError($"Error translasi citra: {ex.Message}");
            }
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                Bitmap flipped = FlipImageHorizontal(currentImage);
                UpdateCurrentImage(flipped);
                ShowSuccess("Gambar berhasil di-flip horizontal!");
            }
            catch (Exception ex)
            {
                ShowError($"Error flip horizontal: {ex.Message}");
            }
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                Bitmap flipped = FlipImageVertical(currentImage);
                UpdateCurrentImage(flipped);
                ShowSuccess("Gambar berhasil di-flip vertical!");
            }
            catch (Exception ex)
            {
                ShowError($"Error flip vertical: {ex.Message}");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e) => PerformImageArithmetic(AddImages, "Ditambahkan", "Penjumlahan");

        private void btnSubtractImage_Click(object sender, EventArgs e) => PerformImageArithmetic(SubtractImages, "Dikurangkan", "Pengurangan");

        private void btnMultiplyImage_Click(object sender, EventArgs e) => PerformImageArithmetic(MultiplyImages, "Perkalian", "Perkalian");

        private void btnDivideImage_Click(object sender, EventArgs e) => PerformImageArithmetic(DivideImages, "Pembagian", "Pembagian");

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded("Please load an image first.")) return;

            currentImage?.Dispose();
            currentImage = new Bitmap(originalImage);
            BitmapToMatrix(currentImage);
            UpdateMainImage(currentImage);
            ShowSuccess("Image has been reset to original.");
        }

        #endregion

        #region Event Handlers - UI & Navigation

        private void btnHome_Click(object sender, EventArgs e) => ResetToHome();

        private void Button_MouseEnter(object sender, EventArgs e) => HandleButtonHover((Button)sender, true);

        private void Button_MouseLeave(object sender, EventArgs e) => HandleButtonHover((Button)sender, false);

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            currentZoomPercent = trackBarZoom.Value;
            labelZoomValue.Text = $"{currentZoomPercent}%";
            ApplyZoomToMainImage();
        }

        // Empty event handlers
        private void labelImageInfo_Click(object sender, EventArgs e) { }
        private void panelSidebarRight_Paint(object sender, PaintEventArgs e) { }
        private void pictureBoxHistogramR_Click(object sender, EventArgs e) { }
        private void labelHistogram_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramGray_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramB_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramG_Click(object sender, EventArgs e) { }
        private void panelAritmatikContainer_Paint(object sender, PaintEventArgs e) { }
        private void labelZoomMin_Click(object sender, EventArgs e) { }
        private void labelAritmatikTitle_Click(object sender, EventArgs e) { }
        private void panelBrightnessContainer_Paint(object sender, PaintEventArgs e) { }
        private void labelFlipTitle_Click(object sender, EventArgs e) { }
        private void numericUpDownTranslateY_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownTranslateX_ValueChanged(object sender, EventArgs e) { }
        private void labelTranslateY_Click(object sender, EventArgs e) { }
        private void labelTranslateX_Click(object sender, EventArgs e) { }
        private void labelTranslateTitle_Click(object sender, EventArgs e) { }
        private void labelCustomRotate_Click(object sender, EventArgs e) { }
        private void numericUpDownDegree_ValueChanged(object sender, EventArgs e) { }
        private void labelZoomTitle_Click(object sender, EventArgs e) { }
        private void labelZoomValue_Click(object sender, EventArgs e) { }
        private void labelZoomMax_Click(object sender, EventArgs e) { }

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
                ResetFilterSettings();
                UpdateMainPreview();
            }
        }

        private void ResetFilterSettings()
        {
            selectedFilterType = "Original";
            HighlightSelectedThumbnail(pictureBoxOriginal);
            trackBarBrightness.Value = 0;
            currentBrightnessValue = 0;
            labelBrightnessValue.Text = "0";
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
            DisposeFilterPreviews();

            previewOriginal = CreateThumbnail(currentImage);
            previewRed = CreateFilterPreview(previewOriginal, "Red");
            previewGreen = CreateFilterPreview(previewOriginal, "Green");
            previewBlue = CreateFilterPreview(previewOriginal, "Blue");
            previewGray = CreateFilterPreview(previewOriginal, "Gray");
            previewThreshold = CreateFilterPreview(previewOriginal, "Threshold");
            previewNegative = CreateFilterPreview(previewOriginal, "Negative");

            AssignFilterPreviews();
        }

        private void DisposeFilterPreviews()
        {
            previewOriginal?.Dispose();
            previewRed?.Dispose();
            previewGreen?.Dispose();
            previewBlue?.Dispose();
            previewGray?.Dispose();
            previewThreshold?.Dispose();
            previewNegative?.Dispose();
        }

        private void AssignFilterPreviews()
        {
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

            BitmapToMatrix(currentImage);
            ResetFilterSettings();

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
            pictureBoxRed.BorderStyle = BorderStyle.None;
            pictureBoxGreen.BorderStyle = BorderStyle.None;
            pictureBoxBlue.BorderStyle = BorderStyle.None;
            pictureBoxGray.BorderStyle = BorderStyle.None;
            pictureBoxThreshold.BorderStyle = BorderStyle.None;
            pictureBoxNegative.BorderStyle = BorderStyle.None;
        }

        #endregion

        #region Image Processing - Filters

        private byte[,,] ApplyFilter(string filterType)
        {
            if (filterType == "Original")
            {
                if (rgbMatrix == null) BitmapToMatrix(currentImage);
                return rgbMatrix;
            }

            byte[,,] resultMatrix = new byte[imageHeight, imageWidth, 3];

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    byte r = rgbMatrix[y, x, 0];
                    byte g = rgbMatrix[y, x, 1];
                    byte b = rgbMatrix[y, x, 2];
                    byte gray = grayMatrix[y, x];

                    Color processedColor = ProcessPixelFromMatrix(r, g, b, gray, filterType);

                    resultMatrix[y, x, 0] = processedColor.R;
                    resultMatrix[y, x, 1] = processedColor.G;
                    resultMatrix[y, x, 2] = processedColor.B;
                }
            }
            
            return resultMatrix;
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

        #region Image Processing - Brightness

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

                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }
            
            return result;
        }

        #endregion

        #region Image Processing - Thumbnails

        private Bitmap CreateFilterPreview(Bitmap thumbnailSource, string filterType)
        {
            Bitmap thumbResult = new Bitmap(thumbnailSource);
            int thumbW = thumbResult.Width;
            int thumbH = thumbResult.Height;
            
            byte[,,] thumbMatrix = new byte[thumbH, thumbW, 3];
            byte[,] thumbGrayMatrix = new byte[thumbH, thumbW];

            for (int y = 0; y < thumbH; y++)
            {
                for (int x = 0; x < thumbW; x++)
                {
                    Color pixel = thumbResult.GetPixel(x, y);
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

        private void GenerateHistograms()
        {
            if (rgbMatrix == null || grayMatrix == null) return;

            DisposeHistogramImages();
            CreateHistogramImages(rgbMatrix, grayMatrix);
        }

        private void DisposeHistogramImages()
        {
            pictureBoxHistogramR.Image?.Dispose();
            pictureBoxHistogramG.Image?.Dispose();
            pictureBoxHistogramB.Image?.Dispose();
            pictureBoxHistogramGray.Image?.Dispose();
        }

        private void CreateHistogramImages(byte[,,] rgb, byte[,] gray)
        {
            pictureBoxHistogramR.Image = CreateHistogramImage(rgb, gray, "R", Color.Red);
            pictureBoxHistogramG.Image = CreateHistogramImage(rgb, gray, "G", Color.Lime);
            pictureBoxHistogramB.Image = CreateHistogramImage(rgb, gray, "B", Color.Blue);
            pictureBoxHistogramGray.Image = CreateHistogramImage(rgb, gray, "Gray", Color.White);
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
                    int value = GetChannelValue(rgb, gray, channel, y, x);
                    histogram[value]++;
                }
            }
            
            return histogram;
        }

        private int GetChannelValue(byte[,,] rgb, byte[,] gray, string channel, int y, int x)
        {
            switch (channel)
            {
                case "R": return rgb[y, x, 0];
                case "G": return rgb[y, x, 1];
                case "B": return rgb[y, x, 2];
                case "Gray": return gray[y, x];
                default: return 0;
            }
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

        #region Image Processing - Rotation

        private void RotateImage(int targetAngle)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                int angleToApply = targetAngle - currentRotationAngle;
                Bitmap rotated = RotateImageToAngle(currentImage, angleToApply);
                currentRotationAngle = targetAngle;
                UpdateCurrentImage(rotated);
                ShowSuccess($"Image rotated to {currentRotationAngle}° successfully!");
            }
            catch (Exception ex)
            {
                ShowError($"Error rotating image: {ex.Message}");
            }
        }

        private Bitmap RotateImageToAngle(Bitmap source, int angle)
        {
            if (source == null) return null;

            angle = angle % 360;
            if (angle < 0) angle += 360;

            switch (angle)
            {
                case 0:
                    return new Bitmap(source);
                
                case 45:
                    return RotateImage45Degrees(source);
                
                case 90:
                    return RotateImage90Degrees(source);
                
                case 180:
                    return RotateImage180Degrees(source);
                
                case 270:
                    return RotateImage270Degrees(source);
                
                default:
                    return RotateImageByAngle(source, angle);
            }
        }

        private Bitmap RotateImage45Degrees(Bitmap src)
        {
            int diagonal = (int)Math.Ceiling(Math.Sqrt(src.Width * src.Width + src.Height * src.Height));
            Bitmap rotated = new Bitmap(diagonal, diagonal);

            using (Graphics g = Graphics.FromImage(rotated))
            {
                ConfigureGraphicsQuality(g);
                g.Clear(Color.FromArgb(28, 28, 28));

                g.TranslateTransform(diagonal / 2f, diagonal / 2f);
                g.RotateTransform(45);
                g.TranslateTransform(-src.Width / 2f, -src.Height / 2f);
                g.DrawImage(src, 0, 0, src.Width, src.Height);
            }
            
            return rotated;
        }

        private Bitmap RotateImage90Degrees(Bitmap src)
        {
            Bitmap rotated = new Bitmap(src.Height, src.Width);
            
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    rotated.SetPixel(src.Height - y - 1, x, src.GetPixel(x, y));
                }
            }
            
            return rotated;
        }

        private Bitmap RotateImage180Degrees(Bitmap src)
        {
            Bitmap rotated = new Bitmap(src.Width, src.Height);
            
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    rotated.SetPixel(src.Width - x - 1, src.Height - y - 1, src.GetPixel(x, y));
                }
            }
            
            return rotated;
        }

        private Bitmap RotateImage270Degrees(Bitmap src)
        {
            Bitmap rotated = new Bitmap(src.Height, src.Width);
            
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    rotated.SetPixel(y, src.Width - x - 1, src.GetPixel(x, y));
                }
            }
            
            return rotated;
        }

        private Bitmap RotateImageByAngle(Bitmap src, int angle)
        {
            double radians = angle * Math.PI / 180;
            double cos = Math.Abs(Math.Cos(radians));
            double sin = Math.Abs(Math.Sin(radians));

            int newWidth = (int)Math.Ceiling(src.Width * cos + src.Height * sin);
            int newHeight = (int)Math.Ceiling(src.Width * sin + src.Height * cos);

            Bitmap rotated = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(rotated))
            {
                ConfigureGraphicsQuality(g);
                g.Clear(Color.FromArgb(28, 28, 28));

                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.RotateTransform(angle);
                g.TranslateTransform(-src.Width / 2f, -src.Height / 2f);
                g.DrawImage(src, 0, 0, src.Width, src.Height);
            }
            
            return rotated;
        }

        private void ConfigureGraphicsQuality(Graphics g)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        }

        #endregion

        #region Image Processing - Translation

        private Bitmap TranslateImage(Bitmap src, int offsetX, int offsetY)
        {
            if (src == null) return null;

            Bitmap translated = new Bitmap(src.Width, src.Height);

            using (Graphics g = Graphics.FromImage(translated))
            {
                ConfigureGraphicsQuality(g);
                g.Clear(Color.FromArgb(28, 28, 28));
                g.DrawImage(src, offsetX, offsetY, src.Width, src.Height);
            }

            return translated;
        }

        #endregion

        #region Image Processing - Flip

        private Bitmap FlipImageHorizontal(Bitmap src)
        {
            if (src == null) return null;

            int width = src.Width;
            int height = src.Height;
            Bitmap flipped = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = src.GetPixel(x, y);
                    flipped.SetPixel(width - x - 1, y, pixel);
                }
            }

            return flipped;
        }

        private Bitmap FlipImageVertical(Bitmap src)
        {
            if (src == null) return null;

            int width = src.Width;
            int height = src.Height;
            Bitmap flipped = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = src.GetPixel(x, y);
                    flipped.SetPixel(x, height - y - 1, pixel);
                }
            }

            return flipped;
        }

        #endregion

        #region Image Processing - Arithmetic Operations

        private void PerformImageArithmetic(Func<Bitmap, Bitmap, Bitmap> operation, string dialogTitle, string successMessage)
        {
            if (!ValidateImageLoaded("Silakan buka gambar utama terlebih dahulu!")) return;
            
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Title = $"Pilih Gambar untuk {dialogTitle}";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap secondImage = new Bitmap(dialog.FileName);
                    Bitmap result = operation(currentImage, secondImage);
                    UpdateCurrentImage(result);
                    ShowSuccess($"{successMessage} citra berhasil!");
                }
            }
        }

        private Bitmap AddImages(Bitmap img1, Bitmap img2)
        {
            return ProcessImagesArithmetic(img1, img2, (c1, c2) =>
            {
                int r = Clamp(c1.R + c2.R, 0, 255);
                int g = Clamp(c1.G + c2.G, 0, 255);
                int b = Clamp(c1.B + c2.B, 0, 255);
                return Color.FromArgb(r, g, b);
            });
        }

        private Bitmap SubtractImages(Bitmap img1, Bitmap img2)
        {
            return ProcessImagesArithmetic(img1, img2, (c1, c2) =>
            {
                int r = Clamp(c1.R - c2.R, 0, 255);
                int g = Clamp(c1.G - c2.G, 0, 255);
                int b = Clamp(c1.B - c2.B, 0, 255);
                return Color.FromArgb(r, g, b);
            });
        }

        private Bitmap MultiplyImages(Bitmap img1, Bitmap img2)
        {
            return ProcessImagesArithmetic(img1, img2, (c1, c2) =>
            {
                int r = Clamp((c1.R * c2.R) / 255, 0, 255);
                int g = Clamp((c1.G * c2.G) / 255, 0, 255);
                int b = Clamp((c1.B * c2.B) / 255, 0, 255);
                return Color.FromArgb(r, g, b);
            });
        }

        private Bitmap DivideImages(Bitmap img1, Bitmap img2)
        {
            return ProcessImagesArithmetic(img1, img2, (c1, c2) =>
            {
                int rDen = Math.Max(1, (int)c2.R);
                int gDen = Math.Max(1, (int)c2.G);
                int bDen = Math.Max(1, (int)c2.B);
                
                int r = Clamp((c1.R * 255) / rDen, 0, 255);
                int g = Clamp((c1.G * 255) / gDen, 0, 255);
                int b = Clamp((c1.B * 255) / bDen, 0, 255);
                
                return Color.FromArgb(r, g, b);
            });
        }

        private Bitmap ProcessImagesArithmetic(Bitmap img1, Bitmap img2, Func<Color, Color, Color> operation)
        {
            int w = Math.Min(img1.Width, img2.Width);
            int h = Math.Min(img1.Height, img2.Height);
            Bitmap result = new Bitmap(w, h);
            
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color c1 = img1.GetPixel(x, y);
                    Color c2 = img2.GetPixel(x, y);
                    Color resultColor = operation(c1, c2);
                    result.SetPixel(x, y, resultColor);
                }
            }
            
            return result;
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

        private void UpdateCurrentImage(Bitmap newImage)
        {
            currentImage?.Dispose();
            currentImage = newImage;
            BitmapToMatrix(currentImage);
            UpdateMainImage(currentImage);
        }

        private void UpdateMainImage(Bitmap image)
        {
            ApplyZoomToMainImage();
            GenerateHistograms();
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
            
            GenerateHistograms();
        }

        private void ShowAritmatikPanel()
        {
            HideFilterPanel();
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
            if (isFilterPanelVisible) HideFilterPanel();
            if (isAritmatikPanelVisible) HideAritmatikPanel();
            if (currentImage != null) ShowHistogram();
        }

        private void HandleButtonHover(Button btn, bool isEnter)
        {
            Color hoverColor = Color.FromArgb(138, 43, 226);
            Color defaultColor = Color.FromArgb(75, 0, 130);

            if (btn == btnBukaGambar)
            {
                btn.BackColor = defaultColor;
            }
            else if (btn == BtnSetColor)
            {
                btn.BackColor = isEnter && isFilterPanelVisible ? hoverColor : defaultColor;
            }
            else if (btn == Aritmathic)
            {
                btn.BackColor = isEnter && isAritmatikPanelVisible ? hoverColor : defaultColor;
            }
            else
            {
                btn.BackColor = isEnter ? hoverColor : defaultColor;
            }
        }

        private void ApplyZoomToMainImage()
        {
            if (currentImage == null) return;
            
            int newWidth = currentImage.Width * currentZoomPercent / 100;
            int newHeight = currentImage.Height * currentZoomPercent / 100;
            
            Bitmap zoomed = new Bitmap(newWidth, newHeight);
            
            using (Graphics g = Graphics.FromImage(zoomed))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(currentImage, 0, 0, newWidth, newHeight);
            }
            
            pictureBoxMain.Image = zoomed;
        }

        #endregion

        #region Utility Methods

        private int CalculateGrayscale(Color pixel)
        {
            return (pixel.R + pixel.G + pixel.B) / 3;
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