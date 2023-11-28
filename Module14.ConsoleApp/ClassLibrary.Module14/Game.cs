using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Module14
{
    public class Game
    {
        private List<Player> players;
        private List<Karta> cards;

        public Game(int player)
        {
            players = new List<Player>();
            cards = new List<Karta>();

            Initialize();
            ForwardCards();
            TransactionsCard(player);
        }

        private void Initialize()
        {
            string[] masts = { "Черви", "Бубны", "Крести", "Пики" };
            string[] tips = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var mast in masts)
            {
                foreach (var tip in tips)
                {
                    cards.Add(new Karta(mast, tip));
                }
            }
        }

        private void ForwardCards()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Karta value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        private void TransactionsCard(int playerNum)
        {
            for (int i = 0; i < playerNum; i++)
            {
                Player player = new Player();
                players.Add(player);
            }

            int playerIndex = 0;
            foreach (var card in cards)
            {
                players[playerIndex].AddCard(card);
                playerIndex = (playerIndex + 1) % playerNum;
            }
        }

        public void Play()
        {
            while (!IsGameOver())
            {
                PlayRound();
            }

            Console.WriteLine($"Победил игрок {GetWinner() + 1}");
        }

        private void PlayRound()
        {
            List<Karta> cardsInPlay = new List<Karta>();
            foreach (var player in players)
            {
                if (player.newList.Count > 0)
                {
                    Karta card = player.newList[0];
                    Console.WriteLine($"Игрок {players.IndexOf(player) + 1} кладет карту: {card}");
                    cardsInPlay.Add(card);
                    player.newList.RemoveAt(0);
                }
            }

            int winnerIndex = FindRoundWinner(cardsInPlay);
            players[winnerIndex].newList.AddRange(cardsInPlay);
            Console.WriteLine($"Игрок {winnerIndex + 1} забирает карты!");

            DisplayPlayersHands();
        }

        private int FindRoundWinner(List<Karta> cardsInPlay)
        {
            int maxIndex = 0;
            for (int i = 1; i < cardsInPlay.Count; i++)
            {
                if (CompareCards(cardsInPlay[i], cardsInPlay[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private int CompareCards(Karta card1, Karta card2)
        {
            string[] tips = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            return Array.IndexOf(tips, card1.Tip) - Array.IndexOf(tips, card2.Tip);
        }

        private bool IsGameOver()
        {
            return players.Any(player => player.newList.Count == 36);
        }

        private int GetWinner()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].newList.Count == 36)
                {
                    return i;
                }
            }
            return -1; 
        }

        private void DisplayPlayersHands()
        {
            foreach (var player in players)
            {
                player.DisplayHand();
                Console.WriteLine();
            }
        }
    }
}
