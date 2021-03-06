using System;

namespace Methods
{
    public class SinApproximation
    {
        public static double Chebyshev(double x)
        {
            double[] coefficients =
            {
                0.999999999973088, // x
                -0.1666666663960699, // x^3
                0.00833333287058762, // x^5
                -0.0001984123883227529, // x^7
                2.755627491096882e-6, // x^9
                -2.503262029557047e-8, // x^11
                1.58535563425041e-10 //x^13
            };

            var p13 = coefficients[6];
            var p11 = p13 * x * x + coefficients[5];
            var p9 = p11 * x * x + coefficients[4];
            var p7 = p9 * x * x + coefficients[3];
            var p5 = p7 * x * x + coefficients[2];
            var p3 = p5 * x * x + coefficients[1];
            var p1 = p3 * x * x + coefficients[0];

            return p1 * x;
        }

        public static double Taylor(double x, int n)
        {
            var result = 0d;

            for (var i = 0; i <= n; i++)
            {
                result += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
            }

            return result;
        }

        private static int Factorial(int num)
        {
            return num <= 1 ? 1 : Factorial(num - 1);
        }
    }
}