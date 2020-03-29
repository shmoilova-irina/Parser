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
        static void Read(string file_name, string find_word)
        {
            // string file_name = "D:\\C#\\Parser";
            using (StreamReader sr = new StreamReader(file_name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(find_word))
                    {
                        Console.WriteLine(line);
                        Console.WriteLine("=====================================================================");
                    }
                } 
            }
        }


        static void Find_files(string find_word)
        {
            string folder_path = "D:\\C#\\Parser";
            DirectoryInfo d = new DirectoryInfo(folder_path);

            foreach (FileInfo f in d.GetFiles("*.log"))
            {
                Console.WriteLine(f.Name);
                Read(folder_path + "\\" + f.Name, find_word);

            }
        }

        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Find_files(arg);
            }
        }
    }
}
