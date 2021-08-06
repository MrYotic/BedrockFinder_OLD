using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder
{
    internal class BedrockGen
    {
        internal static long rawSeedFromChunk(int x, int z) //chunk coordinates
        {            
            return (((long)x * (long)341873128712 + (long)z * (long)132897987541) ^ (long)0x5DEECE66D) & ((((long)1 << 48) - 1));
        }

        internal static int rand5(long raw_seed, long a, long b)
        {
            return (int)((((raw_seed * a + b) & (((long)1 << 48) - 1)) >> 17) % ((long)5));
        }

        internal static int precompChunkIndCalcNormal(int x, int y, int z, bool nether)
        {
            return ((z * 16 + x) * (nether ? 8 : 4) + ((nether ? 7 : 3) - y));
        }

        internal static bool bedrockOverworld112(int x, int y, int z)
        {
            if (y == 0) return true;
            if (y < 0 || y > 4) return false;

            int precomp_ind = precompChunkIndCalcNormal(x & 15, y - 1, z & 15, false);

            return rand5(rawSeedFromChunk(x >> 4, z >> 4), Vars.A_OW_112[precomp_ind], Vars.B_OW_112[precomp_ind]) >= y;
        }
    }
}
