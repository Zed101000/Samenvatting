using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ItemsDecorator
{
    public class SwordDecorator : PlayerDecorator
    {
        public SwordDecorator(IPlayer iplayer) : base(iplayer) { 
        }

        public override void Attack()
        {
            Console.WriteLine($"{this.Name} Attacks with Sword");
        }

        public override IPlayer Unequip()
        {
            Console.WriteLine($"{this.Name} lays down their sword and carries on");
            return this._player.Unequip();
        }
    }
}
