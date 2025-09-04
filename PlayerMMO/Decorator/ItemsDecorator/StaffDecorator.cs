using GameBase.DefaultClasses;
using Decorator.ItemsDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ItemsDecorator
{
    public class StaffDecorator : PlayerDecorator
    {
        public StaffDecorator(IPlayer iplayer) : base(iplayer) {
                }
        public override void Heal()
        {
            Console.WriteLine($"{this.Name} Heals with staff");
        }

        public override IPlayer Unequip()
        {
            Console.WriteLine($"{this.Name} lays down their staff and carries on");
            return this._player.Unequip();
        }

    }
}
