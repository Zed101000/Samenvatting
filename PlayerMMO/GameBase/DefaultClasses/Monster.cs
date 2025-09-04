using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.DefaultClasses { 
    public class Monster : AMonster
    {
        public Monster(string name, int defense, int attackPower, int health, int level) : base(name, defense, attackPower, health, level) { 
        }

        public override void Roar()
        {
            Console.WriteLine($"{Name} roars fiercely like a monster!");
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with power {AttackPower} like a monster!");
        }

        public override void Defend()
        {
            Console.WriteLine($"{Name} defends with defense {Defense} like a monster!");
        }
    }
}
