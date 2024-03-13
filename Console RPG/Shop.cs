using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    class Shop : PointOfInterest
    {
        public string shopName;
        public List<Item> items;

        public Shop(string shopName, List<Item> items) : base(false)
        {
            this.shopName = shopName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            Console.WriteLine($"\nYou entered shop: {shopName} \n");
            while (true)
            {

                Console.WriteLine("\nWhat do you want to do?(Type as shown)");
                Console.WriteLine("BUY | TALK | LEAVE");
                string userInput = Console.ReadLine();

                if (userInput == "BUY")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\nYou curently have ${Player.CoinCount} cash \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Item item = ChooseItem(this.items);

                    Console.WriteLine($"\nHow many of this item do you want to buy? Max of ({item.maxAmount})");
                    int amount = Convert.ToInt32(Console.ReadLine());

                    if (amount + Player.Inventory.Count(thisItem => thisItem == item) > item.maxAmount)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nYou cant hold that many");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (item.shopPrice * amount > Player.CoinCount)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\nYour too poor to afford {item.name}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (amount <= item.maxAmount)
                    {
                        for (int i = 0; i < amount; ++i)
                        {
                            Player.CoinCount -= item.shopPrice;
                            Player.Inventory.Add(item);

                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nYou've accquired {amount} {item.name}('s)");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Your new money is now ${Player.CoinCount}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    

                }
                else if (userInput == "TALK")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nIn case your wondering, yes I run every single shop");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (userInput == "LEAVE")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nType in a valid command\n");
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nBye\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Item ChooseItem(List<Item> choices)
        {

            Console.WriteLine("What item do you want to buy? (type a number)\n");
            //figure it out
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} (${choices[i].shopPrice}) {choices[i].description}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
