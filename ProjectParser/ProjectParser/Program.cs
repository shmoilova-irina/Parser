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
            // string file_name = "D:\\C#\\Parser\\fev.txt";
            using (StreamReader sr = new StreamReader(file_name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(find_word))
                    {
                        Write("D://C#//Parser//result.txt", line);
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

        static int index_wrire = 0;

        static void Write(string file_new, string line)
        {
            using (FileStream fstream = new FileStream(file_new, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(line + "\n");
                fstream.Position = index_wrire;
                fstream.Write(array, 0, array.Length);
                index_wrire += array.Length;
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
