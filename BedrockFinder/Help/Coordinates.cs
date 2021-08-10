using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder
{
    public class Coordinates
    {
        public int x { get; set; }
        public int z { get; set; }
    }

    public class BlockCoord
    {
        public bool block { get; set; }
        public Coordinates coordinates { get; set; }
    }
}
