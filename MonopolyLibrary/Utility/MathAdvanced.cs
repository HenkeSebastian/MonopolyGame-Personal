using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility
{
    public static class MathAdvanced
    {
        public static int Max(int x, int y, int z)
        {
            return Math.Max(x, Math.Max(y, z));
        }

        public static int Min(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }
    }
}
