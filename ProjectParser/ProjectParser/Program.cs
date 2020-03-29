﻿using System;
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
        static void Find_files(string folder_path, string pattern)
        {
            DirectoryInfo d = new DirectoryInfo(folder_path);
            foreach (FileInfo f in d.GetFiles("*.log"))
            {
                Console.WriteLine(f.Name);
                Read(folder_path + "\\" + f.Name, pattern);
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
                        Write("D://C#//Parser//result.txt", line);
                        Console.WriteLine($"Прочитано строк {lines_read}, найдено соответствий в строках {finds_line}");
                    }
                } 
            }
        }

        static int index_wrire = 0;

        static void Write(string file_new, string line)
        {
            using (FileStream fstream = new FileStream(file_new, FileMode.Create))
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
