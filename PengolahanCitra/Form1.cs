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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk disimpan. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp|GIF Image|*.gif";
            saveFileDialog.Title = "Simpan Gambar";
            saveFileDialog.FileName = "edited_image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Drawing.Imaging.ImageFormat format;
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = System.Drawing.Imaging.ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;
                        case ".gif":
                            format = System.Drawing.Imaging.ImageFormat.Gif;
                            break;
                        default:
                            MessageBox.Show("Unsupported file format. Please select a valid image format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    currentImage.Save(saveFileDialog.FileName, format);
                    MessageBox.Show($"Gambar berhasil disimpan! \nLokasi: {saveFileDialog.FileName}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {

        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk diterapkan filter. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TampilkanFilterBtns();
        }

        private void TampilkanFilterBtns()
        {
            panelSidebarRight.Controls.Clear();

            Button btnRedFilter = new Button
            {
                Text = "Red Filter",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(63, 63, 70),
                ForeColor = Color.White
            };
            btnRedFilter.Click += btnRedFilter_Click;
            btnRedFilter.MouseEnter += Button_MouseEnter;
            btnRedFilter.MouseLeave += Button_MouseLeave;
            panelSidebarRight.Controls.Add(btnRedFilter);
            //panelSidebarLeft.Controls.Add(btnRedFilter);
            //panelSidebarLeft.Controls.Add(btnGreenFilter);
            //panelSidebarLeft.Controls.Add(btnBlueFilter);
            //panelSidebarLeft.Controls.Add(btnGrayScale);

            Label labelFilters = new Label
            {
                Text = "Filters",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.TopLeft
            };
            panelSidebarRight.Controls.Add(labelFilters);
        }

        private void btnRedFilter_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk diterapkan filter. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Terapkan filter merah
            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color pixelColor = currentImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0); // Set green and blue to 0
                    currentImage.SetPixel(x, y, newColor);
                }
            }
            pictureBoxMain.Image = currentImage;
        }

        private void btnGreenFilter_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk diterapkan filter. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Terapkan filter hijau
            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color pixelColor = currentImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, pixelColor.G, 0); // Set red and blue to 0
                    currentImage.SetPixel(x, y, newColor);
                }
            }
            pictureBoxMain.Image = currentImage;
        }

        private void btnBlueFilter_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk diterapkan filter. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Terapkan filter biru
            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color pixelColor = currentImage.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, pixelColor.B); // Set red and green to 0
                    currentImage.SetPixel(x, y, newColor);
                }
            }
            pictureBoxMain.Image = currentImage;
        }

        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk diterapkan filter. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Terapkan filter grayscale
            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color pixelColor = currentImage.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    currentImage.SetPixel(x, y, newColor);
                }
            }
            pictureBoxMain.Image = currentImage;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Tidak ada gambar untuk direset. Silakan buka gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Reset ke gambar asli
            currentImage = new Bitmap(originalImage);
            pictureBoxMain.Image = currentImage;
        }
    }
}