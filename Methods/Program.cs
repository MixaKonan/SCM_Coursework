using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Methods
{
    class Program
    {
        public static void Main(string[] args)
        {
            var mySinValues = new Dictionary<double, double>();
            var mathSinValues = new Dictionary<double, double>();
            var errors = new Dictionary<double, double>();

            for (var x = -Math.PI; x < Math.PI; x += 0.001)
            {
                var myVal = Sin(x);
                var libVal = Math.Sin(x);

                var error = (myVal / libVal) - 1;
                
                mySinValues.Add(x, myVal);
                mathSinValues.Add(x, libVal);
                errors.Add(x, error);
            }
            
            using (var stream = File.Create("../../../my_sin.csv"))
            {
                using var writer = new StreamWriter(stream);
                
                //writer.WriteLine("X;Y");
                
                foreach (var (key, value) in mySinValues)
                {
                    writer.WriteLine($"{key.ToString(CultureInfo.InvariantCulture)};{value.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            
            using (var stream = File.Create("../../../math_sin.csv"))
            {
                using var writer = new StreamWriter(stream);
                
                //writer.WriteLine("X;Y");
                
                foreach (var (key, value) in mathSinValues)
                {
                    writer.WriteLine($"{key.ToString(CultureInfo.InvariantCulture)};{value.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            
            using (var stream = File.Create("../../../errors.csv"))
            {
                using var writer = new StreamWriter(stream);
                
                //writer.WriteLine("X;Y");
                
                foreach (var (key, value) in errors)
                {
                    writer.WriteLine($"{key.ToString(CultureInfo.InvariantCulture)};{value.ToString(CultureInfo.InvariantCulture)}");
                }
            }
        }

        public static double Sin(double x)
        {
            double[] coefficients =
            {
                0.999999999973088, // x
                -0.1666666663960699, // x^3
                0.00833333287058762, // x^5
                -0.0001984123883227529, // x^7,
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
    }
}