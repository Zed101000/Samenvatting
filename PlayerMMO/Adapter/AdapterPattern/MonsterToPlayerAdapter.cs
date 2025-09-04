using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.AdapterPattern
{
    public class MonsterToPlayerAdapter : IPlayer
    {
        private readonly MonsterPlayerConverter _player;

        public MonsterToPlayerAdapter(Monster monster)
        {
            this._player = new MonsterPlayerConverter(monster);
            UnequipNumber = 3;
        }

        public string Name => _player.Name;

        private int UnequipNumber;
        public int Mana { get => _player.Mana; set => _player.Mana = value; }
        public int Defense { get => _player.Defense; set => _player.Defense = value; }
        public int AttackPower { get => _player.AttackPower; set => _player.AttackPower = value; }
        public int Health { get => _player.Health; set => _player.Health = value; }
        public int Level { get => _player.Level; set => _player.Level = value; }

        public void Attack()
        {
            this._player.Attack();
        }

        public void Defend()
        {
            this._player.Defend();
        }

        public void Heal()
        {
            Console.WriteLine("This being used to be a monster and cannot heal");
        }

        public void Play()
        {
            this._player.Play();
        }

        public IPlayer Unequip()
        {
            if (this.UnequipNumber == 0)
            {
                Console.WriteLine($"You pull at the equipment but it doesnt come loose try {this.UnequipNumber} more times");
                this.UnequipNumber--;
                return this;
            }
            else
            {
                Console.WriteLine($"You pull at the equipment but it doesnt come loose try {this.UnequipNumber} more times");
                this.UnequipNumber = 3;
                return this._player.Unequip();
            }
        }
    }
}
