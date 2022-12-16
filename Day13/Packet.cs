using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Packet
    {
        public List<Packet> Subpackets { get; set; }= new List<Packet>();
        public bool IsInteger { get; set; }
        public int Value { get; set; }
        public bool IsDivider { get; set; } = false;
    }
}
