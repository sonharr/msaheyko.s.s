﻿using System;
using System.IO;
using System.IO.Compression;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = @"D:\";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги D:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
            }
            string path = @"D:\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine();
            Console.WriteLine("Выберете папку: ");
            string papka = Console.ReadLine();
            string sourceFolder = papka; // исходнаяпапка
            string zipFile = @"D:\test.zip"; // сжатыйфайл
            string targetFolder = @"D:\newtest"; // папка, куда распаковывается файл

            Console.WriteLine();
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Выбранная папка, {sourceFolder}, заархивирована в файл{zipFile}");

            Console.WriteLine();
            FileInfo fileInf = new FileInfo(zipFile);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }

            ZipFile.ExtractToDirectory(zipFile, targetFolder);
            Console.WriteLine($"Файл {zipFile} распакован в папку{targetFolder}");

            Console.WriteLine();
            Console.WriteLine("Файлы из распакованной папки: ");
            string[] files3 = Directory.GetFiles(targetFolder);
            foreach (string s in files3)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            Console.WriteLine("Выберете файл, о котором хотите посмотреть информацию:");
            string file3 = Console.ReadLine();

            Console.WriteLine();
            FileInfo fileInf1 = new FileInfo(file3);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf1.Name);
                Console.WriteLine("Время создания: {0}", fileInf1.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf1.Length);
            }

            Console.WriteLine();
            string path3 = $"{path}test.zip";
            FileInfo fileInf3 = new FileInfo(path3);
            Console.WriteLine($"После нажатия ENTER файл {path}test.zip будет удалён:");
            string enter = Console.ReadLine();
            if (enter == "")
            {
                if (fileInf3.Exists)
                {
                    fileInf3.Delete();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"После нажатия ENTER файл {path} newtest будет удалён:");
            string enter1 = Console.ReadLine();
            if (enter1 == "")
            {
                string path4 = @"D:\newtest";
                Directory.Delete(path4, true);
            }
        }
    }
}