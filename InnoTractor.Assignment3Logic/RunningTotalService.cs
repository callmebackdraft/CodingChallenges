using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoTractor.Assignment3Logic
{
    public class RunningTotalService : IRunningTotal
    {
        private List<int> _values;

        public RunningTotalService()
        {
           _values = new List<int>();
        }
        public int CheckRunningTotal(int value)
        {
            if(_values.Count() >= 3)
            {
                _values.RemoveAt(0);
            }
            _values.Add(value);
            return _values.Sum();
        }
    }
}
