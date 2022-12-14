using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Monkey
    {
        public int Number { get; set; }
        public Queue<ulong> Items { get; set; } = new Queue<ulong>();
        public Func<ulong, ulong> Operation { get; set; }
        public ulong Divisor { get; set; }
        public int TrueTarget { get; set; }
        public int FalseTarget { get; set; }
        public int TimesInspected { get; set; } = 0;
    }
}
