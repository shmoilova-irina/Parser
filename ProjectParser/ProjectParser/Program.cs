using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectParser
{
    class Program
    {
        static void Read()
        {
            string file_name = "D:\\C#\\Parser\\log.log";

            using (StreamReader sr = new StreamReader(file_name))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

        static void Main(string[] args)
        {
            Read();
        }
    }
}
