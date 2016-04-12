using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            using (StreamReader input = new StreamReader(inputFile))
            {
                using (StreamWriter output = new StreamWriter(outputFile))
                {
                    int T = Convert.ToInt32(input.ReadLine());

                    for (int ii = 0; ii < T; ii++)
                    {
                        var temps = input.ReadLine().Split(' ');
                        long K = Convert.ToInt64(temps[0]);
                        long C = Convert.ToInt64(temps[1]);
                        long S = Convert.ToInt64(temps[2]);

                        // Small case : K = S
                        output.Write("Case #{0}: ", ii + 1);

                        for (long i = 1; i <= K;i++)
                        {
                            long pos = 0;
                            for (long j = C - 1; j >= 1; j--)
                                pos += (long)Math.Pow(K, j) * (i - 1);
                            pos += i;

                            output.Write("{0} ", pos);
                        }

                        output.WriteLine();
                    }
                }
            }
        }
    }
}