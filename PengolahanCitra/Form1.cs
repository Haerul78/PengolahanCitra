using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PengolahanCitra
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap currentImage;

        // Preview images
        private Bitmap previewRed, previewGreen, previewBlue, previewGray;
        private Bitmap selectedPreview;
        private Bitmap previewOriginal;

        // State untuk toggle panel
        private bool isFilterPanelVisible = false;
        private bool isHistogramVisible = true;

        public Form1()
        {
            InitializeComponent();
            //InitializeUIState();
        }

        // Initialize UI state saat startup
        private void InitializeUIState()
        {
            // Sembunyikan filter panel di awal
            HideFilterPanel();
            // Sembunyikan histogram di awal (sampai ada gambar)
            //HideHistogram();
        }

        // Method untuk show/hide Filter Panel
        private void ShowFilterPanel()
        {
            labelFilterTitle.Visible = true;
            pictureBoxOriginal.Visible = true;
            labelOriginal.Visible = true;
            pictureBoxRed.Visible = true;
            labelRed.Visible = true;
            pictureBoxGreen.Visible = true;
            labelGreen.Visible = true;
            pictureBoxBlue.Visible = true;
            labelBlue.Visible = true;
            pictureBoxGray.Visible = true;
            labelGray.Visible = true;
            btnApplyFilter.Visible = true;

            // Hide histogram saat filter panel muncul
            //HideHistogram();
            isFilterPanelVisible = true;
        }

        private void HideFilterPanel()
        {
            labelFilterTitle.Visible = false;
            pictureBoxOriginal.Visible = false;
            labelOriginal.Visible = false;
            pictureBoxRed.Visible = false;
            labelRed.Visible = false;
            pictureBoxGreen.Visible = false;
            labelGreen.Visible = false;
            pictureBoxBlue.Visible = false;
            labelBlue.Visible = false;
            pictureBoxGray.Visible = false;
            labelGray.Visible = false;
            btnApplyFilter.Visible = false;

            isFilterPanelVisible = false;
        }

        // Method untuk show/hide Histogram
        private void ShowHistogram()
        {
            if (currentImage != null)
            {
                labelHistogram.Visible = true;
                pictureBoxHistogramR.Visible = true;
                pictureBoxHistogramG.Visible = true;
                pictureBoxHistogramB.Visible = true;
                pictureBoxHistogramGray.Visible = true;
                isHistogramVisible = true;
            }
        }

        //private void HideHistogram()
        //{
        //    labelHistogram.Visible = false;
        //    pictureBoxHistogramR.Visible = false;
        //    pictureBoxHistogramG.Visible = false;
        //    pictureBoxHistogramB.Visible = false;
        //    pictureBoxHistogramGray.Visible = false;
        //    isHistogramVisible = false;
        //}

        // Event Handler untuk Buka Gambar
        private void btnBukaGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Pilih Gambar";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                currentImage = new Bitmap(originalImage);
                pictureBoxMain.Image = currentImage;

                // Generate histogram dan tampilkan
                GenerateHistograms(currentImage);

                // Jika filter panel sedang terbuka, sembunyikan dan tampilkan histogram
                if (isFilterPanelVisible)
                {
                    HideFilterPanel();
                    ShowHistogram();
                }
                else
                {
                    ShowHistogram();
                }
            }
        }

        // Event Handler untuk Save to TXT
        private void btnSaveToTxt_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Image as RGB Matrix";
            saveFileDialog.FileName = "image_matrix.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        file.WriteLine($"Width: {currentImage.Width}");
                        file.WriteLine($"Height: {currentImage.Height}");
                        file.WriteLine("Format: R,G,B per pixel");
                        file.WriteLine();

                        for (int y = 0; y < currentImage.Height; y++)
                        {
                            for (int x = 0; x < currentImage.Width; x++)
                            {
                                Color pixelColor = currentImage.GetPixel(x, y);
                                file.Write($"({pixelColor.R},{pixelColor.G},{pixelColor.B})".PadRight(15));
                            }
                            file.WriteLine();
                        }
                        file.WriteLine();
                    }

                    MessageBox.Show($"Image saved successfully as RGB matrix!\nFile: {saveFileDialog.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        // Event handler BtnFilter_Click - TOGGLE functionality
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Silakan buka gambar terlebih dahulu!");
                return;
            }

            // Toggle filter panel
            if (isFilterPanelVisible)
            {
                // Jika filter panel sedang tampil, sembunyikan dan tampilkan histogram
                HideFilterPanel();
                ShowHistogram();
            }
            else
            {
                // Jika filter panel sedang tersembunyi, tampilkan filter panel
                // Buat thumbnail preview
                previewOriginal = CreateOriginalPreview(originalImage);
                previewRed = CreateFilterPreview(originalImage, "Red", 60, 60);
                previewGreen = CreateFilterPreview(originalImage, "Green", 60, 60);
                previewBlue = CreateFilterPreview(originalImage, "Blue", 60, 60);
                previewGray = CreateFilterPreview(originalImage, "Gray", 60, 60);

                // Set preview images
                pictureBoxOriginal.Image = previewOriginal;
                pictureBoxRed.Image = previewRed;
                pictureBoxGreen.Image = previewGreen;
                pictureBoxBlue.Image = previewBlue;
                pictureBoxGray.Image = previewGray;

                // Tampilkan filter panel
                ShowFilterPanel();

                selectedPreview = null;
            }
        }

        // Hover effect untuk button
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == btnBukaGambar)
                btn.BackColor = Color.FromArgb(0, 140, 220);
            else if (btn == BtnSetColor && !isFilterPanelVisible)
                btn.BackColor = Color.FromArgb(100, 100, 107);
            else if (btn == BtnSetColor && isFilterPanelVisible)
                btn.BackColor = Color.FromArgb(200, 100, 100); // Warna berbeda saat aktif
            else
                btn.BackColor = Color.FromArgb(100, 100, 107);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == btnBukaGambar)
                btn.BackColor = Color.FromArgb(0, 122, 204);
            else if (btn == BtnSetColor && isFilterPanelVisible)
                btn.BackColor = Color.FromArgb(150, 80, 80); // Warna aktif
            else
                btn.BackColor = Color.FromArgb(63, 63, 70);
        }

        /* Navbar */
        private void labelImageInfo_Click(object sender, EventArgs e)
        {
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Reset ke tampilan awal
            if (isFilterPanelVisible)
            {
                HideFilterPanel();
                if (currentImage != null)
                {
                    ShowHistogram();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Image";
                saveFileDialog.FileName = "image.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = saveFileDialog.FileName;
                        string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();

                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                        if (ext == ".jpg" || ext == ".jpeg") format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        else if (ext == ".bmp") format = System.Drawing.Imaging.ImageFormat.Bmp;

                        currentImage.Save(path, format);
                        MessageBox.Show($"Image saved successfully:\n{path}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}");
                    }
                }
            }
        }

        /* Filter Section */
        private Bitmap CreateFilterPreview(Bitmap src, string filterType, int thumbWidth = 50, int thumbHeight = 50)
        {
            Bitmap thumb = new Bitmap(thumbWidth, thumbHeight);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, thumbWidth, thumbHeight);
            }

            for (int x = 0; x < thumb.Width; x++)
            {
                for (int y = 0; y < thumb.Height; y++)
                {
                    Color c = thumb.GetPixel(x, y);
                    switch (filterType)
                    {
                        case "Red":
                            thumb.SetPixel(x, y, Color.FromArgb(c.R, 0, 0));
                            break;
                        case "Green":
                            thumb.SetPixel(x, y, Color.FromArgb(0, c.G, 0));
                            break;
                        case "Blue":
                            thumb.SetPixel(x, y, Color.FromArgb(0, 0, c.B));
                            break;
                        case "Gray":
                            int gray = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                            thumb.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                            break;
                    }
                }
            }
            return thumb;
        }

        private Bitmap ApplyFilter(Bitmap src, string filterType)
        {
            Bitmap result = new Bitmap(src.Width, src.Height);
            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    Color c = src.GetPixel(x, y);
                    switch (filterType)
                    {
                        case "Red":
                            result.SetPixel(x, y, Color.FromArgb(c.R, 0, 0));
                            break;
                        case "Green":
                            result.SetPixel(x, y, Color.FromArgb(0, c.G, 0));
                            break;
                        case "Blue":
                            result.SetPixel(x, y, Color.FromArgb(0, 0, c.B));
                            break;
                        case "Gray":
                            int gray = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                            result.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                            break;
                    }
                }
            }
            return result;
        }

        private Bitmap CreateOriginalPreview(Bitmap src, int thumbWidth = 60, int thumbHeight = 60)
        {
            Bitmap thumb = new Bitmap(thumbWidth, thumbHeight);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, thumbWidth, thumbHeight);
            }
            return thumb;
        }

        // Event handler thumbnail click - Preview saja, tidak langsung apply
        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            selectedPreview = new Bitmap(originalImage);
            pictureBoxMain.Image = selectedPreview;
            HighlightSelectedThumbnail(pictureBoxOriginal);
        }

        private void pictureBoxRed_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Red");
            pictureBoxMain.Image = selectedPreview;
            HighlightSelectedThumbnail(pictureBoxRed);
        }

        private void pictureBoxGreen_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Green");
            pictureBoxMain.Image = selectedPreview;
            HighlightSelectedThumbnail(pictureBoxGreen);
        }

        private void pictureBoxBlue_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Blue");
            pictureBoxMain.Image = selectedPreview;
            HighlightSelectedThumbnail(pictureBoxBlue);
        }

        private void pictureBoxGray_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Gray");
            pictureBoxMain.Image = selectedPreview;
            HighlightSelectedThumbnail(pictureBoxGray);
        }

        // Highlight selected thumbnail
        private void HighlightSelectedThumbnail(PictureBox selected)
        {
            // Reset all borders
            pictureBoxOriginal.BorderStyle = BorderStyle.None;
            pictureBoxRed.BorderStyle = BorderStyle.None;
            pictureBoxGreen.BorderStyle = BorderStyle.None;
            pictureBoxBlue.BorderStyle = BorderStyle.None;
            pictureBoxGray.BorderStyle = BorderStyle.None;

            // Highlight selected
            selected.BorderStyle = BorderStyle.Fixed3D;
        }

        // Event handler Apply Filter
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (selectedPreview != null)
            {
                currentImage = new Bitmap(selectedPreview);
                pictureBoxMain.Image = currentImage;

                // Generate histogram untuk gambar baru
                GenerateHistograms(currentImage);

                // Sembunyikan filter panel dan tampilkan histogram
                HideFilterPanel();
                ShowHistogram();

                MessageBox.Show("Filter applied successfully!");
            }
            else
            {
                MessageBox.Show("Pilih filter terlebih dahulu!");
            }
        }


        private void panelSidebarRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxHistogramR_Click(object sender, EventArgs e)
        {

        }

        private void labelHistogram_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxHistogramGray_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxHistogramB_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxHistogramG_Click(object sender, EventArgs e)
        {

        }

        // Method untuk menghitung histogram
        private int[] CalculateHistogram(Bitmap image, string channel)
        {
            int[] histogram = new int[256];

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int value = 0;

                    switch (channel)
                    {
                        case "R":
                            value = pixel.R;
                            break;
                        case "G":
                            value = pixel.G;
                            break;
                        case "B":
                            value = pixel.B;
                            break;
                        case "Gray":
                            value = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                            break;
                    }

                    histogram[value]++;
                }
            }

            return histogram;
        }

        // Method untuk menggambar histogram
        private Bitmap DrawHistogram(int[] histogram, Color color, int width = 190, int height = 80)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(28, 28, 28));

                int maxValue = 0;
                for (int i = 0; i < histogram.Length; i++)
                {
                    if (histogram[i] > maxValue)
                        maxValue = histogram[i];
                }

                if (maxValue == 0)
                    return bmp;

                using (Pen pen = new Pen(color, 1))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        float x = (float)i * width / 256f;
                        float barHeight = (float)histogram[i] * (height - 10) / maxValue;
                        g.DrawLine(pen, x, height, x, height - barHeight);
                    }
                }

                // Grid lines
                using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50), 1))
                {
                    g.DrawLine(gridPen, 0, height / 2, width, height / 2);
                }

                // Border
                using (Pen borderPen = new Pen(Color.FromArgb(60, 60, 60), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);
                }

                // Label
                using (Font font = new Font("Segoe UI", 7, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    string label = "";
                    if (color == Color.Red) label = "Red";
                    else if (color == Color.Lime) label = "Green";
                    else if (color == Color.Blue) label = "Blue";
                    else if (color == Color.White) label = "Grayscale";

                    g.DrawString(label, font, brush, 5, 5);
                }
            }

            return bmp;
        }

        // Method untuk generate semua histogram
        private void GenerateHistograms(Bitmap image)
        {
            if (image == null) return;

            int[] histR = CalculateHistogram(image, "R");
            int[] histG = CalculateHistogram(image, "G");
            int[] histB = CalculateHistogram(image, "B");
            int[] histGray = CalculateHistogram(image, "Gray");

            pictureBoxHistogramR.Image = DrawHistogram(histR, Color.Red);
            pictureBoxHistogramG.Image = DrawHistogram(histG, Color.Lime);
            pictureBoxHistogramB.Image = DrawHistogram(histB, Color.Blue);
            pictureBoxHistogramGray.Image = DrawHistogram(histGray, Color.White);
        }
    }
}