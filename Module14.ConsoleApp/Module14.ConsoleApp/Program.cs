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
            Console.ReadKey();
        }
    }
}
