﻿using System;
using System.IO;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SomeDir2\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку файла:");
            string text = Console.ReadLine();

            using (FileStream fstream = new FileStream($"{path}note.txt", FileMode.OpenOrCreate))
            {               
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан");
            }

            using (FileStream fstream = File.OpenRead($"{path}note.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }

            string path1 = $"{path}note.txt";
            FileInfo fileInf = new FileInfo(path1);
            Console.WriteLine("После нажатия ENTER файл будет удалён:");
            string enter = Console.ReadLine();
            if (enter == "")
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }
        }
    }
}