using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    struct Stats
    {
        // Structs are useful for sotring simple plain data.
        public int strength;
        public int defense;
        public int speed;

        //no time to intemplement speed or stamina and mana usage on attacking
        public Stats(int strength, int defense, int speed)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
        }
    }

    // Classes are useful for storing complex objects.
     abstract class Entity
     {
        public string name;

        public int currentHP, maxHP;
        public int currentMana, maxMana;
        public int currentStam, maxStam;

        // This is called composition. Composition is awesome!
        public Stats stats;

        public Entity(string name, int hp, int mana, int stamina, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.currentStam = stamina;
            this.maxStam = stamina;
            this.stats = stats;
        }

        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target);
     }


   
}
