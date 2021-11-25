using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        public static void Main(string[] args)
        {
            var chebyshev = new Dictionary<double, double>();
            var taylor = new Dictionary<double, double>();
            var mathLib = new Dictionary<double, double>();
            
            var chebyshevErrors = new Dictionary<double, double>();
            var taylorErrors = new Dictionary<double, double>();

            for (var x = -1d; x < 1; x += 0.001)
            {
                var cheb = SinApproximation.Chebyshev(x);
                var tayl = SinApproximation.Taylor(x, 6);
                var lib = Math.Sin(x);

                var errorCheb = (cheb / lib) - 1;
                var errorTayl = (tayl / lib) - 1;
                
                chebyshev.Add(x, cheb);
                taylor.Add(x, tayl);
                mathLib.Add(x, lib);
                
                chebyshevErrors.Add(x, errorCheb);
                taylorErrors.Add(x, errorTayl);
            }

            WriteResultsToFile(chebyshevErrors, "chebyshev_errors.csv");
            WriteResultsToFile(taylorErrors, "taylor_errors.csv");
            WriteResultsToFile(mathLib, "lib.csv");
            WriteResultsToFile(chebyshev, "chebyshev.csv");
            WriteResultsToFile(taylor, "taylor.csv");
        }

        private static void WriteResultsToFile(Dictionary<double, double> content, string filename)
        {
            using (var stream = File.Create($"../../../{filename}"))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var (key, value) in content)
                    {
                        writer.WriteLine($"{key.ToString(CultureInfo.InvariantCulture)};{value.ToString(CultureInfo.InvariantCulture)}");
                    }
                }
            }
        }
    }
}