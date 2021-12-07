using System;

namespace Methods
{
    public class RangeReduction
    {
        //x' = x - kC

        public const double C = Math.PI / 4;
        public static double ClassicReduction(double x, double c)
        {
            double k = Math.Floor(x / c);

            return x - k * c;
        }
    }
}