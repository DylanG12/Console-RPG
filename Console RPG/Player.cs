using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>();
        public static int CoinCount = 50;

        //Omori is the main character, I will not have time to add an ally system
        public static Player Omori = new Player("Omori", 80, 100, 100, new Stats(100, 3, 5), 1);
        public static Player Omor = new Player("Omori", 80, 100, 100, new Stats(5, -3, 5), 1);
        public static Player Kel = new Player("Kel", 80, 100, 100, new Stats(5, 3, 5), 1);
        public static Player Aubrey = new Player("Aubrey", 80, 100, 100, new Stats(5, 3, 5), 1);
        public static Player  Hero = new Player("Hero", 80, 100, 100, new Stats(5, 3, 5), 1);

        public int level;

        public Player(string name, int hp, int mana, int stamina, Stats stats, int level) : base(name, hp, mana, stamina, stats)
        {
            this.level = level;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {

            Console.WriteLine("Who do you hit? (type in a number)");
            //figure it out
            for (int i = 0; i < targets.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {targets[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return targets[index - 1];
        }

        public Item ChooseItem(List<Item> choices)
        {

            Console.WriteLine("What item do you want to use? (type a number)");
            //figure it out
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage ans ubstract from the targets hp
            Console.ForegroundColor = ConsoleColor.Red;
            int damage = this.stats.strength - target.stats.defense;
            int hp = target.currentHP -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} and dealt {damage} damage! \n {target.name} now has {hp} health left."!);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do? (type exactly how its written)");
            Console.WriteLine("ATTACK | ITEM");
            string choice = Console.ReadLine();

            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Where(enemy => enemy.currentHP > 0).Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "ITEM")
            {
                if (Player.Inventory.Count > 0)
                {

                    Item item = ChooseItem(Inventory);
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                    item.Use(this, target);
                    Inventory.Remove(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{this.name} used a {item.name} on {target.name}, they now have {target.currentHP} hp!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You dont have anything in your inventory");
                }
            }
            
        }
    }
}
