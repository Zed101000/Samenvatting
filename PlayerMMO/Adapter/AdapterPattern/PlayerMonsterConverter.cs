using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.AdapterPattern
{
    public class PlayerMonsterConverter : Monster
    {
        public PlayerMonsterConverter(BasePlayer player) : base(player.Name,player.Defense * 3, player.AttackPower * 2, player.Health * 2, player.Level)
        {
        }
    }
}
