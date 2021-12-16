using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Period
    {
        private const int v = 1000000;
        private int period;
        private int aperiodicity;
        private ulong startNumber, multiplier, module;

        public Period(ulong startNumber, ulong multiplier, ulong module)
        {
            this.startNumber = startNumber;
            this.multiplier = multiplier;
            this.module = module;
        }

        public void Calculate()
        {
            double xv = GetXv();
            period = GetPeriod(xv);
            aperiodicity = GetAperiodicity(period);
        }

        public void Show()
        {
            var window = new WindowPeriod();
            window.periodText.Text = "Длина периода: " + period;
            window.aperiodicityText.Text = "Длина участка апериодичности: " + aperiodicity;
            window.Show();
        }

        private int GetAperiodicity(int period)
        {
            RandomGenerator generator0, generatorP;
            generatorP = new RandomGenerator(startNumber, multiplier, module);
            for (int i = 1; i <= period; ++i)
                generatorP.Next();

            int j;
            generator0 = new RandomGenerator(startNumber, multiplier, module);
            double xi3 = generator0.Current;
            double xi3p = generatorP.Current;
            if (xi3 == xi3p)
                return period;

            for (j = 1; ; ++j)
            {
                xi3 = generator0.Next();
                xi3p = generatorP.Next();
                if (xi3 == xi3p)
                    return j + period;
            }
        }

        private double GetXv()
        {
            RandomGenerator generator = new RandomGenerator(startNumber, multiplier, module);
            for (int i = 0; i < v - 1; ++i)
                generator.Next();
            return generator.Next();
        }

        private int GetPeriod(double xv)
        {
            RandomGenerator generator = new RandomGenerator(startNumber, multiplier, module);
            int i1, i2;
            double xi1, xi2;
            generator.Reset();
            for (i1 = 1; (xi1 = generator.Next()) != xv; ++i1)
                ;
            for (i2 = i1 + 1; (xi2 = generator.Next()) != xv; ++i2)
                ;
            return i2 - i1;
        }
    }
}
