using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {

        public float weight;
        public float rarity;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int maxAmount, float weight, float rarity) : base(name, description, shopPrice, maxAmount)
        {
            this.weight = weight;
            this.rarity = rarity;
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int maxAmount, float weight, float rarity, int defense) : base(name, description, shopPrice, maxAmount, weight, rarity)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                target.stats.defense += this.defense;
            }
            else if (!this.isEquipped)
            {
                target.stats.defense -= this.defense;
            }
        }
    }

    class Weapon : Equipment
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int maxAmount, float weight, float rarity, int damage) : base(name, description, shopPrice, maxAmount, weight, rarity)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                target.stats.strength += this.damage;
            }
            else if (!this.isEquipped)
            {
                target.stats.strength -= this.damage;
            }
        }
    }
}
