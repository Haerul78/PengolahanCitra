using System;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk operasi konvolusi dengan kernel 3x3
    /// - Gaussian Blur
    /// - Sharpen
    /// - Custom Kernel
    /// Semua operasi menggunakan multithreading (Parallel.For)
    /// </summary>
    public static class ConvolutionService
    {
        #region Predefined Kernels 3x3

        /// <summary>
        /// Gaussian Blur Kernel
        ///   [1  2  1]
        ///   [2  4  2]  ÷ 16
        ///   [1  2  1]
        /// </summary>
        public static readonly int[,] KERNEL_GAUSSIAN = {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };
        public const int DIVISOR_GAUSSIAN = 16;

        /// <summary>
        /// Sharpen Kernel (Halus)
        ///   [ 0  -1   0]
        ///   [-1   5  -1]
        ///   [ 0  -1   0]
        /// </summary>
        public static readonly int[,] KERNEL_SHARPEN_SOFT = {
            {  0, -1,  0 },
            { -1,  5, -1 },
            {  0, -1,  0 }
        };

        /// <summary>
        /// Sharpen Kernel (Kuat)
        ///   [-1  -1  -1]
        ///   [-1   9  -1]
        ///   [-1  -1  -1]
        /// </summary>
        public static readonly int[,] KERNEL_SHARPEN_STRONG = {
            { -1, -1, -1 },
            { -1,  9, -1 },
            { -1, -1, -1 }
        };

        /// <summary>
        /// Edge Detection - Laplacian
        ///   [ 0  -1   0]
        ///   [-1   4  -1]
        ///   [ 0  -1   0]
        /// </summary>
        public static readonly int[,] KERNEL_EDGE_LAPLACIAN = {
            {  0, -1,  0 },
            { -1,  4, -1 },
            {  0, -1,  0 }
        };

        /// <summary>
        /// Emboss Kernel
        ///   [-2  -1   0]
        ///   [-1   1   1]
        ///   [ 0   1   2]
        /// </summary>
        public static readonly int[,] KERNEL_EMBOSS = {
            { -2, -1, 0 },
            { -1,  1, 1 },
            {  0,  1, 2 }
        };

        #endregion

        #region Main Convolution Method

        /// <summary>
        /// Fungsi konvolusi utama dengan kernel 3x3
        /// Menggunakan multithreading untuk performa
        /// </summary>
        /// <param name="source">Matrix RGB sumber [height, width, 3]</param>
        /// <param name="kernel">Kernel 3x3</param>
        /// <param name="width">Lebar gambar</param>
        /// <param name="height">Tinggi gambar</param>
        /// <param name="divisor">Pembagi untuk normalisasi (null = auto calculate)</param>
        /// <param name="offset">Offset nilai (untuk kernel dengan hasil negatif)</param>
        public static byte[,,] Convolve(
            byte[,,] source,
            int[,] kernel,
            int width,
            int height,
            int? divisor = null,
            int offset = 0)
        {
            if (source == null || kernel == null) return null;

            var result = new byte[height, width, 3];

            // Auto-calculate divisor jika tidak diberikan
            int div = divisor ?? CalculateKernelSum(kernel);
            if (div == 0) div = 1;

            // Multithreading per baris
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    // Loop kernel 3x3
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int ny = MathHelper.ClampIndex(y + ky, height);
                            int nx = MathHelper.ClampIndex(x + kx, width);

                            int weight = kernel[ky + 1, kx + 1];

                            sumR += source[ny, nx, 0] * weight;
                            sumG += source[ny, nx, 1] * weight;
                            sumB += source[ny, nx, 2] * weight;
                        }
                    }

                    result[y, x, 0] = (byte)MathHelper.Clamp(sumR / div + offset, 0, 255);
                    result[y, x, 1] = (byte)MathHelper.Clamp(sumG / div + offset, 0, 255);
                    result[y, x, 2] = (byte)MathHelper.Clamp(sumB / div + offset, 0, 255);
                }
            });

            return result;
        }

        #endregion

        #region Gaussian Blur

        /// <summary>
        /// Gaussian Blur dengan pengulangan untuk efek lebih kuat
        /// </summary>
        /// <param name="passes">Jumlah pengulangan (1-20). Makin banyak = makin blur</param>
        public static byte[,,] GaussianBlur(byte[,,] source, int width, int height, int passes = 1)
        {
            if (source == null) return null;

            passes = MathHelper.Clamp(passes, 1, 20);
            byte[,,] result = source;

            for (int i = 0; i < passes; i++)
            {
                result = Convolve(result, KERNEL_GAUSSIAN, width, height, DIVISOR_GAUSSIAN);
            }

            return result;
        }

        #endregion

        #region Sharpen

        /// <summary>
        /// Sharpen dengan pilihan kekuatan
        /// </summary>
        /// <param name="useStrongKernel">true = kernel kuat, false = kernel halus</param>
        /// <param name="passes">Jumlah pengulangan (1-5)</param>
        public static byte[,,] Sharpen(byte[,,] source, int width, int height, bool useStrongKernel = true, int passes = 1)
        {
            if (source == null) return null;

            passes = MathHelper.Clamp(passes, 1, 5);
            int[,] kernel = useStrongKernel ? KERNEL_SHARPEN_STRONG : KERNEL_SHARPEN_SOFT;

            byte[,,] result = source;

            for (int i = 0; i < passes; i++)
            {
                result = Convolve(result, kernel, width, height);
            }

            return result;
        }

        #endregion

        #region Edge Detection & Emboss

        /// <summary>
        /// Edge Detection menggunakan Laplacian
        /// </summary>
        public static byte[,,] EdgeDetection(byte[,,] source, int width, int height)
        {
            return Convolve(source, KERNEL_EDGE_LAPLACIAN, width, height, divisor: 1, offset: 128);
        }

        /// <summary>
        /// Emboss effect
        /// </summary>
        public static byte[,,] Emboss(byte[,,] source, int width, int height)
        {
            return Convolve(source, KERNEL_EMBOSS, width, height, divisor: 1, offset: 128);
        }

        #endregion

        #region Custom Kernel

        /// <summary>
        /// Apply custom kernel 3x3 dari user
        /// </summary>
        public static byte[,,] CustomKernel(byte[,,] source, int[,] kernel, int width, int height, int? divisor = null)
        {
            return Convolve(source, kernel, width, height, divisor);
        }

        /// <summary>
        /// Parse kernel dari array 9 nilai (baris per baris)
        /// Input: [k00, k01, k02, k10, k11, k12, k20, k21, k22]
        /// </summary>
        public static int[,] ParseKernel(int[] values)
        {
            if (values == null || values.Length != 9)
                throw new ArgumentException("Kernel harus memiliki 9 nilai");

            return new int[,]
            {
                { values[0], values[1], values[2] },
                { values[3], values[4], values[5] },
                { values[6], values[7], values[8] }
            };
        }

        #endregion

        #region Helper

        /// <summary>
        /// Hitung total sum kernel untuk normalisasi
        /// </summary>
        private static int CalculateKernelSum(int[,] kernel)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += kernel[i, j];
                }
            }
            return sum;
        }

        #endregion
    }
}
