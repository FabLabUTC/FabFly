using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public static class MathHelper
    {
        public static decimal Clamp(this decimal D, decimal min, decimal max)
        {
            if (D < min) return min;
            if (D > max) return max;
            return D;
        }
        public static decimal Cos(this decimal N) { return (decimal)Math.Cos((double)N); }
        public static decimal Sin(this decimal N) { return (decimal)Math.Sin((double)N); }
        public static decimal Tan(this decimal N) { return (decimal)Math.Tan((double)N); }
        public static decimal Sqrt(this decimal N) { return (decimal)Math.Sqrt((double)N); }
        public static decimal Atan2(decimal Y, decimal X) { return (decimal)Math.Atan2((double)Y, (double)X); }

    }
}
