using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.DefaultClasses
{
    public class AMonster : IMonster
    {
        public string Name { get; private set; }
        public int Defense { get; set; }
        public int AttackPower { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }

        public AMonster(string name, int defense, int attackPower, int health, int level)
        {
            Name = name;
            Defense = defense;
            AttackPower = attackPower;
            Health = health;
            Level = level;
        }

        public virtual void Roar()
        {
            Console.WriteLine($"{Name} emits a thunderous roar!");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} strikes with attack power {AttackPower}!");
        }

        public virtual void Defend()
        {
            Console.WriteLine($"{Name} braces for impact with defense {Defense}!");
        }
    }
}