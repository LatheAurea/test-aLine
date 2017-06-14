using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFakes
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculate = new Calculator(new Dependency());
            Console.WriteLine("Result Do is {0}.", calculate.Do(0));
            Console.ReadLine();
        }
    }
}
