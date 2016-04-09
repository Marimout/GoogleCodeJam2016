using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B.Pancakes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string inputFile = "B-large.in";
            string outputFile = "B-large.out";

            using (StreamReader input = new StreamReader(inputFile))
            {
                using (StreamWriter output = new StreamWriter(outputFile))
                {
                    int T = Convert.ToInt32(input.ReadLine());

                    for (int ii = 0; ii < T; ii++)
                    {
                        string s = input.ReadLine();
                        int len = s.Length;

                        int count = 0;
                        bool stop = false;
                        while (!stop)
                        {
                            int i = 0;
                            while (i < len - 1 && s[i] == s[i + 1])
                                i++;

                            if (i < len - 1)
                            {
                                s = Flip(s, i);
                                count++;
                            }
                            else
                            {
                                if (s[i] == '-')
                                    count++;

                                stop = true;
                            }
                        }

                        output.WriteLine("Case #{0}: {1}", ii + 1, count);
                    }
                }
            }
        }

        private static string Flip(string s, int c)
        {
            string ss = "";

            for (int i = c; i >= 0; i--)
            {
                if (s[i] == '+')
                {
                    ss += "-";
                }
                else
                {
                    ss += "+";
                }
            }

            for (int i = c + 1; i < s.Length; i++)
                ss += s[i];

            return ss;
        }
    }
}
