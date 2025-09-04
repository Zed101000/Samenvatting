using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.AdapterPattern
{
    public class MonsterPlayerConverter : BasePlayer
    {
        public MonsterPlayerConverter(Monster monster)
            : base(
                $"Monster {monster.Name}",
                monster.Health / 2, // Health
                0,                  // Mana
                monster.AttackPower / 2, // AttackPower
                monster.Defense / 3, // Defense
                monster.Level        // Level
            )
        {
            // Additional initialization if needed
        }
    }
}