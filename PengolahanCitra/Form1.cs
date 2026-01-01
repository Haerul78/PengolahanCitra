using System;
using System.Drawing;
using System.Windows.Forms;
using PengolahanCitra.Helpers;
using PengolahanCitra.Services;

namespace PengolahanCitra
{
    public partial class Form1 : Form
    {
        #region Fields

        // Images
        private Bitmap originalImage;
        private Bitmap currentImage;
        private Bitmap selectedPreview;

        // Matrix Storage
        private byte[,,] rgbMatrix;
        private byte[,] grayMatrix;
        private int imageWidth;
        private int imageHeight;

        // Preview Thumbnails
        private Bitmap previewOriginal;
        private Bitmap previewRed, previewGreen, previewBlue;
        private Bitmap previewGray, previewThreshold, previewNegative;
        private Bitmap previewGaussian, previewSharpen, previewEqualizer;
        private Bitmap previewSmoothing, previewContrast;

        // Edge Detection Previews
        private Bitmap previewRoberts, previewPrewitt, previewSobel, previewCanny;

        // State
        private bool isFilterPanelVisible;
        private bool isAritmatikPanelVisible;
        private bool isEdgePanelVisible;
        private int currentBrightnessValue = 0;
        private string selectedFilterType = "Original";
        private string selectedEdgeType = "Roberts";
        private int currentRotationAngle = 0;
        private int currentZoomPercent = 20;

        // Constants
        private const int THUMBNAIL_SIZE = 60;
        private const int THRESHOLD_VALUE = 128;

        // Filter Settings (bisa diubah sesuai kebutuhan)
        private int gaussianBlurPasses = 5;      // Kekuatan blur (1-20)
        private bool useSharpenStrong = true;     // true = kuat, false = halus
        private int sharpenPasses = 1;            // Pengulangan sharpen (1-5)

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers - Image Operations

