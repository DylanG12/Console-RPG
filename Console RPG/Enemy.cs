using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy bun = new Enemy("Bun", 25, 50, 25, new Stats(3, 1, 2), 5, 15);
        public static Enemy SproutMole = new Enemy("Sprout mole", 50, 25, 50, new Stats(6, 3, 1), 10, 25);
        public static Enemy Spider = new Enemy("Spider", 30, 50, 25, new Stats(10, 0, 5), 20, 30);
        public static Enemy SproutMoleKnight = new Enemy("Sprout mole-knight", 50, 50, 25, new Stats(5, 10, 1), 30, 40);
        public static Enemy Ghost = new Enemy("Ghost", 50, 50, 25, new Stats(2, 15, 5), 10, 40);
        public static Enemy SpacePirate = new Enemy("Space-pirate", 25, 50, 25, new Stats(6, 3, 2), 50, 25);
        public static Enemy SpaceBoy = new Enemy("Space Boy..?", 150, 100, 100, new Stats(8, 6, 5), 100, 150);

        public int coinsDroppedOnDeath;
        public int expDroppedOnDeath;

        public Enemy(String name, int hp, int mana, int stamina, Stats stats, int coinsDroppedOnDeath, int expDroppedOnDeath) : base(name, hp, mana, stamina, stats)
        {
            this.coinsDroppedOnDeath = coinsDroppedOnDeath;
            this.expDroppedOnDeath = expDroppedOnDeath;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            //figure out how to calculate the damage and subtract from the targets hp
            Console.ForegroundColor = ConsoleColor.Red;
            int damage = this.stats.strength - target.stats.defense;
            int hp = target.currentHP -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} and dealt {damage} damage! \n {target.name} now has {hp} health left."!);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
