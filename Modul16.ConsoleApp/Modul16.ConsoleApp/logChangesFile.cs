using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul16.ConsoleApp
{
    internal class logChangesFile
    {
        static void LogChange(string action, string path)
        {
            string logMessage = $"{DateTime.Now} - {action}: {path}";
            Console.WriteLine(logMessage);

            try
            {
                File.AppendAllText("log.txt", logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
        static void Main()
        {
            Console.WriteLine("приложение для логирования изменений в файлах");

            Console.Write("Введите путь: ");
            string Path = Console.ReadLine();

            Console.Write("путь к лог-файлу: ");
            string logFilePath = Console.ReadLine();

            using (FileSystemWatcher watcher = new FileSystemWatcher(Path))
            {
                watcher.IncludeSubdirectories = true;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite;

                watcher.Changed += (sender, e) => LogChange("Изменено", e.FullPath);

                watcher.Created += (sender, e) => LogChange("Создано", e.FullPath);

                watcher.Deleted += (sender, e) => LogChange("Удалено", e.FullPath);

                watcher.Renamed += (sender, e) => LogChange($"Переименовано с {e.OldFullPath} на", e.FullPath);

                watcher.EnableRaisingEvents = true;

                Console.WriteLine($"Отслеживание изменений в директории {Path} начато.");

                Console.ReadKey();
            }

        }


    }
}
