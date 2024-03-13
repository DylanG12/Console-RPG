using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;
        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
        }

        public abstract void Use(Entity user, Entity target);
    }

    //Items that give health: (NAME, DESCRITPION, SHOP PRICE, MAX AMOUNT, HEAL AMOUNT)
    class HPFoodItem : Item
    {
        public int healAmount;
        public static HPFoodItem fries = new HPFoodItem("Fry box", "Worse than even Mc'Donalds (+ 5 hp)", 3, 10, 5);
        public static HPFoodItem sandwich = new HPFoodItem("Sandwich", "Sandy (+20 hp)", 10, 5, 20);
        public HPFoodItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP += this.healAmount;
        }
    }

    //Omoris specific weapon of choice : (NAME, DESCRPTION, SHOP PRICE, MAXAMOUNT, DAMAGE, BLEED DOT)
    class Knife : Weapon
    {
        public int bleed;
        public static Knife steakKnife = new Knife("Steak-knife", "Sharp (5 damage, 5 bleed damage)", 0, 1, 5, 3, 2, 1);


        public Knife(string name, string description, int shopPrice, int maxAmount, int damage, int bleed, int weight, int rarity) : base(name, description, shopPrice, maxAmount, weight, rarity, damage)
        {
            this.damage = damage;
            this.bleed = bleed;
        }
        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= this.damage;
        }
    }
}
