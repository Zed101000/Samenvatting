using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.AdapterPattern
{
    public class PlayerToMonsterAdapter : IMonster
    {
        private readonly IMonster _monster;

        public PlayerToMonsterAdapter(BasePlayer player) {
            this._monster =new PlayerMonsterConverter(player);
        }

        public string Name => _monster.Name;

        public int Defense { get => _monster.Defense; set => _monster.Defense = value; }
        public int AttackPower { get => _monster.AttackPower; set => _monster.AttackPower = value; }
        public int Health { get => _monster.Health; set => _monster.Health = value; }
        public int Level { get => _monster.Level; set => _monster.Level = value; }

        public void Attack()
        {
            Console.WriteLine($"{this.Name} Flails arms around like a human till it hits like a monster.");
        }

        public void Defend()
        {
            Console.WriteLine($"{this.Name} Defends  like a human but receives the impact easily.");
        }

        public void Roar()
        {
            Console.WriteLine($"{this.Name} Roars like a human possessed by anger.");
        }
    }
}
