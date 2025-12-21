using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk transformasi geometri:
    /// - Rotate (putar)
    /// - Flip (cermin)
    /// - Translate (geser)
    /// - Zoom/Scale
    /// </summary>
    public static class GeometryService
    {
        #region Rotation

        /// <summary>
        /// Rotate gambar dengan sudut tertentu (dalam derajat)
        /// </summary>
        public static Bitmap Rotate(Bitmap source, float angleDegrees)
        {
            if (source == null) return null;

            // Hitung ukuran baru setelah rotasi
            double radians = angleDegrees * Math.PI / 180.0;
            double cos = Math.Abs(Math.Cos(radians));
            double sin = Math.Abs(Math.Sin(radians));

            int newWidth = (int)(source.Width * cos + source.Height * sin);
            int newHeight = (int)(source.Width * sin + source.Height * cos);

            Bitmap result = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // Pindahkan origin ke tengah
                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.RotateTransform(angleDegrees);
                g.TranslateTransform(-source.Width / 2f, -source.Height / 2f);

                g.DrawImage(source, 0, 0);
            }

            return result;
        }

        /// <summary>
        /// Rotate dengan sudut preset (90, 180, 270)
        /// </summary>
        public static Bitmap RotatePreset(Bitmap source, RotateFlipType rotateType)
        {
            if (source == null) return null;

            Bitmap result = new Bitmap(source);
            result.RotateFlip(rotateType);
            return result;
        }

        /// <summary>
        /// Rotate 90 derajat searah jarum jam
        /// </summary>
        public static Bitmap Rotate90CW(Bitmap source)
        {
            return RotatePreset(source, RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// Rotate 90 derajat berlawanan jarum jam
        /// </summary>
        public static Bitmap Rotate90CCW(Bitmap source)
        {
            return RotatePreset(source, RotateFlipType.Rotate270FlipNone);
        }

        /// <summary>
        /// Rotate 180 derajat
        /// </summary>
        public static Bitmap Rotate180(Bitmap source)
        {
            return RotatePreset(source, RotateFlipType.Rotate180FlipNone);
        }

        #endregion

        #region Flip (Mirror)

        /// <summary>
        /// Flip horizontal (cermin kiri-kanan)
        /// </summary>
        public static Bitmap FlipHorizontal(Bitmap source)
        {
            if (source == null) return null;

            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Pixel dari kanan dipindah ke kiri
                    Color pixel = source.GetPixel(width - 1 - x, y);
                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }

        /// <summary>
        /// Flip horizontal menggunakan matrix (lebih cepat untuk gambar besar)
        /// </summary>
        public static byte[,,] FlipHorizontalMatrix(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int srcX = width - 1 - x;
                    result[y, x, 0] = source[y, srcX, 0];
                    result[y, x, 1] = source[y, srcX, 1];
                    result[y, x, 2] = source[y, srcX, 2];
                }
            });

            return result;
        }

        /// <summary>
        /// Flip vertical (cermin atas-bawah)
        /// </summary>
        public static Bitmap FlipVertical(Bitmap source)
        {
            if (source == null) return null;

            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Pixel dari bawah dipindah ke atas
                    Color pixel = source.GetPixel(x, height - 1 - y);
                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }

        /// <summary>
        /// Flip vertical menggunakan matrix
        /// </summary>
        public static byte[,,] FlipVerticalMatrix(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                int srcY = height - 1 - y;
                for (int x = 0; x < width; x++)
                {
                    result[y, x, 0] = source[srcY, x, 0];
                    result[y, x, 1] = source[srcY, x, 1];
                    result[y, x, 2] = source[srcY, x, 2];
                }
            });

            return result;
        }

        #endregion

        #region Translate (Shift/Geser)

        /// <summary>
        /// Translate/geser gambar dengan offset X dan Y
        /// Area kosong diisi warna background
        /// </summary>
        public static Bitmap Translate(Bitmap source, int offsetX, int offsetY, Color? backgroundColor = null)
        {
            if (source == null) return null;

            Color bgColor = backgroundColor ?? Color.Black;
            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(bgColor);
                g.DrawImage(source, offsetX, offsetY);
            }

            return result;
        }

        /// <summary>
        /// Translate menggunakan matrix
        /// </summary>
        public static byte[,,] TranslateMatrix(byte[,,] source, int width, int height, int offsetX, int offsetY)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            // Default hitam (0,0,0) - array sudah initialized ke 0

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int srcX = x - offsetX;
                    int srcY = y - offsetY;

                    // Cek apakah posisi sumber valid
                    if (srcX >= 0 && srcX < width && srcY >= 0 && srcY < height)
                    {
                        result[y, x, 0] = source[srcY, srcX, 0];
                        result[y, x, 1] = source[srcY, srcX, 1];
                        result[y, x, 2] = source[srcY, srcX, 2];
                    }
                }
            });

            return result;
        }

        #endregion

        #region Zoom/Scale

        /// <summary>
        /// Zoom/scale gambar dengan persentase
        /// </summary>
        public static Bitmap Zoom(Bitmap source, int zoomPercent)
        {
            if (source == null) return null;

            int newWidth = source.Width * zoomPercent / 100;
            int newHeight = source.Height * zoomPercent / 100;

            if (newWidth <= 0) newWidth = 1;
            if (newHeight <= 0) newHeight = 1;

            Bitmap result = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, newWidth, newHeight);
            }

            return result;
        }

        /// <summary>
        /// Scale gambar ke ukuran tertentu
        /// </summary>
        public static Bitmap Scale(Bitmap source, int newWidth, int newHeight)
        {
            if (source == null) return null;

            Bitmap result = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, newWidth, newHeight);
            }

            return result;
        }

        /// <summary>
        /// Scale dengan mempertahankan aspect ratio
        /// </summary>
        public static Bitmap ScaleToFit(Bitmap source, int maxWidth, int maxHeight)
        {
            if (source == null) return null;

            double ratioX = (double)maxWidth / source.Width;
            double ratioY = (double)maxHeight / source.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(source.Width * ratio);
            int newHeight = (int)(source.Height * ratio);

            return Scale(source, newWidth, newHeight);
        }

        #endregion

        #region Crop

        /// <summary>
        /// Crop gambar dengan rectangle
        /// </summary>
        public static Bitmap Crop(Bitmap source, Rectangle cropArea)
        {
            if (source == null) return null;

            // Validasi area crop
            cropArea.X = MathHelper.Clamp(cropArea.X, 0, source.Width - 1);
            cropArea.Y = MathHelper.Clamp(cropArea.Y, 0, source.Height - 1);
            cropArea.Width = MathHelper.Clamp(cropArea.Width, 1, source.Width - cropArea.X);
            cropArea.Height = MathHelper.Clamp(cropArea.Height, 1, source.Height - cropArea.Y);

            Bitmap result = new Bitmap(cropArea.Width, cropArea.Height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(source, 0, 0, cropArea, GraphicsUnit.Pixel);
            }

            return result;
        }

        #endregion
    }
}
