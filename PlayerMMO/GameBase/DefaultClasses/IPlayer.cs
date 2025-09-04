using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.DefaultClasses
{
    public interface IPlayer
    {
        string Name { get; }
        int Mana { set; get; }
        int Defense { set; get; }
        int AttackPower { set; get; }
        int Health { set; get; }
        int Level { set; get; }
        IPlayer Unequip();
        void Play();
        void Attack();
        void Defend();
        void Heal();
    }
}
