using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace CasinoGame
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
        private void Music()
        {
            WMPLib.WindowsMediaPlayer w = new WMPLib.WindowsMediaPlayer();
            w.URL = @"C:\Users\User\Downloads\Deep_House_Elements-Low_Pression_Of_Wot_-_Jack_Of_Jazz_Mix-spcs.me.mp3";
            w.controls.play();
        }
        public int Init(int number)
        {

            bool b = false;
            while (!b)
            {

                string str = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(str)||str.Length>10)
                {
                    Console.Write("Invalid  input . . .  Try Again: \a");
                    str = Console.ReadLine();

                }

                List<char> list = new List<char>();
                list.AddRange(str);
            
                int temp = 0;

                foreach (var item in list)
                {
                    if (char.IsDigit(item))
                        temp++;
                    else
                        temp--;
                }
                if (temp == str.Length)
                {
                    b = true;

                    number = Convert.ToInt32(str);
                  

                }
                else

                    Console.Write("Invalid  input . . .  Try again: \a");

            }
            return number;

        }

        private bool CheckManey(double money)
        {


            if (money <= 0 )
            {
                return false;
            }
            return true;
        }

        private bool CompareBetAndMoney(Player player)
        {

            player.Bet = Init(number);

            if (player.Bet > player.Money || player.Bet <= 0)
            {
                return false;
            }
            return true;
        }

        int number;
        private bool CheckNumber()
        {
            number = Init(number);


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

                    Console.Write("Invalid  input . . .  Try again: \a ");
                    player.Money = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter bet: ");

                while (!CompareBetAndMoney(player))
                {

                    Console.Write("Invalid  input . . .  Try again: \a");
                }

                Console.Write("Enter number: ");


                while (!CheckNumber())
                {
                    Console.Write("Enter number between 1 and 6: ");
                }

                bot.RandomInt = GenerateRandomInt();

                Finish(CheckOfWinning(bot.RandomInt, number));

                if (!CheckManey(player.Money))
                {
                    Console.WriteLine($"You have 0$.\nThanks {player.Name} for the game. ");
                    return;

                }

            }



        }

        private void Finish(bool flag)
        {
            if (flag)
            {
                Console.WriteLine($"You won {player.Name}");
                player.Money += player.Bet * 4;
            }
            else
            {
                Console.WriteLine($"You lost {player.Name}");
                player.Money -= player.Bet;

            }
            Console.WriteLine($"The number is {bot.RandomInt}");
            if (player.Money > 0)
            {
                Console.WriteLine($"You have {player.Money}$");

            }
            Console.Write("Continue game?: ");

            while (b)
            {

                string Revansh = Console.ReadLine();
                if (Revansh.ToLower() == "yes")
                {
                    b = true;
                    Console.Clear();
                    return;
                }

                if (Revansh.ToLower() == "no")
                {
                    if (player.Money != 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Thanks {player.Name} for the game");
                        b = false;
                        return;
                    }
                    else
                    {
                        b = false;
                        return;
                    }
                }

                else
                {
                    Console.Write("Type Yes or No: ");
                }
            }
        }
        public void CheckName()
        {
            Music();

            Console.Write("Enter your name: ");
            player.Name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(player.Name))
            {
                Console.Write("Invalid  input . . .  Try again: \a");
                player.Name = Console.ReadLine();
            }
        }

    }
}
