using ClassLibrary.Module14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module14.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите количество игроков (минимум 2):");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            if (numberOfPlayers < 2)
            {
                Console.WriteLine("Недостаточно игроков.");
                return;
            }

            Game game = new Game(numberOfPlayers);
            game.Play();

            string textFromGame = "Текст из игры:";
            Dictionary<string, int> wordStatistics = GetWordStatistics(textFromGame);
            DisplayStatisticsTable(wordStatistics);

            Console.ReadKey();
        }

        static Dictionary<string, int> GetWordStatistics(string text)
        {
            string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCount = words
                .GroupBy(word => word, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(group => group.Key, group => group.Count());

            return wordCount;
        }

        static void DisplayStatisticsTable(Dictionary<string, int> wordStatistics)
        {
            Console.WriteLine("Статистика слов в тексте:");
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Слово      | Количество |");
            Console.WriteLine("-------------------------");

            foreach (var pair in wordStatistics)
            {
                Console.WriteLine($"| {pair.Key,-10} | {pair.Value,-11} |");
            }

            Console.WriteLine("-------------------------");
        }
    }
}
