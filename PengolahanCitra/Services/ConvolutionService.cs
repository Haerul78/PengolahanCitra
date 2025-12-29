using System;
using System.Threading.Tasks;
using PengolahanCitra.Helpers;

namespace PengolahanCitra.Services
{
    /// <summary>
    /// Service untuk operasi konvolusi dengan kernel 3x3
    /// - Gaussian Blur
    /// - Sharpen
    /// - Edge Detection (Roberts, Prewitt, Sobel, Canny)
    /// - Custom Kernel
    /// Semua operasi menggunakan multithreading (Parallel.For)
    /// </summary>
    public static class ConvolutionService
    {
        #region Predefined Kernels 3x3

        public static readonly int[,] KERNEL_GAUSSIAN = {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };
        public const int DIVISOR_GAUSSIAN = 16;

        public static readonly int[,] KERNEL_SHARPEN_SOFT = {
            {  0, -1,  0 },
            { -1,  5, -1 },
            {  0, -1,  0 }
        };

        public static readonly int[,] KERNEL_SHARPEN_STRONG = {
            { -1, -1, -1 },
            { -1,  9, -1 },
            { -1, -1, -1 }
        };

        public static readonly int[,] KERNEL_EDGE_LAPLACIAN = {
            {  0, -1,  0 },
            { -1,  4, -1 },
            {  0, -1,  0 }
        };

        public static readonly int[,] KERNEL_EMBOSS = {
            { -2, -1, 0 },
            { -1,  1, 1 },
            {  0,  1, 2 }
        };

        public static readonly int[,] KERNEL_MEAN = {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
        public const int DIVISOR_MEAN = 9;

        #endregion

        #region Edge Detection Kernels

        // Roberts Cross Kernels (2x2 tapi kita pakai 3x3 dengan padding)
        public static readonly int[,] KERNEL_ROBERTS_X = {
            { 1,  0, 0 },
            { 0, -1, 0 },
            { 0,  0, 0 }
        };

        public static readonly int[,] KERNEL_ROBERTS_Y = {
            { 0, 1, 0 },
            { -1, 0, 0 },
            { 0, 0, 0 }
        };

        // Prewitt Kernels
        public static readonly int[,] KERNEL_PREWITT_X = {
            { -1, 0, 1 },
            { -1, 0, 1 },
            { -1, 0, 1 }
        };

        public static readonly int[,] KERNEL_PREWITT_Y = {
            { -1, -1, -1 },
            {  0,  0,  0 },
            {  1,  1,  1 }
        };

        // Sobel Kernels
        public static readonly int[,] KERNEL_SOBEL_X = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        public static readonly int[,] KERNEL_SOBEL_Y = {
            { -1, -2, -1 },
            {  0,  0,  0 },
            {  1,  2,  1 }
        };

        #endregion

        #region Main Convolution Method

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

        public static byte[,,] EdgeDetection(byte[,,] source, int width, int height)
        {
            return Convolve(source, KERNEL_EDGE_LAPLACIAN, width, height, divisor: 1, offset: 128);
        }

        public static byte[,,] Emboss(byte[,,] source, int width, int height)
        {
            return Convolve(source, KERNEL_EMBOSS, width, height, divisor: 1, offset: 128);
        }

        #endregion

        #region Roberts Edge Detection

        /// <summary>
        /// Roberts Cross Edge Detection
        /// Mendeteksi tepi dengan kernel 2x2 (diagonal)
        /// Cocok untuk mendeteksi tepi dengan resolusi rendah
        /// </summary>
        public static byte[,,] EdgeRoberts(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            // Convert ke grayscale dulu
            byte[,] gray = ToGrayscale(source, width, height);
            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    // Roberts Cross operator
                    int gx = 0, gy = 0;

                    // Gx = P(x,y) - P(x+1,y+1)
                    int nx1 = MathHelper.ClampIndex(x + 1, width);
                    int ny1 = MathHelper.ClampIndex(y + 1, height);
                    gx = gray[y, x] - gray[ny1, nx1];

                    // Gy = P(x+1,y) - P(x,y+1)
                    gy = gray[y, nx1] - gray[ny1, x];

                    // Magnitude
                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    byte value = (byte)MathHelper.Clamp(magnitude, 0, 255);

                    result[y, x, 0] = value;
                    result[y, x, 1] = value;
                    result[y, x, 2] = value;
                }
            });

