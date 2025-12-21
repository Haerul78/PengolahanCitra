using System;
using System.Drawing;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk operasi aritmatika antar gambar:
    /// - Add (penjumlahan)
    /// - Subtract (pengurangan)
    /// - Multiply (perkalian)
    /// - Divide (pembagian)
    /// - Blend (campuran dengan alpha)
    /// </summary>
    public static class ArithmeticService
    {
        #region Add (Penjumlahan)

        /// <summary>
        /// Penjumlahan dua gambar: result = img1 + img2
        /// </summary>
        public static byte[,,] Add(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => MathHelper.Clamp(a + b, 0, 255));
        }

        /// <summary>
        /// Penjumlahan dengan konstanta: result = img + value
        /// </summary>
        public static byte[,,] AddConstant(byte[,,] source, int width, int height, int value)
        {
            return ApplyConstant(source, width, height, v => MathHelper.Clamp(v + value, 0, 255));
        }

        #endregion

        #region Subtract (Pengurangan)

        /// <summary>
        /// Pengurangan dua gambar: result = img1 - img2
        /// </summary>
        public static byte[,,] Subtract(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => MathHelper.Clamp(a - b, 0, 255));
        }

        /// <summary>
        /// Pengurangan dengan konstanta: result = img - value
        /// </summary>
        public static byte[,,] SubtractConstant(byte[,,] source, int width, int height, int value)
        {
            return ApplyConstant(source, width, height, v => MathHelper.Clamp(v - value, 0, 255));
        }

        #endregion

        #region Multiply (Perkalian)

        /// <summary>
        /// Perkalian dua gambar: result = (img1 * img2) / 255
        /// Normalisasi dengan 255 agar hasil tetap dalam range 0-255
        /// </summary>
        public static byte[,,] Multiply(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => MathHelper.Clamp((a * b) / 255, 0, 255));
        }

        /// <summary>
        /// Perkalian dengan konstanta (scaling): result = img * factor
        /// </summary>
        public static byte[,,] MultiplyConstant(byte[,,] source, int width, int height, double factor)
        {
            return ApplyConstant(source, width, height, v => MathHelper.Clamp((int)(v * factor), 0, 255));
        }

        #endregion

        #region Divide (Pembagian)

        /// <summary>
        /// Pembagian dua gambar: result = (img1 / img2) * 255
        /// Normalisasi dengan 255 agar hasil visible
        /// </summary>
        public static byte[,,] Divide(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) =>
            {
                if (b == 0) return a; // Hindari division by zero
                return MathHelper.Clamp((a * 255) / b, 0, 255);
            });
        }

        /// <summary>
        /// Pembagian dengan konstanta: result = img / divisor
        /// </summary>
        public static byte[,,] DivideConstant(byte[,,] source, int width, int height, int divisor)
        {
            if (divisor == 0) divisor = 1;
            return ApplyConstant(source, width, height, v => MathHelper.Clamp(v / divisor, 0, 255));
        }

        #endregion

        #region Blend (Campuran dengan Alpha)

        /// <summary>
        /// Blend dua gambar dengan alpha: result = img1 * alpha + img2 * (1 - alpha)
        /// </summary>
        /// <param name="alpha">Nilai 0.0 sampai 1.0 (0 = 100% img2, 1 = 100% img1)</param>
        public static byte[,,] Blend(byte[,,] img1, byte[,,] img2, int width, int height, double alpha)
        {
            alpha = MathHelper.Clamp(alpha, 0.0, 1.0);
            double beta = 1.0 - alpha;

            return ApplyOperation(img1, img2, width, height, (a, b) =>
            {
                return MathHelper.Clamp((int)(a * alpha + b * beta), 0, 255);
            });
        }

        #endregion

        #region Difference (Absolute)

        /// <summary>
        /// Selisih absolut: result = |img1 - img2|
        /// Berguna untuk motion detection
        /// </summary>
        public static byte[,,] Difference(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => Math.Abs(a - b));
        }

        #endregion

        #region Logical Operations (AND, OR, XOR)

        /// <summary>
        /// Bitwise AND: result = img1 AND img2
        /// </summary>
        public static byte[,,] BitwiseAnd(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => a & b);
        }

        /// <summary>
        /// Bitwise OR: result = img1 OR img2
        /// </summary>
        public static byte[,,] BitwiseOr(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => a | b);
        }

        /// <summary>
        /// Bitwise XOR: result = img1 XOR img2
        /// </summary>
        public static byte[,,] BitwiseXor(byte[,,] img1, byte[,,] img2, int width, int height)
        {
            return ApplyOperation(img1, img2, width, height, (a, b) => a ^ b);
        }

        /// <summary>
        /// Bitwise NOT: result = NOT img (invert)
        /// </summary>
        public static byte[,,] BitwiseNot(byte[,,] source, int width, int height)
        {
            return ApplyConstant(source, width, height, v => 255 - v);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Template untuk operasi antar dua gambar
        /// </summary>
        private static byte[,,] ApplyOperation(
            byte[,,] img1,
            byte[,,] img2,
            int width,
            int height,
            Func<int, int, int> operation)
        {
            if (img1 == null || img2 == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    // Clamp koordinat untuk img2 jika ukuran berbeda
                    int x2 = Math.Min(x, img2.GetLength(1) - 1);
                    int y2 = Math.Min(y, img2.GetLength(0) - 1);

                    result[y, x, 0] = (byte)operation(img1[y, x, 0], img2[y2, x2, 0]);
                    result[y, x, 1] = (byte)operation(img1[y, x, 1], img2[y2, x2, 1]);
                    result[y, x, 2] = (byte)operation(img1[y, x, 2], img2[y2, x2, 2]);
                }
            });

            return result;
        }

        /// <summary>
        /// Template untuk operasi dengan konstanta
        /// </summary>
        private static byte[,,] ApplyConstant(
            byte[,,] source,
            int width,
            int height,
            Func<int, int> operation)
        {
            if (source == null) return null;

            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x, 0] = (byte)operation(source[y, x, 0]);
                    result[y, x, 1] = (byte)operation(source[y, x, 1]);
                    result[y, x, 2] = (byte)operation(source[y, x, 2]);
                }
            });

            return result;
        }

        #endregion
    }
}
