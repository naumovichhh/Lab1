using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace Lab1
{
    internal class ChartAndCharacteristics
    {
        private const int intervalCount = 20;
        private const int sequenceSize = 100000;
        private double expectedValue;
        private double dispersion;
        private double squareDeviation;
        private double xMin = double.MaxValue, xMax = double.MinValue;
        private double[] columns = new double[20];
        private double[] sequence = new double[sequenceSize];
        private RandomGenerator generator;

        public ChartAndCharacteristics(ulong startNumber, ulong multiplier, ulong module)
        {
            this.generator = new RandomGenerator(startNumber, multiplier, module);
        }

        public void Calculate()
        {
            for (int i = 1; i <= sequenceSize; ++i)
            {
                var val = generator.Next();
                var oldExpectedValue = expectedValue;
                expectedValue = oldExpectedValue * (double)(i - 1) / (double)i + val / (double)i;
                if (i > 1)
                {
                    dispersion = dispersion * (double)(i - 2) / (double)(i - 1) + Math.Pow(val - oldExpectedValue, 2) / i;
                }

                if (val > xMax)
                    xMax = val;
                if (val < xMin)
                    xMin = val;

                sequence[i - 1] = val;
            }

            squareDeviation = Math.Sqrt(dispersion);
            CountChartColumns();
        }

        public void Show()
        {
            var windowChart = new WindowChart();
            windowChart.plotView.Model = GetPlotModel();
            windowChart.expectedValueText.Text = "Математическое ожидание: " + expectedValue.ToString();
            windowChart.dispersionText.Text = "Дисперсия: " + dispersion.ToString();
            windowChart.squareDeviationText.Text = "Среднее квадратичное отклонение: " + squareDeviation.ToString();
            windowChart.Show();
        }

        private PlotModel GetPlotModel()
        {
            var model = new PlotModel();
            var series = new BarSeries();
            for (int i = 0; i < columns.Length; ++i)
            {
                series.Items.Add(new BarItem(columns[i], i));
            }
            
            model.Series.Add(series);
            return model;
        }

        private void CountChartColumns()
        {
            var range = xMax - xMin;
            var intervalSize = range / intervalCount;
            for (int i = 0; i < intervalCount; ++i)
            {
                int count = 0;
                double intervalMin = xMin + i * intervalSize;
                double intervalMax = xMin + (i + 1) * intervalSize;
                for (int j = 0; j < sequenceSize; ++j)
                {
                    if (sequence[j] >= intervalMin && sequence[j] < intervalMax)
                    {
                        count++;
                    }
                }

                columns[i] = (double)count / sequenceSize;
            }
        }
    }
}
