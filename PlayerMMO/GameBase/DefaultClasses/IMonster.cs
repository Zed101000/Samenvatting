using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.DefaultClasses
{
    public interface IMonster
    {
        string Name { get; }
        int Defense { set; get; }
        int AttackPower { set; get; }
        int Health { set; get; }
        int Level { set; get; }

        void Roar();
        void Attack();
        void Defend();


    }
}