        private void btnBukaGambar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Title = "Pilih Gambar";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImage(dialog.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                dialog.Title = "Save Image";
                dialog.FileName = "image.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageHelper.SaveImage(currentImage, dialog.FileName);
                        ShowSuccess($"Image saved: {dialog.FileName}");
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void btnSaveToTxt_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files|*.txt";
                dialog.Title = "Save as Matrix";
                dialog.FileName = "image_matrix.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveMatrixToFile(dialog.FileName);
                }
            }
        }

        #endregion

        #region Event Handlers - Filter Operations

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded("Silakan buka gambar terlebih dahulu!")) return;

            HideAritmatikPanel();
            HideEdgePanel();

            if (isFilterPanelVisible)
            {
                HideFilterPanel();
            }
            else
            {
                GenerateFilterPreviews();
                ShowFilterPanel();
                ResetFilterSettings();
            }
        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e) => SelectFilter("Original", pictureBoxOriginal);
        private void pictureBoxRed_Click(object sender, EventArgs e) => SelectFilter("Red", pictureBoxRed);
        private void pictureBoxGreen_Click(object sender, EventArgs e) => SelectFilter("Green", pictureBoxGreen);
        private void pictureBoxBlue_Click(object sender, EventArgs e) => SelectFilter("Blue", pictureBoxBlue);
        private void pictureBoxGray_Click(object sender, EventArgs e) => SelectFilter("Gray", pictureBoxGray);
        private void pictureBoxThreshold_Click(object sender, EventArgs e) => SelectFilter("Threshold", pictureBoxThreshold);
        private void pictureBoxNegative_Click(object sender, EventArgs e) => SelectFilter("Negative", pictureBoxNegative);
        private void pictureBoxGaussian_Click(object sender, EventArgs e) => SelectFilter("Gaussian", pictureBoxGaussian);
        private void pictureBoxSharpen_Click(object sender, EventArgs e) => SelectFilter("Sharpen", pictureBoxSharpen);
        private void pictureBoxEqualizer_Click(object sender, EventArgs e) => SelectFilter("Equalizer", pictureBoxEqualizer);
        private void pictureBoxSmoothing_Click(object sender, EventArgs e) => SelectFilter("Smoothing", pictureBoxSmoothing);
        private void pictureBoxContrast_Click(object sender, EventArgs e) => SelectFilter("Contrast", pictureBoxContrast);

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (selectedPreview == null)
            {
                ShowWarning("Pilih filter terlebih dahulu!");
                return;
            }

            currentImage?.Dispose();
            currentImage = new Bitmap(selectedPreview);
            UpdateMatrixFromBitmap();
            ResetFilterSettings();
            HideFilterPanel();
            ShowHistogram();
            ShowSuccess("Filter applied!");
        }

        #endregion

        #region Event Handlers - Edge Detection

        private void btnEdge_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded("Silakan buka gambar terlebih dahulu!")) return;

            HideFilterPanel();
            HideAritmatikPanel();

            if (isEdgePanelVisible)
            {
                HideEdgePanel();
                ShowHistogram();
            }
            else
            {
                GenerateEdgePreviews();
                ShowEdgePanel();
            }
        }

        private void pictureBoxRoberts_Click(object sender, EventArgs e) => SelectEdgeFilter("Roberts", pictureBoxRoberts);
        private void pictureBoxPrewitt_Click(object sender, EventArgs e) => SelectEdgeFilter("Prewitt", pictureBoxPrewitt);
        private void pictureBoxSobel_Click(object sender, EventArgs e) => SelectEdgeFilter("Sobel", pictureBoxSobel);
        private void pictureBoxCanny_Click(object sender, EventArgs e) => SelectEdgeFilter("Canny", pictureBoxCanny);

        private void btnApplyEdge_Click(object sender, EventArgs e)
        {
            if (selectedPreview == null)
            {
                ShowWarning("Pilih metode edge detection terlebih dahulu!");
                return;
            }

            currentImage?.Dispose();
            currentImage = new Bitmap(selectedPreview);
            UpdateMatrixFromBitmap();
            HideEdgePanel();
            ShowHistogram();
            ShowSuccess($"{selectedEdgeType} edge detection applied!");
        }

        private void btnRefreshCanny_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            // Regenerate Canny preview dengan threshold baru
            int lowThreshold = (int)numericCannyLowThreshold.Value;
            int highThreshold = (int)numericCannyHighThreshold.Value;

            previewCanny?.Dispose();
            previewCanny = CreateEdgeThumbnail("Canny", lowThreshold, highThreshold);
            SetPictureBoxImage(pictureBoxCanny, previewCanny);

            // Update main preview jika Canny sedang dipilih
            if (selectedEdgeType == "Canny")
            {
                UpdateEdgeMainPreview();
            }

            ShowSuccess("Canny preview refreshed!");
        }

        #endregion

        #region Event Handlers - Brightness

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

        #region Event Handlers - Geometry (Rotate, Flip, Translate)

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
                HideFilterPanel();
                HideEdgePanel();
                ShowAritmatikPanel();
            }
        }

        private void btnRotate45_Click(object sender, EventArgs e) => RotateImage(45);
        private void btnRotate90_Click(object sender, EventArgs e) => RotateImage(90);
        private void btnRotate180_Click(object sender, EventArgs e) => RotateImage(180);

        private void btnRotateCustom_Click(object sender, EventArgs e)
        {
            int degree = (int)numericUpDownDegree.Value;
            RotateImage(degree);
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                Bitmap flipped = GeometryService.FlipHorizontal(currentImage);
                UpdateCurrentImage(flipped);
                ShowSuccess("Flip horizontal berhasil!");
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                Bitmap flipped = GeometryService.FlipVertical(currentImage);
                UpdateCurrentImage(flipped);
                ShowSuccess("Flip vertical berhasil!");
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                int offsetX = (int)numericUpDownTranslateX.Value;
                int offsetY = (int)numericUpDownTranslateY.Value;

                Bitmap translated = GeometryService.Translate(currentImage, offsetX, offsetY);
                UpdateCurrentImage(translated);
                ShowSuccess($"Translasi berhasil! X: {offsetX}, Y: {offsetY}");
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        #endregion

        #region Event Handlers - Arithmetic Operations

        private void btnAddImage_Click(object sender, EventArgs e) => PerformArithmetic("Add");
        private void btnSubtractImage_Click(object sender, EventArgs e) => PerformArithmetic("Subtract");
        private void btnMultiplyImage_Click(object sender, EventArgs e) => PerformArithmetic("Multiply");
        private void btnDivideImage_Click(object sender, EventArgs e) => PerformArithmetic("Divide");

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            currentImage?.Dispose();
            currentImage = new Bitmap(originalImage);
            currentRotationAngle = 0;
            UpdateMatrixFromBitmap();
            UpdateMainImage();
            ShowSuccess("Image reset to original!");
        }

        #endregion

        #region Event Handlers - Zoom

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            currentZoomPercent = trackBarZoom.Value;
            labelZoomValue.Text = $"{currentZoomPercent}%";
            ApplyZoomToMainImage();
        }

        #endregion

        #region Event Handlers - Color Slicing (Popup Version)

        /// <summary>
        /// Handle klik pada gambar utama untuk memilih warna dan tampilkan popup
        /// </summary>
        private void pictureBoxMain_Click(object sender, EventArgs e)
        {
            if (!ValidateImageLoaded()) return;

            // Dapatkan posisi mouse relatif terhadap PictureBox
            MouseEventArgs me = e as MouseEventArgs;
            if (me == null) return;

            // Hitung posisi pixel yang sebenarnya
            Point clickPoint = me.Location;

            // Karena menggunakan CenterImage, perlu hitung offset
            int offsetX = 0, offsetY = 0;
            if (pictureBoxMain.Image != null)
            {
                offsetX = (pictureBoxMain.Width - pictureBoxMain.Image.Width) / 2;
                offsetY = (pictureBoxMain.Height - pictureBoxMain.Image.Height) / 2;
            }

            int imageX = clickPoint.X - offsetX;
            int imageY = clickPoint.Y - offsetY;

            // Validasi posisi dalam gambar yang ditampilkan
            if (pictureBoxMain.Image == null) return;
            if (imageX < 0 || imageX >= pictureBoxMain.Image.Width) return;
            if (imageY < 0 || imageY >= pictureBoxMain.Image.Height) return;

            // Ambil warna dari gambar yang ditampilkan
            Bitmap displayedImage = pictureBoxMain.Image as Bitmap;
            if (displayedImage == null) return;

            Color pickedColor = displayedImage.GetPixel(imageX, imageY);

            // Tampilkan popup dialog
            ShowColorOperationPopup(pickedColor);
        }

        /// <summary>
        /// Tampilkan popup dialog untuk pilih operasi warna
        /// </summary>
        private void ShowColorOperationPopup(Color selectedColor)
        {
            using (ColorSlicingForm popup = new ColorSlicingForm(selectedColor))
            {
                if (popup.ShowDialog(this) == DialogResult.OK)
                {
                    // User memilih operasi
                    if (popup.SelectedOperation == "ColorSlicing")
                    {
                        ApplyColorOperation(selectedColor, popup.Tolerance, popup.UseGrayBackground, "ColorSlicing");
                    }
                    else if (popup.SelectedOperation == "PseudoColor")
                    {
                        ApplyColorOperation(selectedColor, popup.Tolerance, popup.UseGrayBackground, "PseudoColor");
                    }
                    // Tambahkan operasi lain di sini nanti (PseudoColor, dll)
                }
            }
        }

        /// <summary>
        /// Terapkan efek Color Slicing atau PseudoColor
        /// </summary>
        private void ApplyColorOperation(Color targetColor, int tolerance, bool useGrayBackground, string operation)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                byte[,,] result;

                if (operation == "ColorSlicing")
                {
                    if (useGrayBackground)
                    {
                        result = FilterService.ColorSlicingWithGrayBackground(
                            rgbMatrix, imageWidth, imageHeight,
                            targetColor.R, targetColor.G, targetColor.B,
                            tolerance);
                    }
                    else
                    {
                        result = FilterService.ColorSlicing(
                            rgbMatrix, imageWidth, imageHeight,
                            targetColor.R, targetColor.G, targetColor.B,
                            tolerance);
                    }

                    Bitmap resultBitmap = ImageHelper.RgbMatrixToBitmap(result);
                    UpdateCurrentImage(resultBitmap);

                    ShowSuccess($"Color Slicing berhasil!\nWarna: R:{targetColor.R} G:{targetColor.G} B:{targetColor.B}\nToleransi: {tolerance}");
                }
                else if (operation == "PseudoColor")
                {
                    // Map tolerance percent (0-100) to absolute distance (0-441 approx) if using percent
                    int mappedTolerance = tolerance; // default
                    try
                    {
                        // If popup provided percent slider, combine it: use tolerance * percent / 100
                        // But we don't have popup reference here; keep original tolerance for now
                        mappedTolerance = tolerance;
                    }
                    catch { }

                    result = FilterService.PseudoColor(rgbMatrix, imageWidth, imageHeight,
                        targetColor.R, targetColor.G, targetColor.B, mappedTolerance);

                    Bitmap resultBitmap = ImageHelper.RgbMatrixToBitmap(result);
                    UpdateCurrentImage(resultBitmap);

                    ShowSuccess($"Pewarnaan Semu berhasil!\nWarna target: R:{targetColor.R} G:{targetColor.G} B:{targetColor.B}\nToleransi: {mappedTolerance}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }


        #endregion

        #region Core Logic - Load & Save

        private void LoadImage(string filePath)
        {
            try
            {
                originalImage?.Dispose();
                currentImage?.Dispose();

                originalImage = ImageHelper.LoadImage(filePath);
                currentImage = ImageHelper.Clone(originalImage);

                UpdateMatrixFromBitmap();
                UpdateMainImage();

                if (isFilterPanelVisible) HideFilterPanel();
                if (isAritmatikPanelVisible) HideAritmatikPanel();
                if (isEdgePanelVisible) HideEdgePanel();
                ShowHistogram();
            }
            catch (Exception ex)
            {
                ShowError($"Error loading image: {ex.Message}");
            }
        }

        private void SaveMatrixToFile(string filePath)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(filePath))
                {
                    writer.WriteLine($"Width: {imageWidth}");
                    writer.WriteLine($"Height: {imageHeight}");
                    writer.WriteLine("Format: R,G,B per pixel");
                    writer.WriteLine();

                    for (int y = 0; y < imageHeight; y++)
                    {
                        for (int x = 0; x < imageWidth; x++)
                        {
                            byte r = rgbMatrix[y, x, 0];
                            byte g = rgbMatrix[y, x, 1];
                            byte b = rgbMatrix[y, x, 2];
                            writer.Write($"({r},{g},{b})".PadRight(15));
                        }
                        writer.WriteLine();
                    }
                }
                ShowSuccess($"Matrix saved: {filePath}");
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        #endregion

        #region Core Logic - Apply Filters

        private byte[,,] ApplyFilter(string filterType)
        {
            switch (filterType)
            {
                case "Original":
                    return rgbMatrix;

                case "Red":
                    return FilterService.RedChannel(rgbMatrix, imageWidth, imageHeight);

                case "Green":
                    return FilterService.GreenChannel(rgbMatrix, imageWidth, imageHeight);

                case "Blue":
                    return FilterService.BlueChannel(rgbMatrix, imageWidth, imageHeight);

                case "Gray":
                    return FilterService.Grayscale(rgbMatrix, imageWidth, imageHeight);

                case "Threshold":
                    return FilterService.Threshold(rgbMatrix, imageWidth, imageHeight, THRESHOLD_VALUE);

                case "Negative":
                    return FilterService.Negative(rgbMatrix, imageWidth, imageHeight);

                case "Gaussian":
                    return ConvolutionService.GaussianBlur(rgbMatrix, imageWidth, imageHeight, gaussianBlurPasses);

                case "Sharpen":
                    return ConvolutionService.Sharpen(rgbMatrix, imageWidth, imageHeight, useSharpenStrong, sharpenPasses);

                case "Equalizer":
                    return HistogramService.EqualizeLuminance(rgbMatrix, imageWidth, imageHeight);

                case "Smoothing":
                    return ConvolutionService.ImageSmoothing(rgbMatrix, imageWidth, imageHeight, 3);

                case "Contrast":
                    return FilterService.ContrastStretching(rgbMatrix, imageWidth, imageHeight);

                default:
                    return rgbMatrix;
            }
        }

        private void SelectFilter(string filterType, PictureBox pictureBox)
        {
            selectedFilterType = filterType;
            HighlightSelectedThumbnail(pictureBox);
            UpdateMainPreview();
        }

        private void UpdateMainPreview()
        {
            if (currentImage == null) return;

            byte[,,] filtered = ApplyFilter(selectedFilterType);
            byte[,,] withBrightness = FilterService.Brightness(filtered, imageWidth, imageHeight, currentBrightnessValue);

            Bitmap preview = ImageHelper.RgbMatrixToBitmap(withBrightness);
            SetPictureBoxImage(pictureBoxMain, preview);
            selectedPreview = preview;
        }

        #endregion

        #region Core Logic - Edge Detection

        private byte[,,] ApplyEdgeDetection(string edgeType, int lowThreshold = 50, int highThreshold = 150)
        {
            switch (edgeType)
            {
                case "Roberts":
                    return ConvolutionService.EdgeRoberts(rgbMatrix, imageWidth, imageHeight);

                case "Prewitt":
                    return ConvolutionService.EdgePrewitt(rgbMatrix, imageWidth, imageHeight);

                case "Sobel":
                    return ConvolutionService.EdgeSobel(rgbMatrix, imageWidth, imageHeight);

                case "Canny":
                    return ConvolutionService.EdgeCanny(rgbMatrix, imageWidth, imageHeight, lowThreshold, highThreshold);

                default:
                    return rgbMatrix;
            }
        }

        private void SelectEdgeFilter(string edgeType, PictureBox pictureBox)
        {
            selectedEdgeType = edgeType;
            HighlightSelectedEdgeThumbnail(pictureBox);
            UpdateEdgeMainPreview();
        }

        private void UpdateEdgeMainPreview()
        {
            if (currentImage == null) return;

            int lowThreshold = (int)numericCannyLowThreshold.Value;
            int highThreshold = (int)numericCannyHighThreshold.Value;

            byte[,,] edgeDetected = ApplyEdgeDetection(selectedEdgeType, lowThreshold, highThreshold);
            Bitmap preview = ImageHelper.RgbMatrixToBitmap(edgeDetected);
            SetPictureBoxImage(pictureBoxMain, preview);
            selectedPreview = preview;
        }

        private void HighlightSelectedEdgeThumbnail(PictureBox selected)
        {
            ResetAllEdgeThumbnailBorders();
            selected.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ResetAllEdgeThumbnailBorders()
        {
            pictureBoxRoberts.BorderStyle = BorderStyle.None;
            pictureBoxPrewitt.BorderStyle = BorderStyle.None;
            pictureBoxSobel.BorderStyle = BorderStyle.None;
            pictureBoxCanny.BorderStyle = BorderStyle.None;
        }

        #endregion

        #region Core Logic - Geometry

        private void RotateImage(int targetAngle)
        {
            if (!ValidateImageLoaded()) return;

            try
            {
                Bitmap rotated = GeometryService.Rotate(currentImage, targetAngle);
                currentRotationAngle = targetAngle;
                UpdateCurrentImage(rotated);
                ShowSuccess($"Rotated to {currentRotationAngle}°");
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        #endregion

        #region Core Logic - Arithmetic

        private void PerformArithmetic(string operation)
        {
            if (!ValidateImageLoaded()) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.Title = "Pilih gambar kedua";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap img2 = ImageHelper.LoadImage(dialog.FileName);
                        byte[,,] matrix2 = ImageHelper.BitmapToRgbMatrix(img2);
                        img2.Dispose();

                        byte[,,] result;
                        switch (operation)
                        {
                            case "Add":
                                result = ArithmeticService.Add(rgbMatrix, matrix2, imageWidth, imageHeight);
                                break;
                            case "Subtract":
                                result = ArithmeticService.Subtract(rgbMatrix, matrix2, imageWidth, imageHeight);
                                break;
                            case "Multiply":
                                result = ArithmeticService.Multiply(rgbMatrix, matrix2, imageWidth, imageHeight);
                                break;
                            case "Divide":
                                result = ArithmeticService.Divide(rgbMatrix, matrix2, imageWidth, imageHeight);
                                break;
                            default:
                                return;
                        }

                        Bitmap resultBitmap = ImageHelper.RgbMatrixToBitmap(result);
                        UpdateCurrentImage(resultBitmap);
                        ShowSuccess($"{operation} berhasil!");
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error: {ex.Message}");
                    }
                }
            }
        }

        #endregion

        #region Preview Generation

        private void GenerateFilterPreviews()
        {
            ClearPreviewPictureBoxes();
            DisposeFilterPreviews();

            previewOriginal = ImageHelper.CreateThumbnail(currentImage, THUMBNAIL_SIZE);

            // Generate previews menggunakan services
            previewRed = CreateFilterThumbnail("Red");
            previewGreen = CreateFilterThumbnail("Green");
            previewBlue = CreateFilterThumbnail("Blue");
            previewGray = CreateFilterThumbnail("Gray");
            previewThreshold = CreateFilterThumbnail("Threshold");
            previewNegative = CreateFilterThumbnail("Negative");
            previewGaussian = CreateFilterThumbnail("Gaussian");
            previewSharpen = CreateFilterThumbnail("Sharpen");
            previewEqualizer = CreateFilterThumbnail("Equalizer");
            previewSmoothing = CreateFilterThumbnail("Smoothing");
            previewContrast = CreateFilterThumbnail("Contrast");

            AssignFilterPreviews();
        }

        private Bitmap CreateFilterThumbnail(string filterType)
        {
            byte[,,] thumbMatrix = ImageHelper.BitmapToRgbMatrix(previewOriginal);
            int w = previewOriginal.Width;
            int h = previewOriginal.Height;

            byte[,,] filtered;
            switch (filterType)
            {
                case "Red":
                    filtered = FilterService.RedChannel(thumbMatrix, w, h);
                    break;
                case "Green":
                    filtered = FilterService.GreenChannel(thumbMatrix, w, h);
                    break;
                case "Blue":
                    filtered = FilterService.BlueChannel(thumbMatrix, w, h);
                    break;
                case "Gray":
                    filtered = FilterService.Grayscale(thumbMatrix, w, h);
                    break;
                case "Threshold":
                    filtered = FilterService.Threshold(thumbMatrix, w, h, THRESHOLD_VALUE);
                    break;
                case "Negative":
                    filtered = FilterService.Negative(thumbMatrix, w, h);
                    break;
                case "Gaussian":
                    filtered = ConvolutionService.GaussianBlur(thumbMatrix, w, h, gaussianBlurPasses);
                    break;
                case "Sharpen":
                    filtered = ConvolutionService.Sharpen(thumbMatrix, w, h, useSharpenStrong, sharpenPasses);
                    break;
                case "Equalizer":
                    filtered = HistogramService.EqualizeLuminance(thumbMatrix, w, h);
                    break;
                case "Smoothing":
                    filtered = ConvolutionService.ImageSmoothing(thumbMatrix, w, h, 3);
                    break;
                case "Contrast":
                    filtered = FilterService.ContrastStretching(thumbMatrix, w, h);
                    break;
                default:
                    filtered = thumbMatrix;
                    break;
            }

            return ImageHelper.RgbMatrixToBitmap(filtered);
        }

        private void GenerateEdgePreviews()
        {
            ClearEdgePreviewPictureBoxes();
            DisposeEdgePreviews();

            int lowThreshold = (int)numericCannyLowThreshold.Value;
            int highThreshold = (int)numericCannyHighThreshold.Value;

            previewRoberts = CreateEdgeThumbnail("Roberts");
            previewPrewitt = CreateEdgeThumbnail("Prewitt");
            previewSobel = CreateEdgeThumbnail("Sobel");
            previewCanny = CreateEdgeThumbnail("Canny", lowThreshold, highThreshold);

            AssignEdgePreviews();
        }

        private Bitmap CreateEdgeThumbnail(string edgeType, int lowThreshold = 50, int highThreshold = 150)
        {
            Bitmap thumbnail = ImageHelper.CreateThumbnail(currentImage, 80);
            byte[,,] thumbMatrix = ImageHelper.BitmapToRgbMatrix(thumbnail);
            int w = thumbnail.Width;
            int h = thumbnail.Height;
            thumbnail.Dispose();

            byte[,,] edgeDetected;
            switch (edgeType)
            {
                case "Roberts":
                    edgeDetected = ConvolutionService.EdgeRoberts(thumbMatrix, w, h);
                    break;
                case "Prewitt":
                    edgeDetected = ConvolutionService.EdgePrewitt(thumbMatrix, w, h);
                    break;
                case "Sobel":
                    edgeDetected = ConvolutionService.EdgeSobel(thumbMatrix, w, h);
                    break;
                case "Canny":
                    edgeDetected = ConvolutionService.EdgeCanny(thumbMatrix, w, h, lowThreshold, highThreshold);
                    break;
                default:
                    edgeDetected = thumbMatrix;
                    break;
            }

            return ImageHelper.RgbMatrixToBitmap(edgeDetected);
        }

        #endregion

        #region Histogram

        private void GenerateHistograms()
        {
            if (rgbMatrix == null || grayMatrix == null) return;

            DisposeHistogramImages();

            int[] histR = HistogramService.CalculateHistogram(rgbMatrix, grayMatrix, "R");
            int[] histG = HistogramService.CalculateHistogram(rgbMatrix, grayMatrix, "G");
            int[] histB = HistogramService.CalculateHistogram(rgbMatrix, grayMatrix, "B");
            int[] histGray = HistogramService.CalculateHistogram(rgbMatrix, grayMatrix, "Gray");

            pictureBoxHistogramR.Image = HistogramService.GenerateHistogramImage(histR, Color.Red);
            pictureBoxHistogramG.Image = HistogramService.GenerateHistogramImage(histG, Color.Lime);
            pictureBoxHistogramB.Image = HistogramService.GenerateHistogramImage(histB, Color.Blue);
            pictureBoxHistogramGray.Image = HistogramService.GenerateHistogramImage(histGray, Color.White);
        }

        #endregion

        #region Matrix Operations

        private void UpdateMatrixFromBitmap()
        {
            if (currentImage == null)
            {
                rgbMatrix = null;
                grayMatrix = null;
                return;
            }

            imageWidth = currentImage.Width;
            imageHeight = currentImage.Height;
            rgbMatrix = ImageHelper.BitmapToRgbMatrix(currentImage);
            grayMatrix = ImageHelper.BitmapToGrayMatrix(currentImage);
        }

        #endregion

        #region UI Helper Methods

        private void UpdateCurrentImage(Bitmap newImage)
        {
            currentImage?.Dispose();
            currentImage = newImage;
            UpdateMatrixFromBitmap();
            UpdateMainImage();
        }

        private void UpdateMainImage()
        {
            ApplyZoomToMainImage();
            GenerateHistograms();
        }

        private void ApplyZoomToMainImage()
        {
            if (currentImage == null) return;

            Bitmap zoomed = ImageHelper.Resize(currentImage, currentZoomPercent);
            SetPictureBoxImage(pictureBoxMain, zoomed);
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
            UpdateMainImage();
            selectedPreview = null;
        }

        private void ShowEdgePanel()
        {
            panelEdgeContainer.Visible = true;
            isEdgePanelVisible = true;
        }

        private void HideEdgePanel()
        {
            panelEdgeContainer.Visible = false;
            isEdgePanelVisible = false;
            UpdateMainImage();
            selectedPreview = null;
        }

        private void ShowAritmatikPanel()
        {
            panelAritmatikContainer.Visible = true;
            isAritmatikPanelVisible = true;
        }

        private void HideAritmatikPanel()
        {
            panelAritmatikContainer.Visible = false;
            isAritmatikPanelVisible = false;
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

        private void ResetFilterSettings()
        {
            selectedFilterType = "Original";
            HighlightSelectedThumbnail(pictureBoxOriginal);
            trackBarBrightness.Value = 0;
            currentBrightnessValue = 0;
            labelBrightnessValue.Text = "0";
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
            pictureBoxGaussian.BorderStyle = BorderStyle.None;
            pictureBoxSharpen.BorderStyle = BorderStyle.None;
            pictureBoxEqualizer.BorderStyle = BorderStyle.None;
            pictureBoxSmoothing.BorderStyle = BorderStyle.None;
            pictureBoxContrast.BorderStyle = BorderStyle.None;
        }

        private void SetPictureBoxImage(PictureBox pb, Image newImage)
        {
            var old = pb.Image;
            pb.Image = newImage;
            if (old != null && !ReferenceEquals(old, newImage))
            {
                try { old.Dispose(); } catch { }
            }
        }

        private void AssignFilterPreviews()
        {
            SetPictureBoxImage(pictureBoxOriginal, previewOriginal);
            SetPictureBoxImage(pictureBoxRed, previewRed);
            SetPictureBoxImage(pictureBoxGreen, previewGreen);
            SetPictureBoxImage(pictureBoxBlue, previewBlue);
            SetPictureBoxImage(pictureBoxGray, previewGray);
            SetPictureBoxImage(pictureBoxThreshold, previewThreshold);
            SetPictureBoxImage(pictureBoxNegative, previewNegative);
            SetPictureBoxImage(pictureBoxGaussian, previewGaussian);
            SetPictureBoxImage(pictureBoxSharpen, previewSharpen);
            SetPictureBoxImage(pictureBoxEqualizer, previewEqualizer);
            SetPictureBoxImage(pictureBoxSmoothing, previewSmoothing);
            SetPictureBoxImage(pictureBoxContrast, previewContrast);
        }

        private void AssignEdgePreviews()
        {
            SetPictureBoxImage(pictureBoxRoberts, previewRoberts);
            SetPictureBoxImage(pictureBoxPrewitt, previewPrewitt);
            SetPictureBoxImage(pictureBoxSobel, previewSobel);
            SetPictureBoxImage(pictureBoxCanny, previewCanny);
        }

        private void ClearPreviewPictureBoxes()
        {
            SetPictureBoxImage(pictureBoxOriginal, null);
            SetPictureBoxImage(pictureBoxRed, null);
            SetPictureBoxImage(pictureBoxGreen, null);
            SetPictureBoxImage(pictureBoxBlue, null);
            SetPictureBoxImage(pictureBoxGray, null);
            SetPictureBoxImage(pictureBoxThreshold, null);
            SetPictureBoxImage(pictureBoxNegative, null);
            SetPictureBoxImage(pictureBoxGaussian, null);
            SetPictureBoxImage(pictureBoxSharpen, null);
            SetPictureBoxImage(pictureBoxEqualizer, null);
            SetPictureBoxImage(pictureBoxSmoothing, null);
            SetPictureBoxImage(pictureBoxContrast, null);
        }

        private void ClearEdgePreviewPictureBoxes()
        {
            SetPictureBoxImage(pictureBoxRoberts, null);
            SetPictureBoxImage(pictureBoxPrewitt, null);
            SetPictureBoxImage(pictureBoxSobel, null);
            SetPictureBoxImage(pictureBoxCanny, null);
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
            previewGaussian?.Dispose();
            previewSharpen?.Dispose();
            previewEqualizer?.Dispose();
            previewSmoothing?.Dispose();
            previewContrast?.Dispose();
        }

        private void DisposeEdgePreviews()
        {
            previewRoberts?.Dispose();
            previewPrewitt?.Dispose();
            previewSobel?.Dispose();
            previewCanny?.Dispose();
        }

        private void DisposeHistogramImages()
        {
            pictureBoxHistogramR.Image?.Dispose();
            pictureBoxHistogramG.Image?.Dispose();
            pictureBoxHistogramB.Image?.Dispose();
            pictureBoxHistogramGray.Image?.Dispose();
        }

        #endregion

        #region Validation & Messages

        private bool ValidateImageLoaded(string message = "Please load an image first.")
        {
            if (currentImage == null)
            {
                ShowWarning(message);
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

        #region Empty Event Handlers (dari Designer)

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (isFilterPanelVisible) HideFilterPanel();
            if (isAritmatikPanelVisible) HideAritmatikPanel();
            if (isEdgePanelVisible) HideEdgePanel();
            if (currentImage != null) ShowHistogram();
        }

        private void Button_MouseEnter(object sender, EventArgs e) { }
        private void Button_MouseLeave(object sender, EventArgs e) { }
        private void panelFilterContainer_Paint(object sender, PaintEventArgs e) { }
        private void panelAritmatikContainer_Paint(object sender, PaintEventArgs e) { }
        private void panelSidebarRight_Paint(object sender, PaintEventArgs e) { }
        private void labelImageInfo_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramR_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramG_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramB_Click(object sender, EventArgs e) { }
        private void pictureBoxHistogramGray_Click(object sender, EventArgs e) { }
        private void labelHistogram_Click(object sender, EventArgs e) { }
        private void labelSharpen_Click(object sender, EventArgs e) { }
        private void panelBrightnessContainer_Paint(object sender, PaintEventArgs e) { }
        private void labelFlipTitle_Click(object sender, EventArgs e) { }
        private void numericUpDownTranslateY_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownTranslateX_ValueChanged(object sender, EventArgs e) { }
        private void labelTranslateY_Click(object sender, EventArgs e) { }
        private void labelTranslateX_Click(object sender, EventArgs e) { }
        private void labelTranslateTitle_Click(object sender, EventArgs e) { }
        private void numericUpDownDegree_ValueChanged(object sender, EventArgs e) { }
        private void labelCustomRotate_Click(object sender, EventArgs e) { }
        private void labelAritmatikTitle_Click(object sender, EventArgs e) { }
        private void labelZoomTitle_Click(object sender, EventArgs e) { }
        private void labelZoomValue_Click(object sender, EventArgs e) { }
        private void labelZoomMin_Click(object sender, EventArgs e) { }
        private void labelZoomMax_Click(object sender, EventArgs e) { }
        private void btnPreviewSharpen_Click(object sender, EventArgs e) { }

        #endregion
    }
}