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
        static void Read(string file_name)
        {
            // string file_name = "D:\\C#\\Parser";
            using (StreamReader sr = new StreamReader(file_name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("Error"))
                    {
                        Console.WriteLine(line);
                        Console.WriteLine("=====================================================================");
                    }
                } 
            }
        }


        static void Find_files()
        {
            string folder_path = "D:\\C#\\Parser";
            DirectoryInfo d = new DirectoryInfo(folder_path);

            foreach (FileInfo f in d.GetFiles("*.log"))
            {
                Console.WriteLine(f.Name);
                Read(folder_path + "\\" + f.Name);

            }
        }

        static void Main(string[] args)
        {
            Find_files();
            Console.ReadLine();
        }
    }
}
