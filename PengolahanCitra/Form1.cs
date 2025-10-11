using System;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap currentImage;

        // Tambahkan di Form1 class
        private Bitmap previewRed, previewGreen, previewBlue, previewGray;
        private Bitmap selectedPreview;
        private Bitmap previewOriginal;

        public Form1()
        {
            InitializeComponent();
        }

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
            }
        }


        // Event Handler untuk Grayscale
        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Silakan buka gambar terlebih dahulu!", "Peringatan");
                return;
            }

            Bitmap grayImage = new Bitmap(currentImage.Width, currentImage.Height);

            for (int x = 0; x < currentImage.Width; x++)
            {
                for (int y = 0; y < currentImage.Height; y++)
                {
                    Color originalColor = currentImage.GetPixel(x, y);
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    grayImage.SetPixel(x, y, grayColor);
                }
            }

            currentImage = grayImage;
            pictureBoxMain.Image = currentImage;
        }

        private void btnSaveToTxt_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            // Dialog untuk memilih lokasi save
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
                        // Tulis informasi dimensi gambar
                        file.WriteLine($"Width: {currentImage.Width}");
                        file.WriteLine($"Height: {currentImage.Height}");
                        file.WriteLine("Format: R,G,B per pixel");
                        file.WriteLine();

                        // Loop untuk setiap baris (y)
                        for (int y = 0; y < currentImage.Height; y++)
                        {
                            // Loop untuk setiap kolom (x) dalam baris
                            for (int x = 0; x < currentImage.Width; x++)
                            {
                                Color pixelColor = currentImage.GetPixel(x, y);

                                // Tulis dalam format (R,G,B)
                                file.Write($"({pixelColor.R},{pixelColor.G},{pixelColor.B})".PadRight(15));
                            }
                            // Baris baru setelah selesai 1 row
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

        // Hover effect untuk button
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(0, 140, 220);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == btnBukaGambar)
                btn.BackColor = Color.FromArgb(0, 122, 204);
            else
                btn.BackColor = Color.FromArgb(63, 63, 70);
        }

        private void labelImageInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        // Helper untuk membuat thumbnail filter
        private Bitmap CreateFilterPreview(Bitmap src, string filterType, int thumbWidth = 50, int thumbHeight = 50)
        {
            Bitmap thumb = new Bitmap(thumbWidth, thumbHeight);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.DrawImage(src, 0, 0, thumbWidth, thumbHeight);
            }
            for (int x = 0; x < thumb.Width; x++)
            {
                for (int y = 0; y < thumb.Height; y++)
                {
                    Color c = thumb.GetPixel(x, y);
                    switch (filterType)
                    {
                        case "Red": thumb.SetPixel(x, y, Color.FromArgb(c.R, 0, 0)); break;
                        case "Green": thumb.SetPixel(x, y, Color.FromArgb(0, c.G, 0)); break;
                        case "Blue": thumb.SetPixel(x, y, Color.FromArgb(0, 0, c.B)); break;
                        case "Gray":
                            int gray = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                            thumb.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                            break;
                    }
                }
            }
            return thumb;
        }

        // Helper untuk filter full-size
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
                        case "Red": result.SetPixel(x, y, Color.FromArgb(c.R, 0, 0)); break;
                        case "Green": result.SetPixel(x, y, Color.FromArgb(0, c.G, 0)); break;
                        case "Blue": result.SetPixel(x, y, Color.FromArgb(0, 0, c.B)); break;
                        case "Gray":
                            int gray = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                            result.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                            break;
                    }
                }
            }
            return result;
        }

        // Helper untuk membuat thumbnail original
        private Bitmap CreateOriginalPreview(Bitmap src, int thumbWidth = 60, int thumbHeight = 60)
        {
            Bitmap thumb = new Bitmap(thumbWidth, thumbHeight);
            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.DrawImage(src, 0, 0, thumbWidth, thumbHeight);
            }
            return thumb;
        }

        // Event handler BtnFilter_Click
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Silakan buka gambar terlebih dahulu!");
                return;
            }

            // Buat thumbnail preview
            previewOriginal = CreateOriginalPreview(originalImage);
            previewRed = CreateFilterPreview(originalImage, "Red", 60, 60);
            previewGreen = CreateFilterPreview(originalImage, "Green", 60, 60);
            previewBlue = CreateFilterPreview(originalImage, "Blue", 60, 60);
            previewGray = CreateFilterPreview(originalImage, "Gray", 60, 60);

            // Tampilkan preview di sidebar kanan
            labelFilterTitle.Visible = true;
            pictureBoxOriginal.Image = previewOriginal;
            pictureBoxOriginal.Visible = true;
            labelOriginal.Visible = true;
            pictureBoxRed.Image = previewRed;
            pictureBoxRed.Visible = true;
            labelRed.Visible = true;
            pictureBoxGreen.Image = previewGreen;
            pictureBoxGreen.Visible = true;
            labelGreen.Visible = true;
            pictureBoxBlue.Image = previewBlue;
            pictureBoxBlue.Visible = true;
            labelBlue.Visible = true;
            pictureBoxGray.Image = previewGray;
            pictureBoxGray.Visible = true;
            labelGray.Visible = true;
            btnApplyFilter.Visible = true;

            selectedPreview = null;
        }

        // Event handler thumbnail click
        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            selectedPreview = new Bitmap(originalImage);
            pictureBoxMain.Image = selectedPreview;
        }
        private void pictureBoxRed_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Red");
            pictureBoxMain.Image = selectedPreview;
        }
        private void pictureBoxGreen_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Green");
            pictureBoxMain.Image = selectedPreview;
        }
        private void pictureBoxBlue_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Blue");
            pictureBoxMain.Image = selectedPreview;
        }
        private void pictureBoxGray_Click(object sender, EventArgs e)
        {
            selectedPreview = ApplyFilter(originalImage, "Gray");
            pictureBoxMain.Image = selectedPreview;
        }

        // Event handler Apply Filter
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (selectedPreview != null)
            {
                currentImage = new Bitmap(selectedPreview);
                pictureBoxMain.Image = currentImage;
                MessageBox.Show("Filter applied!");
            }
            else
            {
                MessageBox.Show("Pilih filter terlebih dahulu!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic here
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

                        // Save to chosen path/format
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
    }
}
