using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul16.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите:");
                Console.WriteLine("1.Просмотр содержимого директории");
                Console.WriteLine("2.Создание файла/директории");
                Console.WriteLine("3.Удаление файла/директории");
                Console.WriteLine("4.Копирование файла/директории");
                Console.WriteLine("5.Перемещение файла/директории");
                Console.WriteLine("6.Чтение из файла");
                Console.WriteLine("7.Запись в файл");
                Console.WriteLine("0.Выход");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewDirectoryContents();
                        break;
                    case 2:
                        CreateFileOrDirectory();
                        break;
                    case 3:
                        DeleteFileOrDirectory();
                        break;
                    case 4:
                        CopyFileOrDirectory();
                        break;
                    case 5:
                        MoveFileOrDirectory();
                        break;
                    case 6:
                        ReadFromFile();
                        break;
                    case 7:
                        WriteToFile();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("error.");
                        break;
                }
            }
        }

        static void ViewDirectoryContents()
        {
            Console.WriteLine("Введите путь к директории:");
            string path = Console.ReadLine();

            try
            {
                string[] files = Directory.GetFiles(path);
                string[] dir = Directory.GetDirectories(path);

                Console.WriteLine("Файлы:");
                foreach (string f in files)
                {
                    Console.WriteLine(Path.GetFileName(f));
                }

                Console.WriteLine("Директории:");
                foreach (string d in dir)
                {
                    Console.WriteLine(Path.GetFileName(d));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        static void CreateFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (1 - файл, 2 - директория):");
            int typeChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();

            try
            {
                if (typeChoice == 1)
                {
                    File.Create(path).Close();
                    Console.WriteLine("Файл создан.");
                }
                else if (typeChoice == 2)
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Директория создана .");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (1 - файл, 2 - директория):");
            int typeChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();

            try
            {
                if (typeChoice == 1)
                {
                    File.Delete(path);
                    Console.WriteLine("Файл удален");
                }
                else if (typeChoice == 2)
                {
                    Directory.Delete(path, true); 
                    Console.WriteLine("Директория удалена");
                }
                else
                {
                    Console.WriteLine("error ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void CopyFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (1 - файл, 2 - директория):");
            int type = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите исходный путь:");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Введите целевой путь:");
            string targetPath = Console.ReadLine();

            try
            {
                if (type == 1)
                {
                    File.Copy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                    Console.WriteLine("Файл скопирован успешно.");
                }
                else if (type == 2)
                {
                    DirectoryCopy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)), true);
                    Console.WriteLine("Директория скопирована успешно.");
                }
                else
                {
                    Console.WriteLine("Неверный выбор типа.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void MoveFileOrDirectory()
        {
            Console.WriteLine("Выберите тип (1 - файл, 2 - директория):");
            int typeChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите исходный путь:");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Введите целевой путь:");
            string targetPath = Console.ReadLine();

            try
            {
                if (typeChoice == 1)
                {
                    File.Move(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                    Console.WriteLine("Файл перемещен ");
                }
                else if (typeChoice == 2)
                {
                    Directory.Move(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                    Console.WriteLine("Директория перемещена");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ReadFromFile()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void WriteToFile()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Введите текст для записи в файл:");
            string content = Console.ReadLine();

            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("Текст записан в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DirectoryCopy(string sourceDirName, string dirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(dirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(dirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


    }
}
