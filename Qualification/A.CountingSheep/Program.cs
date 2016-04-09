using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.CountingSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "A-large.in";
            string outputFile = "A-large.out";

            using (StreamReader input = new StreamReader(inputFile))
            {
                using (StreamWriter output = new StreamWriter(outputFile))
                {
                    int T = Convert.ToInt32(input.ReadLine());

                    for (int i = 0; i < T; i++)
                    {
                        int N = Convert.ToInt32(input.ReadLine());

                        if (N == 0)
                        {
                            output.WriteLine("Case #{0}: INSOMNIA", i + 1);
                        }
                        else
                        {
                            HashSet<int> check = new HashSet<int>();
                            bool found = false;
                            int j = 1;
                            while (j <= Math.Pow(10, N.ToString().Length * 2) + 1)
                            {
                                int k = N * j;
                                while (k > 0)
                                {
                                    check.Add(k % 10);
                                    if (check.Count == 10)
                                    {
                                        found = true;
                                        break;
                                    }

                                    k = k/10;
                                }
                                if (found)
                                    break;

                                j++;
                            }

                            if (found)
                            {
                                output.WriteLine("Case #{0}: {1}", i + 1, N * j);
                            }
                            else
                            {
                                output.WriteLine("Case #{0}: INSOMNIA", i + 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
