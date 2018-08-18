using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
   
    public class Game
    {
        private Player player;
        private Bot bot;

        public Game(Player player, Bot bot)
        {
            this.player = player;
            this.bot = bot;
        }

        private bool CheckManey(int money)
        {
            if (money <= 0)
            {
                return false;
            }
            return true;
        }

        private bool CompareBetAndMoney(Player player)
        {
            player.Bet = int.Parse(Console.ReadLine());
            if (player.Bet > player.Money || player.Bet <= 0)
            {
                return false;
            }
            return true;
        }

        private bool CheckNumber(out int number)
        {
            number = int.Parse(Console.ReadLine());
            if (number >= 1 && number <= 6)
            {
                return true;
            }
            return false;
        }

        private bool CheckOfWinning(int betNumber, int playerNumber)
        {
            if (betNumber == playerNumber)
            {
                return true;
            }
            return false;
        }

        private int GenerateRandomInt()
        {
            Random rand = new Random();

            return rand.Next(1, 7);
        }
        bool b = true;

        public void Gamee()
        {

            while (b)
            {
                while (!CheckManey(player.Money))
                {
                    Console.WriteLine("Unsighit Money");
                    player.Money = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter Bet: ");

                while (!CompareBetAndMoney(player))
                {

                    Console.WriteLine("Unsighit Bet Number");
                }

                Console.Write("Enter Number: ");

                int num;

                while (!CheckNumber(out num))
                {
                    Console.WriteLine("Input Number 1-6");
                }

                bot.RandomInt = GenerateRandomInt();

                Finish(CheckOfWinning(bot.RandomInt, num));
            }


        }

        private void Finish(bool flag)
        {
            if (flag)
            {
                Console.WriteLine($"You Are Win {player.Name}");
                player.Money += player.Bet * 6;
            }
            else
            {
                Console.WriteLine("You Are Lose " + player.Name);
                player.Money -= player.Bet;
            }


            Console.WriteLine("Your Score = " + player.Money);
            Console.WriteLine("Continue Game?");

            while (true)
            {
                string Revansh = Console.ReadLine();
                if (Revansh.ToLower() == "yes")
                {
                    b = true;
                    return;
                }
                if (Revansh.ToLower() == "no")
                {
                    Console.WriteLine($"Thanks {player.Name} For The Game");
                    b = false;
                    return;
                }
                else
                {
                    Console.WriteLine("Input Yes Or No");
                }
            }
        }
        public void CheckName()
        {
            Console.Write("Enter Your Name: ");
            player.Name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(player.Name))
            {
                Console.Write("Invalid  Input . . .  Try Again: ");
                player.Name = Console.ReadLine();
            }
        }

    }
}
