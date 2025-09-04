using GameBase.DefaultClasses;
using System;

namespace Decorator.ItemsDecorator
{
    public abstract class PlayerDecorator : IPlayer
    {
        protected IPlayer _player; // the wrapped player

        public string Name => _player.Name; // delegate to wrapped player
        public int Health
        {
            get => _player.Health;
            set => _player.Health = value;
        }
        public int Mana
        {
            get => _player.Mana;
            set => _player.Mana = value;
        }
        public int AttackPower
        {
            get => _player.AttackPower;
            set => _player.AttackPower = value;
        }
        public int Defense
        {
            get => _player.Defense;
            set => _player.Defense = value;
        }
        public int Level
        {
            get => _player.Level;
            set => _player.Level = value;
        }

        protected PlayerDecorator(IPlayer player)
        {
            _player = player;
        }

        // Base behavior delegates to wrapped player
        public virtual void Play()
        {
            _player.Play(); // delegate
        }

        public virtual void Attack() {
            _player.Attack();
        }
        public virtual void Defend() {
            _player.Defend();
        }
        public virtual void Heal() { 
            _player.Heal();
        }
        public virtual IPlayer Unequip()
        {
            return this._player;
        }

        public override string ToString()
        {
            return $"{Name} - Health: {Health}, Mana: {Mana}, Attack: {AttackPower}, Defense: {Defense}, Level: {Level}";
        }
    }
}
