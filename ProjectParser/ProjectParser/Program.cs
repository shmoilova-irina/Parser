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
        static void Find_files(string folder_path, string find_word)
        {
            DirectoryInfo d = new DirectoryInfo(folder_path);
            foreach (FileInfo f in d.GetFiles("*.log"))
            {
                Console.WriteLine(f.Name);
                Read(folder_path + "\\" + f.Name, find_word);
            }
        }

        static void Read(string file_name, string find_word)
        {
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
            if (args.Length < 2)
            {
                Console.Write("Укажите файл/папку для распарса и слова, которые нужно искать, через пробел");
                return;
            }

            string ext = Path.GetExtension(args[0]);
            if (ext != null && ext.Length > 0)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    Read(args[0], args[i]);
                }
            }
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    Find_files(args[0], args[i]);
                }
            }
        }
    }
}
