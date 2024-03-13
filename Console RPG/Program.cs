using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        //crpg is inspired by Omori
        static void Main(string[] args)
        {
            // Player (name) = new Player("NAME", HP, MANA, STAMINA, new Stats(STR, DEF, SPD), LEVEL);
            // Enemy (name) = new Enemy("NAME", HP, MANA, STAMINA, new Stats(STR, DEF, SPD), COINS, EXP);

            //HEALTH:
            //(item) (name) = new (item) ("NAME", "DESCRIPTION", PRICE IN SHOP, MAX AMOUNT, HEAL AMOUNT)

            Console.WriteLine("Name = " + Enemy.bun.name + "\n");
            Console.WriteLine("Strength = " + Enemy.bun.stats.strength + "\n");
            Console.WriteLine("Defense = " + Enemy.bun.stats.defense + "\n");
            Console.WriteLine("Speed = " + Enemy.bun.stats.speed + "\n");
            Console.WriteLine("MaxHP = " + Enemy.bun.maxHP + "\n");
            Console.WriteLine("Coins on death = " + Enemy.bun.coinsDroppedOnDeath + "\n");
            Console.WriteLine("Exp on death = " + Enemy.bun.expDroppedOnDeath + "\n");

        //Locations:
        //omoriHouse O
        //startArea O
        //school X
        //dreamWorld O
        //vastForest X
        //playground X
        //northLake X
        //space X
        // cafeteria O

            Location.startArea.SetNearbyLocations(north: Location.dreamWorld, south: Location.omoriHouse, west: Location.Computer);
            Location.omoriHouse.SetNearbyLocations(north: Location.startArea, south: Location.school);
            Location.school.SetNearbyLocations(north: Location.omoriHouse, west: Location.cafeteria);
            Location.cafeteria.SetNearbyLocations(east: Location.school);
            Location.dreamWorld.SetNearbyLocations(north: Location.northLake, south: Location.startArea, east: Location.playground, west: Location.vastForest);
            Location.northLake.SetNearbyLocations(east: Location.woods);
            Location.space.SetNearbyLocations(north: Location.spaceBoyLair, west: Location.houses);
            Location.playground.SetNearbyLocations(east: Location.BunShrine);

            Location.startArea.Resolve(new List<Player>() { Player.Omori });

            int numberOfDucks = 12;
            Console.WriteLine("Omori owns " + numberOfDucks + " ducks");
            Console.WriteLine($"Omori owns {numberOfDucks} ducks.");
        }
    }
}
