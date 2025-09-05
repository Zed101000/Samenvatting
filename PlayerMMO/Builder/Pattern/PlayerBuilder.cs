using GameBase.DefaultClasses;

namespace Builder.Pattern
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private string _name = "Default Player";
        private int _health = 100;
        private int _mana = 50;
        private int _attackPower = 10;
        private int _defense = 5;
        private int _level = 1;

        public IPlayerBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPlayerBuilder SetHealth(int health)
        {
            _health = health;
            return this;
        }

        public IPlayerBuilder SetMana(int mana)
        {
            _mana = mana;
            return this;
        }

        public IPlayerBuilder SetAttackPower(int attackPower)
        {
            _attackPower = attackPower;
            return this;
        }

        public IPlayerBuilder SetDefense(int defense)
        {
            _defense = defense;
            return this;
        }

        public IPlayerBuilder SetLevel(int level)
        {
            _level = level;
            return this;
        }

        public IPlayer Build()
        {
            return new BasePlayer(_name, _mana, _defense, _attackPower, _health, _level);
        }

        public void Reset()
        {
            _name = "Default Player";
            _health = 100;
            _mana = 50;
            _attackPower = 10;
            _defense = 5;
            _level = 1;
        }
    }
}
