using CartConversion;
using System;

namespace ConsoleAppModule12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RacingGame game = new RacingGame();

            RaceCar raceCar = new RaceCar(200);
            SportsCar sportsCar = new SportsCar(180);

            raceCar.RaceEvent += DisplayMessage;
            raceCar.FinishEvent += DisplayMessage;

            sportsCar.RaceEvent += DisplayMessage;
            sportsCar.FinishEvent += DisplayMessage;

            game.StartRace();

            raceCar.Accelerate(20);
            sportsCar.Accelerate(15);

            Console.ReadKey();
        }

        private static void DisplayMessage(object sender, string e)
        {
            Console.WriteLine($"[Game]: {e}");
        }
    }
}
