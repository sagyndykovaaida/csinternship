using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Module14
{
    public class Player
    {
        public List<Karta> newList { get; set; }

        public Player()
        {
            newList = new List<Karta>();
        }

        public void AddCard(Karta card)
        {
            newList.Add(card);
        }

        public void DisplayHand()
        {
            Console.WriteLine("Имеющиеся карты:");
            foreach (var card in newList)
            {
                Console.WriteLine(card);
            }
        }
    }
}
