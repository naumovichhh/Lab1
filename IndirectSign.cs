using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class IndirectSign
    {
        private const int sequenceSize = 100000;
        private RandomGenerator generator;
        private double frequency;
        private double difference;

        public IndirectSign(ulong startNumber, ulong multiplier, ulong module)
        {
            generator = new RandomGenerator(startNumber, multiplier, module);
        }

        public void Calculate()
        {
            int conditionSatisfyCount = 0;
            for (int i = 0; i < sequenceSize / 2; ++i)
            {
                double x1, x2;
                x1 = generator.Next();
                x2 = generator.Next();
                if (x1 * x1 + x2 * x2 < 1)
                {
                    conditionSatisfyCount++;
                }
            }

            frequency = (double)conditionSatisfyCount * 2 / sequenceSize;
            difference = frequency - Math.PI / 4;
        }

        public void Show()
        {
            var windowIndirectSign = new WindowIndirectSign();
            windowIndirectSign.frequencyText.Text = "Частота попадания точки в четверть круга: " + frequency.ToString();
            windowIndirectSign.differenceText.Text = "Частота - π/4: " + difference;
            windowIndirectSign.Show();
        }
    }
}
