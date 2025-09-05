using GameBase.DefaultClasses;

namespace Builder.Pattern
{
    public interface IPlayerBuilder
    {
        IPlayerBuilder SetName(string name);
        IPlayerBuilder SetHealth(int health);
        IPlayerBuilder SetMana(int mana);
        IPlayerBuilder SetAttackPower(int attackPower);
        IPlayerBuilder SetDefense(int defense);
        IPlayerBuilder SetLevel(int level);
        IPlayer Build();
        void Reset();
    }
}
