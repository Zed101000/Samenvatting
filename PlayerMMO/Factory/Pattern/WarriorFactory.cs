using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public class WarriorFactory : PlayerFactory
    {
        public override IPlayer CreatePlayer(string name)
        {
            LogCreation("Warrior", name);
            // Warriors have high health, moderate mana, high attack, high defense
            return new BasePlayer(name, 30, 18, 25, 180, 1); // mana, defense, attack, health, level
        }
    }
}
