using System;
using System.Drawing;
using System.Windows.Forms;

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

                labelImageInfo.Text = $"Gambar: {openFileDialog.SafeFileName} | Ukuran: {currentImage.Width}x{currentImage.Height}px";
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
            labelImageInfo.Text = "Grayscale diterapkan";
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}