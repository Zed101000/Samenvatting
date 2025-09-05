using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public class MageFactory : PlayerFactory
    {
        public override IPlayer CreatePlayer(string name)
        {
            LogCreation("Mage", name);
            // Mages have low health, high mana, moderate attack, low defense
            return new BasePlayer(name, 120, 3, 18, 80, 1); // mana, defense, attack, health, level
        }
    }
}
