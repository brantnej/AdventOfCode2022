using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Tree
    {
        public int Height;
        public int MaxTop;
        public int MaxBottom;
        public int MaxLeft;
        public int MaxRight;
        public int VisibleTop;
        public int VisibleBottom;
        public int VisibleLeft;
        public int VisibleRight;
        public int ScenicScore { get => VisibleBottom * VisibleLeft * VisibleRight * VisibleTop; }
    };
}
