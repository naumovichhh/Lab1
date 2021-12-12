using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RandomGenerator
    {
        private readonly ulong module;
        private readonly ulong multiplier;
        private ulong currentNumber;

        public RandomGenerator(ulong startNumber, ulong module, ulong multiplier)
        {
            currentNumber = startNumber;
            this.module = module;
            this.multiplier = multiplier;
        }

        public double Next()
        {
            currentNumber = currentNumber * multiplier % module;
            return (double)currentNumber / (double)module;
        }
    }
}
