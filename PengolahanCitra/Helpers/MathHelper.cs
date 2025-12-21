using System;

namespace PengolahanCitra.Helpers
{
    /// <summary>
    /// Helper untuk fungsi-fungsi matematika dasar
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Clamp nilai ke range [min, max]
        /// </summary>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Clamp nilai double ke range [min, max]
        /// </summary>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Clamp index array supaya tidak out of bounds
        /// </summary>
        public static int ClampIndex(int index, int maxExclusive)
        {
            if (index < 0) return 0;
            if (index >= maxExclusive) return maxExclusive - 1;
            return index;
        }

        /// <summary>
        /// Hitung grayscale dari RGB (rata-rata sederhana)
        /// </summary>
        public static int ToGrayscale(int r, int g, int b)
        {
            return (r + g + b) / 3;
        }

        /// <summary>
        /// Hitung grayscale dengan formula luminance (lebih akurat)
        /// </summary>
        public static int ToGrayscaleLuminance(int r, int g, int b)
        {
            return (int)(0.299 * r + 0.587 * g + 0.114 * b);
        }
    }
}
