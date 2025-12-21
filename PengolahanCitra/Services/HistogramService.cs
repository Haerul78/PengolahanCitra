using System;
using System.Drawing;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk operasi histogram:
    /// - Histogram Equalization (3 metode)
    /// - Generate histogram image untuk display
    /// </summary>
    public static class HistogramService
    {
        #region Histogram Equalization - Metode 1: Intensity Scaling

        /// <summary>
        /// Histogram Equalization dengan Intensity Scaling
        /// Mempertahankan warna dengan menskala berdasarkan rasio intensitas
        /// </summary>
        public static byte[,,] EqualizeIntensityScaling(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];
            int totalPixels = width * height;

            // Step 1: Hitung histogram intensitas
            int[] histogram = new int[256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int intensity = (source[y, x, 0] + source[y, x, 1] + source[y, x, 2]) / 3;
                    histogram[intensity]++;
                }
            }

            // Step 2: Hitung CDF
            int[] cdf = new int[256];
            cdf[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i];
            }

            // Step 3: Cari CDF minimum
            int cdfMin = FindCdfMin(cdf);

            // Step 4: Buat LUT
            byte[] lut = BuildLUT(cdf, cdfMin, totalPixels);

            // Step 5: Apply dengan multithreading
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    byte r = source[y, x, 0];
                    byte g = source[y, x, 1];
                    byte b = source[y, x, 2];

                    int oldIntensity = (r + g + b) / 3;
                    int newIntensity = lut[oldIntensity];

                    if (oldIntensity == 0)
                    {
                        result[y, x, 0] = (byte)newIntensity;
                        result[y, x, 1] = (byte)newIntensity;
                        result[y, x, 2] = (byte)newIntensity;
                    }
                    else
                    {
                        double ratio = Math.Min((double)newIntensity / oldIntensity, 3.0);

                        result[y, x, 0] = (byte)MathHelper.Clamp((int)(r * ratio), 0, 255);
                        result[y, x, 1] = (byte)MathHelper.Clamp((int)(g * ratio), 0, 255);
                        result[y, x, 2] = (byte)MathHelper.Clamp((int)(b * ratio), 0, 255);
                    }
                }
            });

            return result;
        }

        #endregion

        #region Histogram Equalization - Metode 2: Per Channel

        /// <summary>
        /// Histogram Equalization per channel RGB
        /// Setiap channel di-equalize terpisah
        /// Kontras tinggi, tapi warna bisa berubah
        /// </summary>
        public static byte[,,] EqualizePerChannel(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];
            int totalPixels = width * height;

            // Buat LUT untuk masing-masing channel
            byte[] lutR = BuildChannelLUT(source, width, height, 0, totalPixels);
            byte[] lutG = BuildChannelLUT(source, width, height, 1, totalPixels);
            byte[] lutB = BuildChannelLUT(source, width, height, 2, totalPixels);

            // Apply
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x, 0] = lutR[source[y, x, 0]];
                    result[y, x, 1] = lutG[source[y, x, 1]];
                    result[y, x, 2] = lutB[source[y, x, 2]];
                }
            });

            return result;
        }

        #endregion

        #region Histogram Equalization - Metode 3: Luminance/YUV (RECOMMENDED)

        /// <summary>
        /// Histogram Equalization menggunakan YUV color space
        /// Hanya equalize Y (luminance), warna tetap
        /// INI METODE PALING NATURAL!
        /// </summary>
        public static byte[,,] EqualizeLuminance(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];
            int totalPixels = width * height;

            // Step 1: Convert RGB ke YUV dan hitung histogram Y
            double[,,] yuv = new double[height, width, 3];
            int[] histogramY = new int[256];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double r = source[y, x, 0];
                    double g = source[y, x, 1];
                    double b = source[y, x, 2];

                    // RGB to YUV
                    double yVal = 0.299 * r + 0.587 * g + 0.114 * b;
                    double uVal = -0.147 * r - 0.289 * g + 0.436 * b;
                    double vVal = 0.615 * r - 0.515 * g - 0.100 * b;

                    yuv[y, x, 0] = yVal;
                    yuv[y, x, 1] = uVal;
                    yuv[y, x, 2] = vVal;

                    histogramY[MathHelper.Clamp((int)yVal, 0, 255)]++;
                }
            }

            // Step 2-4: CDF dan LUT untuk Y
            int[] cdf = new int[256];
            cdf[0] = histogramY[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogramY[i];
            }

            int cdfMin = FindCdfMin(cdf);
            double[] lutY = BuildLUTDouble(cdf, cdfMin, totalPixels);

            // Step 5: Apply dan convert balik ke RGB
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int oldY = MathHelper.Clamp((int)yuv[y, x, 0], 0, 255);
                    double newY = lutY[oldY];
                    double u = yuv[y, x, 1];
                    double v = yuv[y, x, 2];

                    // YUV to RGB
                    double newR = newY + 1.140 * v;
                    double newG = newY - 0.395 * u - 0.581 * v;
                    double newB = newY + 2.032 * u;

                    result[y, x, 0] = (byte)MathHelper.Clamp((int)newR, 0, 255);
                    result[y, x, 1] = (byte)MathHelper.Clamp((int)newG, 0, 255);
                    result[y, x, 2] = (byte)MathHelper.Clamp((int)newB, 0, 255);
                }
            });

            return result;
        }

        #endregion

        #region Generate Histogram Image

        /// <summary>
        /// Hitung histogram untuk channel tertentu
        /// </summary>
        public static int[] CalculateHistogram(byte[,,] rgb, byte[,] gray, string channel)
        {
            int[] histogram = new int[256];
            int height = gray.GetLength(0);
            int width = gray.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int value;
                    switch (channel)
                    {
                        case "R": value = rgb[y, x, 0]; break;
                        case "G": value = rgb[y, x, 1]; break;
                        case "B": value = rgb[y, x, 2]; break;
                        case "Gray": value = gray[y, x]; break;
                        default: value = 0; break;
                    }
                    histogram[value]++;
                }
            }

            return histogram;
        }

        /// <summary>
        /// Generate gambar histogram untuk display
        /// </summary>
        public static Bitmap GenerateHistogramImage(int[] histogram, Color color, int width = 220, int height = 90)
        {
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(28, 28, 28));

                // Convert ke log scale untuk visualisasi lebih baik
                double[] logHist = new double[256];
                double maxVal = 0;

                for (int i = 0; i < 256; i++)
                {
                    logHist[i] = Math.Log10(1 + histogram[i]);
                    if (logHist[i] > maxVal) maxVal = logHist[i];
                }

                if (maxVal == 0) return bmp;

                // Draw bars
                using (Pen pen = new Pen(color, 1))
                {
                    for (int i = 0; i < 256; i++)
                    {
                        float x = (float)i * width / 256f;
                        float barHeight = (float)(logHist[i] / maxVal) * (height - 10);

                        if (barHeight > 0)
                        {
                            g.DrawLine(pen, x, height, x, height - barHeight);
                        }
                    }
                }

                // Draw grid line
                using (Pen gridPen = new Pen(Color.FromArgb(50, 50, 50), 1))
                {
                    g.DrawLine(gridPen, 0, height / 2, width, height / 2);
                }

                // Draw border
                using (Pen borderPen = new Pen(Color.FromArgb(60, 60, 60), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);
                }
            }

            return bmp;
        }

        #endregion

        #region Private Helpers

        private static int FindCdfMin(int[] cdf)
        {
            for (int i = 0; i < 256; i++)
            {
                if (cdf[i] > 0) return cdf[i];
            }
            return 0;
        }

        private static byte[] BuildLUT(int[] cdf, int cdfMin, int totalPixels)
        {
            byte[] lut = new byte[256];
            int denominator = Math.Max(totalPixels - cdfMin, 1);

            for (int i = 0; i < 256; i++)
            {
                if (cdf[i] == 0)
                    lut[i] = 0;
                else
                    lut[i] = (byte)MathHelper.Clamp((int)((double)(cdf[i] - cdfMin) / denominator * 255), 0, 255);
            }

            return lut;
        }

        private static double[] BuildLUTDouble(int[] cdf, int cdfMin, int totalPixels)
        {
            double[] lut = new double[256];
            int denominator = Math.Max(totalPixels - cdfMin, 1);

            for (int i = 0; i < 256; i++)
            {
                if (cdf[i] == 0)
                    lut[i] = 0;
                else
                    lut[i] = (double)(cdf[i] - cdfMin) / denominator * 255.0;
            }

            return lut;
        }

        private static byte[] BuildChannelLUT(byte[,,] source, int width, int height, int channel, int totalPixels)
        {
            // Hitung histogram
            int[] histogram = new int[256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    histogram[source[y, x, channel]]++;
                }
            }

            // CDF
            int[] cdf = new int[256];
            cdf[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i];
            }

            return BuildLUT(cdf, FindCdfMin(cdf), totalPixels);
        }

        #endregion
    }
}
