using System;
using System.Drawing;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk filter warna dasar:
    /// - Channel RGB (Red, Green, Blue)
    /// - Grayscale
    /// - Threshold (Binary)
    /// - Negative
    /// - Brightness
    /// </summary>
    public static class FilterService
    {
        #region Channel Filters

        /// <summary>
        /// Filter Red Channel - hanya tampilkan komponen merah
        /// </summary>
        public static byte[,,] RedChannel(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) => (r, (byte)0, (byte)0));
        }

        /// <summary>
        /// Filter Green Channel - hanya tampilkan komponen hijau
        /// </summary>
        public static byte[,,] GreenChannel(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) => ((byte)0, g, (byte)0));
        }

        /// <summary>
        /// Filter Blue Channel - hanya tampilkan komponen biru
        /// </summary>
        public static byte[,,] BlueChannel(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) => ((byte)0, (byte)0, b));
        }

        #endregion

        #region Grayscale & Threshold

        /// <summary>
        /// Convert ke Grayscale
        /// </summary>
        public static byte[,,] Grayscale(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) =>
            {
                byte gray = (byte)MathHelper.ToGrayscale(r, g, b);
                return (gray, gray, gray);
            });
        }

        /// <summary>
        /// Convert ke Threshold (Binary: hitam putih)
        /// </summary>
        public static byte[,,] Threshold(byte[,,] source, int width, int height, int thresholdValue = 128)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) =>
            {
                int gray = MathHelper.ToGrayscale(r, g, b);
                byte val = (byte)(gray > thresholdValue ? 255 : 0);
                return (val, val, val);
            });
        }

        #endregion

        #region Negative & Brightness

        /// <summary>
        /// Negative/Invert - balik warna
        /// </summary>
        public static byte[,,] Negative(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) =>
            {
                // Negative dari grayscale
                byte gray = (byte)MathHelper.ToGrayscale(r, g, b);
                byte inv = (byte)(255 - gray);
                return (inv, inv, inv);
            });
        }

        /// <summary>
        /// Negative RGB - balik setiap channel warna
        /// </summary>
        public static byte[,,] NegativeRGB(byte[,,] source, int width, int height)
        {
            return ApplyChannelFilter(source, width, height, (r, g, b) =>
            {
                return ((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
            });
        }

        /// <summary>
        /// Adjust Brightness - tambah/kurang kecerahan
        /// </summary>
        public static byte[,,] Brightness(byte[,,] source, int width, int height, int brightnessValue)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x, 0] = (byte)MathHelper.Clamp(source[y, x, 0] + brightnessValue, 0, 255);
                    result[y, x, 1] = (byte)MathHelper.Clamp(source[y, x, 1] + brightnessValue, 0, 255);
                    result[y, x, 2] = (byte)MathHelper.Clamp(source[y, x, 2] + brightnessValue, 0, 255);
                }
            });

            return result;
        }

        #endregion

        #region Apply Filter by Name

        /// <summary>
        /// Apply filter berdasarkan nama
        /// </summary>
        public static byte[,,] ApplyByName(byte[,,] source, int width, int height, string filterName, int thresholdValue = 128)
        {
            switch (filterName)
            {
                case "Red":
                    return RedChannel(source, width, height);
                case "Green":
                    return GreenChannel(source, width, height);
                case "Blue":
                    return BlueChannel(source, width, height);
                case "Gray":
                    return Grayscale(source, width, height);
                case "Threshold":
                    return Threshold(source, width, height, thresholdValue);
                case "Negative":
                    return Negative(source, width, height);
                default:
                    return source;
            }
        }

        #endregion

        #region Private Helper

        /// <summary>
        /// Template method untuk apply filter per pixel dengan multithreading
        /// </summary>
        private static byte[,,] ApplyChannelFilter(
            byte[,,] source,
            int width,
            int height,
            Func<byte, byte, byte, (byte r, byte g, byte b)> filterFunc)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    byte r = source[y, x, 0];
                    byte g = source[y, x, 1];
                    byte b = source[y, x, 2];

                    var (newR, newG, newB) = filterFunc(r, g, b);

                    result[y, x, 0] = newR;
                    result[y, x, 1] = newG;
                    result[y, x, 2] = newB;
                }
            });

            return result;
        }

        #endregion
    }
}
