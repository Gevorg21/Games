using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
         

            Player player = new Player();

            Bot bot = new Bot();

            Game g = new Game(player, bot);

            g.CheckName();
            
            Console.Write("Enter Money: ");
            player.Money = int.Parse(Console.ReadLine());
            
            g.Gamee();
            
        }
    }
}