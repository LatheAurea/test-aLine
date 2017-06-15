using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFakes
{
    public class Calculator
    {
        private readonly IDependency _dependency;

        public Calculator(IDependency dependency)
        {
            _dependency = dependency;
        }

        public int Do(int start)
        {
            return _dependency.Do(start);
        }

        public int GetCurrentYear()
        {
            return DateTime.Today.Year;
        }
    }
}
