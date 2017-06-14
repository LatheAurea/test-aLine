using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFakes
{
    public class Dependency : IDependency
    {
        public static int Count
        {
            get { return 10; }
        }

        public int Do(int start)
        {
            for (int i = 0; i < Count; i++)
            {
                start += 1;
            }
            return start;
        }
    }
}
