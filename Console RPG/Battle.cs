using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class Battle : PointOfInterest
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {


            while (true)
            {
                //run code on each player
                foreach(var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("It's " + player.name + " 's turn.");
                        Console.ForegroundColor = ConsoleColor.White;
                        player.DoTurn(players, enemies);
                    }
                    
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You are victorious!");

                    foreach (var item in enemies)
                    {
                        Player.CoinCount += item.coinsDroppedOnDeath;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nYou gained {item.coinsDroppedOnDeath} coins from a fallen enemy.\n You now have {Player.CoinCount} coins!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                   
                    //xp
                    break;
                }

                //run code on each player
                foreach (var enemy in enemies)
                {
                    if(enemy.currentHP > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("It's " + enemy.name + " 's turn.");
                        Console.ForegroundColor = ConsoleColor.White;
                        enemy.DoTurn(players, enemies);
                    }
                    
                }

                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("Game over");
                    Player.Omori.stats = Player.Omor.stats;
                    Console.WriteLine($"Your hp is now {Player.Omor.currentHP}");
                    break;
                }
            }
        }
    }
}
