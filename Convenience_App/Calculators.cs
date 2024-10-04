using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_App
{
    public class Calculators
    {
        private int value1 = 0;
        private int value2 = 0;

        public Calculators(int val1, int val2)
        {
            value1 = val1;
            value2 = val2;
        }

        public int Add()
        {
            return value1 + value2;
        }

        public int Subtract()
        {
            return value1 - value2;
        }

        public int Multiply()
        {
            return value1 * value2;
        }

        public int Divide()
        {
            return value1 / value2;
        }
    }
}
