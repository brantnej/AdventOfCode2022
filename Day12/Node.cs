using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Node
    {
        public char Height { get; set; }
        public bool Visited { get; set; } = false;
        public bool Start { get; set; } = false;
        public bool End { get; set; } = false;
        public int Distance { get; set; } = 0;
        public int XCoord { get; set; }
        public int YCoord { get; set; }
    }
}
