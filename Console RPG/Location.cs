using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location omoriHouse = new Location("Home", "Yippe" + "\n");
        public static Location  startArea = new Location("White space", "The realm between realms. Comfy." + "\n");
        public static Location school = new Location("School grounds", "Your prison" + "\n");
        public static Location  dreamWorld = new Location("Dream world", "Your own little headspace" + "\n");
        public static Location Computer = new Location("Computer(SHOP)", "Where did this come from?", new Shop("Computer", new List<Item>() { Knife.steakKnife }));
        public static Location  vastForest = new Location("Vast Forest(BATTLE)", "Dangerous", new Battle(new List<Enemy>() { Enemy.bun, Enemy.SproutMole }));
        public static Location BunShrine = new Location("Bun Shrine (DIFFICULT BATTLE)", "Do you pray to the buns?", new Battle(new List<Enemy>() { Enemy.bun, Enemy.bun, Enemy.bun, Enemy.bun }));
        public static Location  playground = new Location("Playground", "Where all your friends are" + "\n");
        public static Location  northLake = new Location("Northlake", "The lake of the north" + "\n");
        public static Location woods = new Location("Deep woods (BATTLE)", "A forest past the lake", new Battle(new List<Enemy>() { Enemy.Spider, Enemy.Ghost }));
        public static Location  space = new Location("Space", "Space!" + "\n");
        public static Location houses = new Location("Houses(DIFFICULT BATTLE)", "Who lives here?", new Battle(new List<Enemy> { Enemy.SpacePirate, Enemy.SpacePirate }));
        public static Location spaceBoyLair = new Location("Space Boy's lair(BOSS)", "ITS HIM!!!!", new Battle(new List<Enemy>() { Enemy.SpaceBoy }));
        public static Location cafeteria = new Location("Cafeteria(SHOP)", "School lunch is digusting, but at least its cheap" + "\n", new Shop("Cafeteria", new List<Item>() { HPFoodItem.fries, HPFoodItem.sandwich }));

        public string name;
        public string description;
        public PointOfInterest Event;

        public Location north, east, south, west;

        public Location(string name, string description, PointOfInterest Event = null)
        {
            this.name = name;
            this.description = description;
            this.Event = Event;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {

            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }
              
            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }
              
            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
                
        }

        public void Resolve(List<Player> players)
        {
            //Only resolve a battle if there is one to resolve. aka "Null checking"
            Event?.Resolve(players);

            Console.WriteLine("You are now in " + this.name + ". (Type n, e, s or w to travel)" + "\n");
            Console.WriteLine(this.description);

            if (!(north is null))
                Console.WriteLine("NORTH: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("EAST: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("WEST: " + this.west.name + "\n");

            bool Loop = true;
            Location nextLocation = null;
            while (Loop)
            {
                string direction = Console.ReadLine();
                

                if (direction == "n")
                {
                    nextLocation = this.north;
                    Loop = false;
                }

                else if (direction == "e")
                {
                    nextLocation = this.east;
                    Loop = false;
                }


                else if (direction == "s")
                {
                    nextLocation = this.south;
                    Loop = false;
                }


                else if (direction == "w")
                {
                    nextLocation = this.west;
                    Loop = false;
                }


                else
                {
                    Console.WriteLine("Type in a location's letter (n, e, s, w)" + "\n");
                    Loop = true;
                }

               
            } nextLocation.Resolve(players);
        }
    }
}
