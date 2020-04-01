using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectParser
{
    class Program
    {
        static string[] log_types = new string[] { "*.log", "*.txt", ""};
        static string result_perfix = "_result.txt";

        static void Find_files(string folder_path, string pattern)
        {
            DirectoryInfo d = new DirectoryInfo(folder_path);
            foreach (string file_exist in log_types)
            {
                foreach (FileInfo f in d.GetFiles(file_exist))
                {
                    if (f.Name.Contains(result_perfix))
                    {
                        continue;
                    }
                    Console.WriteLine("Start read: " + f.Name);
                    Read(folder_path + f.Name, pattern);
                }
            }
        }

        static void Read(string file_name, string pattern)
        {
            int lines_read = 0;
            int finds_line = 0;
            using (StreamReader sr = new StreamReader(file_name))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines_read++;
                    if (Regex.IsMatch(line, pattern, RegexOptions.IgnoreCase))
                    {
                        finds_line++;
                        Write(file_name + result_perfix, line);
                        Console.WriteLine($"Прочитано строк {lines_read}, найдено соответствий в строках {finds_line}");
                    }
                } 
            }
        }

        static int index_write = 0;

        static void Write(string file_new, string line)
        {
            using (FileStream fstream = new FileStream(file_new, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fstream, Encoding.ASCII))
                {
                    sw.WriteLine(line);
                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Write("Укажите файл/папку для распарса и слова, которые нужно искать, через пробел");
                return;
            }
            string file_or_path = args[0];
            string last_symbol = file_or_path.Substring(file_or_path.Length-1);
            if (last_symbol == "/" || last_symbol == "\\")
            {
                for (int i = 1; i < args.Length; i++)
                {
                    Find_files(file_or_path, args[i]);
                }
            }
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    Read(file_or_path, args[i]);
                }
            }
        }
    }
}
