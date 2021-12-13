using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace Lab1
{
    internal class ChartAndCharacteristics
    {
        private double expectedValue;
        private double dispersion;
        private double squareDeviation;
        private double[] columns = new double[20];

        public void Calculate()
        {
            Dictionary<ulong, ulong> columns;
            PlotModel plotModel = new PlotModel();

            new WindowChart().Show();
        }

        private void ObserveSequence()
        {

        }
    }
}
