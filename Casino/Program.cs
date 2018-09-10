using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CasinoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Player player = new Player();

            Bot bot = new Bot();

            Game g = new Game(player, bot);
           

            g.CheckName();


            Console.Write("Enter money: ");
            int money=0;
            player.Money = g.Init(money);

            g.Gamee();
            

        }
    }
}
