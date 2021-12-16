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
            int period = GetPeriod(xv);
            int aperiodicity = GetAperiodicity(period);
        }

        public void Show()
        {

        }

        private int GetAperiodicity(int period)
        {
            return 0;
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
