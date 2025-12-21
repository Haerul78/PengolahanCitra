using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PengolahanCitra.Helpers
{
    /// <summary>
    /// Helper untuk operasi dasar gambar:
    /// - Konversi Bitmap <-> Matrix
    /// - Load & Save gambar
    /// - Thumbnail
    /// </summary>
    public static class ImageHelper
    {
        #region Bitmap <-> Matrix Conversion

        /// <summary>
        /// Convert Bitmap ke RGB Matrix [height, width, 3]
        /// </summary>
        public static byte[,,] BitmapToRgbMatrix(Bitmap image)
        {
            if (image == null) return null;

            int width = image.Width;
            int height = image.Height;
            byte[,,] matrix = new byte[height, width, 3];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    matrix[y, x, 0] = pixel.R;
                    matrix[y, x, 1] = pixel.G;
                    matrix[y, x, 2] = pixel.B;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Convert Bitmap ke Grayscale Matrix [height, width]
        /// </summary>
        public static byte[,] BitmapToGrayMatrix(Bitmap image)
        {
            if (image == null) return null;

            int width = image.Width;
            int height = image.Height;
            byte[,] matrix = new byte[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    matrix[y, x] = (byte)MathHelper.ToGrayscale(pixel.R, pixel.G, pixel.B);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Convert RGB Matrix ke Bitmap
        /// </summary>
        public static Bitmap RgbMatrixToBitmap(byte[,,] matrix)
        {
            if (matrix == null) return null;

            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = Color.FromArgb(
                        matrix[y, x, 0],
                        matrix[y, x, 1],
                        matrix[y, x, 2]
                    );
                    result.SetPixel(x, y, c);
                }
            }

            return result;
        }

        /// <summary>
        /// Convert Grayscale Matrix ke Bitmap
        /// </summary>
        public static Bitmap GrayMatrixToBitmap(byte[,] matrix)
        {
            if (matrix == null) return null;

            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte gray = matrix[y, x];
                    result.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return result;
        }

        #endregion

        #region Load & Save

        /// <summary>
        /// Load gambar dari file path
        /// </summary>
        public static Bitmap LoadImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            return new Bitmap(filePath);
        }

        /// <summary>
        /// Save gambar ke file
        /// </summary>
        public static void SaveImage(Bitmap image, string filePath)
        {
            if (image == null || string.IsNullOrEmpty(filePath))
                return;

            ImageFormat format = GetImageFormat(filePath);
            image.Save(filePath, format);
        }

        /// <summary>
        /// Tentukan format gambar dari extension file
        /// </summary>
        public static ImageFormat GetImageFormat(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLowerInvariant();

            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Png;
            }
        }

        #endregion

        #region Thumbnail & Resize

        /// <summary>
        /// Buat thumbnail dengan ukuran tertentu
        /// </summary>
        public static Bitmap CreateThumbnail(Bitmap source, int size)
        {
            if (source == null) return null;

            Bitmap thumb = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(thumb))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, size, size);
            }

            return thumb;
        }

        /// <summary>
        /// Resize gambar dengan persentase zoom
        /// </summary>
        public static Bitmap Resize(Bitmap source, int zoomPercent)
        {
            if (source == null) return null;

            int newWidth = source.Width * zoomPercent / 100;
            int newHeight = source.Height * zoomPercent / 100;

            Bitmap result = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, newWidth, newHeight);
            }

            return result;
        }

        #endregion

        #region Clone & Copy

        /// <summary>
        /// Clone bitmap (deep copy)
        /// </summary>
        public static Bitmap Clone(Bitmap source)
        {
            if (source == null) return null;
            return new Bitmap(source);
        }

        /// <summary>
        /// Clone RGB matrix (deep copy)
        /// </summary>
        public static byte[,,] CloneMatrix(byte[,,] source)
        {
            if (source == null) return null;
            return (byte[,,])source.Clone();
        }

        #endregion
    }
}
