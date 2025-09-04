using GameBase.DefaultClasses;
using Decorator.ItemsDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ItemsDecorator
{
    public class ShieldDecorator : PlayerDecorator
    {
        public ShieldDecorator(IPlayer iplayer) : base(iplayer) {
        }

        public override void Defend()
        {
            Console.WriteLine($"{this.Name} Defends with shield");
        }
        public override IPlayer Unequip()
        {
            Console.WriteLine($"{this.Name} lays down their shield and carries on");
            return this._player.Unequip();
        }

    }
}
