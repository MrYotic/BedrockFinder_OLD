using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder
{
    public class Coordinates
    {
        int x { get; set; }
        byte y { get; set; }
        int z { get; set; }
    }

    public class BlockCoord
    {
        char block { get; set; }
        Coordinates coordinates { get; set; }
    }
}
