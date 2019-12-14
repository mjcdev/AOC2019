using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D08
{
    public class Layer : List<Row>
    {
        public int CountLayer(int value)
        {
            return this.SelectMany(r => r).Count(v => v == value);
        }
    }
}
