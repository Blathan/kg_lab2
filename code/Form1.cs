using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Text;

namespace lab_2
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> _loaded;

        private Image<Gray, byte> _gray;

        private Image<Gray, byte> _filtered;

        private readonly float[,] _laplacianKernel = new float[,]{
            { 0, -1, 0},
            { -1, 5, -1},
            { 0, -1, 0}
        };

        private readonly float[,] _unsharpKernel = new float[,]{
            { -1, -1, -1},
            { -1, 9, -1},
            { -1, -1, -1}
        };

        private readonly float[,] _customKernel = new float[,]{
            { -0.1f, -0.1f, -0.1f },
            { -0.1f, 2f, -0.1f },
            { -0.1f, -0.1f, -0.1f }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                var fileName = openPicture.FileName;

                _loaded = new Image<Bgr, byte>(CvInvoke.Imread(fileName));
                _gray = _loaded.Convert<Gray, byte>();
                CvInvoke.Imshow("Loaded", _loaded);
                CvInvoke.WaitKey(0);
                CvInvoke.DestroyAllWindows();
            }
        }

        private void SaveFilteredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savePicture.ShowDialog() == DialogResult.OK)
            {
                var fileName = savePicture.FileName;

                _filtered.Save(fileName);
            }
        }

        private void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (filters.SelectedIndex)
            {
                case 0:
                    // global
                    globalValue.Visible = true;
                    label1.Visible = true;
                    kernel.Visible = false;
                    kernelPrint.Visible = false;
                    blockSize.Visible = false;
                    constant.Visible = false;
                    break;
                case 1:
                    // adaptive
                    kernel.Visible = false;
                    kernelPrint.Visible = false;
                    globalValue.Visible = false;
                    label1.Visible = false;
                    blockSize.Visible = true;
                    constant.Visible = true;
                    break;
                case 2:
                    kernel.Visible = true;
                    kernelPrint.Visible = true;
                    globalValue.Visible = false;
                    label1.Visible = false;
                    blockSize.Visible = false;
                    constant.Visible = false;
                    break;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (filters.SelectedIndex)
            {
                case 1:
                    if (int.TryParse(blockSize.SelectedItem.ToString(), out var s) &&
                        int.TryParse(constant.SelectedItem.ToString(), out var c))
                    {
                        AdaptiveTresholding(s, c);
                    }
                    break;
                case 2:
                    switch (kernel.SelectedIndex)
                    {
                        case 0:
                            HighPassFilter(_laplacianKernel);
                            break;
                        case 1:
                            HighPassFilter(_unsharpKernel);
                            break;
                        case 2:
                            HighPassFilter(_customKernel);
                            break;
                    }
                    break;
                case 3:
                    Otsu();
                    break;
                case 4:
                    Gradient();
                    break;

            }
        }

        private void UpdateScreen()
        {
            if (_loaded != null && _filtered != null)
            {
                CvInvoke.Imshow("Loaded", _loaded);
                CvInvoke.Imshow("Filtered", _filtered);
                CvInvoke.WaitKey(0);
                CvInvoke.DestroyAllWindows();
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"Global value: {globalValue.Value}";
            GlobalTresholding(globalValue.Value);
            UpdateScreen();
        }

        private void GlobalTresholding(int value)
        {
            // Глобальный порог
            var gray = new Mat();
            CvInvoke.CvtColor(_loaded, gray, ColorConversion.Bgr2Gray);
            double maxBinaryValue = 255; // Максимальное значение для бинаризации
            CvInvoke.Threshold(gray, _filtered, value, maxBinaryValue, ThresholdType.Binary);
            UpdateScreen();
        }

        private void AdaptiveTresholding(int kernelSize, int constant)
        {
            double maxValue = 255; // Максимальное значение для бинаризации
            AdaptiveThresholdType adaptiveType = AdaptiveThresholdType.MeanC;
            ThresholdType thresholdType = ThresholdType.Binary;
            CvInvoke.AdaptiveThreshold(_gray, _filtered, maxValue, adaptiveType, thresholdType, kernelSize, constant);
            UpdateScreen();
        }

        private void HighPassFilter(float[,] kernel)
        {
            _filtered = new Image<Gray, byte>(_loaded.Width, _loaded.Height);
            CvInvoke.Filter2D(_gray, _filtered, new Matrix<float>(kernel), new Point(0, 0));
            UpdateScreen();
        }

        private void Otsu()
        {
            var threshhold = CalculateOtsuThreshold(_gray);
            _filtered = _gray.ThresholdBinary(new Gray(threshhold), new Gray(255));
            UpdateScreen();
        }

        private void Kernel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = new StringBuilder();

            switch (kernel.SelectedIndex)
            {
                case 0:
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            result.Append(_laplacianKernel[i, j] + " ");
                        }

                        result.Append(Environment.NewLine);
                    }
                    break;
                case 1:
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            result.Append(_unsharpKernel[i, j] + " ");
                        }

                        result.Append(Environment.NewLine);
                    }
                    break;
                case 2:
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            result.Append(_customKernel[i, j] + " ");
                        }

                        result.Append(Environment.NewLine);
                    }
                    break;
            }

            kernelPrint.Text = result.ToString();
        }

        private void Gradient()
        {
            Image<Gray, byte> threshold = CalculateThreshold(_gray);
            _filtered = threshold;
            UpdateScreen();
        }

        public static Image<Gray, byte> CalculateThreshold(Image<Gray, byte> gray)
        {
            // Вычисление градиентов по горизонтали и вертикали с помощью оператора Собеля
            Image<Gray, float> gradientX = gray.Sobel(1, 0, 3);
            Image<Gray, float> gradientY = gray.Sobel(0, 1, 3);

            // Вычисление абсолютного значения градиента
            Image<Gray, float> gradientMagnitude = gradientX.AbsDiff(gradientY);

            // Нормализация значений градиента в диапазоне [0, 255]
            Image<Gray, byte> normalizedGradient = gradientMagnitude.ConvertScale<byte>(255, 0);

            // Поиск локальных максимумов градиента
            Image<Gray, byte> threshold = normalizedGradient.ThresholdBinaryInv(new Gray(0), new Gray(255));

            return threshold;
        }

        public static byte CalculateOtsuThreshold(Image<Gray, byte> image)
        {
            // Вычисление гистограммы яркости
            int[] histogram = new int[256];
            var pixels = image.Data;

            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    histogram[pixels[i, j, 0]]++;
                }
            }

            // Общее количество пикселей
            int totalPixels = image.Rows * image.Cols;

            // Вычисление суммы яркостей
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += i * histogram[i];
            }

            // Вычисление глобальной дисперсии
            double globalVariance = 0;
            double globalMean = (double)sum / totalPixels;
            double maxVariance = 0;
            byte threshold = 0;

            for (int i = 0; i < 256; i++)
            {
                int backgroundPixels = 0;
                int foregroundPixels = 0;
                int backgroundSum = 0;
                int foregroundSum = 0;

                for (int j = 0; j <= i; j++)
                {
                    backgroundPixels += histogram[j];
                    backgroundSum += j * histogram[j];
                }

                foregroundPixels = totalPixels - backgroundPixels;
                foregroundSum = sum - backgroundSum;

                if (backgroundPixels == 0 || foregroundPixels == 0)
                    continue;

                double backgroundMean = (double)backgroundSum / backgroundPixels;
                double foregroundMean = (double)foregroundSum / foregroundPixels;

                double variance = backgroundPixels * foregroundPixels * Math.Pow(backgroundMean - foregroundMean, 2);
                if (variance > maxVariance)
                {
                    maxVariance = variance;
                    threshold = (byte)i;
                }
            }

            return threshold;
        }
    }
}