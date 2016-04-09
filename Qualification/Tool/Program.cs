using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFile = "inputAll.txt";

            using (StreamWriter output = new StreamWriter(outputFile))
            {
                output.WriteLine(1000000);
                for (int i = 1; i <= 1000000; i++)
                {
                    output.WriteLine(i);
                }
            }
        }
    }
}
