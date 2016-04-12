using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.CoinJam
{
    class Program
    {
        public static long CurrentCount = 0;
        public static string CurrentString;
        public static long N;
        public static long J;
        public static List<string> JamCoinList = new List<string>();

        static void Main(string[] args)
        {
            string inputFile = "C-small-attempt1.in";
            string outputFile = "C-small-attempt1.out";

            using (StreamReader input = new StreamReader(inputFile))
            {
                using (StreamWriter output = new StreamWriter(outputFile))
                {
                    long T = Convert.ToInt64(input.ReadLine());

                    for (long i = 0; i < T; i++)
                    {
                        var temps = input.ReadLine().Split(' ');
                        N = Convert.ToInt64(temps[0]);
                        J = Convert.ToInt64(temps[1]);

                        CurrentString = "1";

                        Try(1);

                        output.WriteLine("Case #{0}:", i + 1);

                        foreach (var coin in JamCoinList)
                        {
                            output.WriteLine(coin);
                        }
                    }
                }
            }
        }

        static long FirstDivisor(long n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return i;
            }

            return 1;
        }

        static void Try(long i)
        {
            for (var j = 0; j <= 1; j++)
            {
                CurrentString += j.ToString();

                if (i == N - 2)
                {
                    CurrentString += "1";

                    var proof = JamCoinProof(CurrentString);
                    if (!String.IsNullOrEmpty(proof))
                    {
                        CurrentCount++;
                        JamCoinList.Add(CurrentString + " " + proof);
                    }

                    CurrentString = CurrentString.Remove(CurrentString.Length - 1);
                }
                else
                {
                    Try(i + 1);
                }

                CurrentString = CurrentString.Remove(CurrentString.Length - 1);

                if (CurrentCount == J)
                    return;
            }
        }

        static long ValueInBase(string s, long b)
        {
            long len = s.Length;
            long v = 0;
            for (int i = 0; i < len; i++)
            {
                v += Convert.ToInt64(s[i].ToString()) * (long)Math.Pow(b, len - i - 1);
            }

            return v;
        }

        static string JamCoinProof(string s)
        {
            string proof = "";

            int len = s.Length;

            if (s[0] != '1' || s[len - 1] != '1')
                return "";


            for (long i = 2; i <= 10;i++)
            {
                long v = FirstDivisor(ValueInBase(s, i));
                if (v == 1)
                    return "";
                else proof += v.ToString() + " ";
            }

            return proof;
        }
    }
}