            return result;
        }

        #endregion

        #region Prewitt Edge Detection

        /// <summary>
        /// Prewitt Edge Detection
        /// Menggunakan kernel 3x3 untuk mendeteksi tepi horizontal dan vertikal
        /// Lebih halus dari Sobel
        /// </summary>
        public static byte[,,] EdgePrewitt(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            byte[,] gray = ToGrayscale(source, width, height);
            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int gx = 0, gy = 0;

                    // Apply Prewitt kernels
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int ny = MathHelper.ClampIndex(y + ky, height);
                            int nx = MathHelper.ClampIndex(x + kx, width);

                            int pixelValue = gray[ny, nx];

                            gx += pixelValue * KERNEL_PREWITT_X[ky + 1, kx + 1];
                            gy += pixelValue * KERNEL_PREWITT_Y[ky + 1, kx + 1];
                        }
                    }

                    // Magnitude
                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    byte value = (byte)MathHelper.Clamp(magnitude, 0, 255);

                    result[y, x, 0] = value;
                    result[y, x, 1] = value;
                    result[y, x, 2] = value;
                }
            });

            return result;
        }

        #endregion

        #region Sobel Edge Detection

        /// <summary>
        /// Sobel Edge Detection
        /// Menggunakan kernel 3x3 dengan bobot lebih besar di tengah
        /// Lebih sensitif terhadap tepi diagonal
        /// </summary>
        public static byte[,,] EdgeSobel(byte[,,] source, int width, int height)
        {
            if (source == null) return null;

            byte[,] gray = ToGrayscale(source, width, height);
            var result = new byte[height, width, 3];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int gx = 0, gy = 0;

                    // Apply Sobel kernels
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int ny = MathHelper.ClampIndex(y + ky, height);
                            int nx = MathHelper.ClampIndex(x + kx, width);

                            int pixelValue = gray[ny, nx];

                            gx += pixelValue * KERNEL_SOBEL_X[ky + 1, kx + 1];
                            gy += pixelValue * KERNEL_SOBEL_Y[ky + 1, kx + 1];
                        }
                    }

                    // Magnitude
                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    byte value = (byte)MathHelper.Clamp(magnitude, 0, 255);

                    result[y, x, 0] = value;
                    result[y, x, 1] = value;
                    result[y, x, 2] = value;
                }
            });

            return result;
        }

        #endregion

        #region Canny Edge Detection

        /// <summary>
        /// Canny Edge Detection (Simplified)
        /// 5 tahap: Gaussian Blur -> Gradient -> Non-Max Suppression -> Double Threshold -> Hysteresis
        /// Menghasilkan tepi yang tipis dan bersih
        /// </summary>
        public static byte[,,] EdgeCanny(byte[,,] source, int width, int height, int lowThreshold = 50, int highThreshold = 150)
        {
            if (source == null) return null;

            // Step 1: Gaussian Blur untuk mengurangi noise
            byte[,,] blurred = GaussianBlur(source, width, height, 2);

            // Step 2: Convert ke grayscale
            byte[,] gray = ToGrayscale(blurred, width, height);

            // Step 3: Hitung gradient menggunakan Sobel
            double[,] gradientMagnitude = new double[height, width];
            double[,] gradientDirection = new double[height, width];

            Parallel.For(1, height - 1, y =>
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int gx = 0, gy = 0;

                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int pixelValue = gray[y + ky, x + kx];
                            gx += pixelValue * KERNEL_SOBEL_X[ky + 1, kx + 1];
                            gy += pixelValue * KERNEL_SOBEL_Y[ky + 1, kx + 1];
                        }
                    }

                    gradientMagnitude[y, x] = Math.Sqrt(gx * gx + gy * gy);
                    gradientDirection[y, x] = Math.Atan2(gy, gx) * 180.0 / Math.PI;
                }
            });

            // Step 4: Non-Maximum Suppression
            byte[,] suppressed = NonMaxSuppression(gradientMagnitude, gradientDirection, width, height);

            // Step 5: Double Thresholding
            byte[,] thresholded = DoubleThreshold(suppressed, width, height, lowThreshold, highThreshold);

            // Step 6: Hysteresis (Edge Tracking)
            byte[,] edges = Hysteresis(thresholded, width, height);

            // Convert ke RGB
            var result = new byte[height, width, 3];
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x, 0] = edges[y, x];
                    result[y, x, 1] = edges[y, x];
                    result[y, x, 2] = edges[y, x];
                }
            });

            return result;
        }

        /// <summary>
        /// Non-Maximum Suppression untuk menipiskan tepi
        /// </summary>
        private static byte[,] NonMaxSuppression(double[,] magnitude, double[,] direction, int width, int height)
        {
            byte[,] result = new byte[height, width];

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double angle = direction[y, x];
                    if (angle < 0) angle += 180;

                    double q = 255, r = 255;

                    // Angle 0 (horizontal)
                    if ((angle >= 0 && angle < 22.5) || (angle >= 157.5 && angle <= 180))
                    {
                        q = magnitude[y, x + 1];
                        r = magnitude[y, x - 1];
                    }
                    // Angle 45 (diagonal)
                    else if (angle >= 22.5 && angle < 67.5)
                    {
                        q = magnitude[y + 1, x - 1];
                        r = magnitude[y - 1, x + 1];
                    }
                    // Angle 90 (vertical)
                    else if (angle >= 67.5 && angle < 112.5)
                    {
                        q = magnitude[y + 1, x];
                        r = magnitude[y - 1, x];
                    }
                    // Angle 135 (diagonal)
                    else if (angle >= 112.5 && angle < 157.5)
                    {
                        q = magnitude[y - 1, x - 1];
                        r = magnitude[y + 1, x + 1];
                    }

                    if (magnitude[y, x] >= q && magnitude[y, x] >= r)
                    {
                        result[y, x] = (byte)MathHelper.Clamp((int)magnitude[y, x], 0, 255);
                    }
                    else
                    {
                        result[y, x] = 0;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Double Threshold untuk klasifikasi tepi
        /// </summary>
        private static byte[,] DoubleThreshold(byte[,] source, int width, int height, int lowThreshold, int highThreshold)
        {
            byte[,] result = new byte[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int pixel = source[y, x];

                    if (pixel >= highThreshold)
                    {
                        result[y, x] = 255; // Strong edge
                    }
                    else if (pixel >= lowThreshold)
                    {
                        result[y, x] = 128; // Weak edge
                    }
                    else
                    {
                        result[y, x] = 0; // Not edge
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Hysteresis untuk menghubungkan weak edges dengan strong edges
        /// </summary>
        private static byte[,] Hysteresis(byte[,] source, int width, int height)
        {
            byte[,] result = new byte[height, width];
            Array.Copy(source, result, source.Length);

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    if (result[y, x] == 128) // Weak edge
                    {
                        // Check if connected to strong edge
                        bool connected = false;
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            for (int kx = -1; kx <= 1; kx++)
                            {
                                if (result[y + ky, x + kx] == 255)
                                {
                                    connected = true;
                                    break;
                                }
                            }
                            if (connected) break;
                        }

                        result[y, x] = connected ? (byte)255 : (byte)0;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Mean Filter (Box Blur)

        public static byte[,,] MeanBlur(byte[,,] source, int width, int height, int passes = 1)
        {
            if (source == null) return null;

            passes = MathHelper.Clamp(passes, 1, 20);
            byte[,,] result = source;

            for (int i = 0; i < passes; i++)
            {
                result = Convolve(result, KERNEL_MEAN, width, height, DIVISOR_MEAN);
            }

            return result;
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

        /// <summary>
        /// Convert RGB ke Grayscale
        /// </summary>
        private static byte[,] ToGrayscale(byte[,,] source, int width, int height)
        {
            byte[,] gray = new byte[height, width];

            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    // Luminance formula
                    gray[y, x] = (byte)(0.299 * source[y, x, 0] + 0.587 * source[y, x, 1] + 0.114 * source[y, x, 2]);
                }
            });

            return gray;
        }

        #endregion
    }
}
