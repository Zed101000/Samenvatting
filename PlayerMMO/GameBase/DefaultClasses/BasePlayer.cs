using System;

namespace GameBase.DefaultClasses
{
    public class BasePlayer : APlayer
    {
        public BasePlayer(string name, int mana = 50, int defense = 5, int attackPower = 10, int health = 100, int level = 1)
            : base(name, health, mana, attackPower, defense, level)
        {
        }

        // Leave Play() open for your custom logic
        public override void Play()
        {
            base.Play();
        }
        public override void Attack()
        {
            Console.WriteLine($"{this.Name} Attacks with hand");
        }

        public override void Heal()
        {
            Console.WriteLine($"{this.Name} Heals passively");
        }

        public override void Defend()
        {
            Console.WriteLine($"{this.Name} Defends with arms");
        }

        public override IPlayer Unequip()
        {
            Console.WriteLine($"{this.Name} has nothing to unequip.");
            return this;
        }
    }
}
