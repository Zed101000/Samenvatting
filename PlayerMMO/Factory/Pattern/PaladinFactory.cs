using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public class PaladinFactory : PlayerFactory
    {
        public override IPlayer CreatePlayer(string name)
        {
            LogCreation("Paladin", name);
            // Paladins have high health, high mana, moderate attack, very high defense
            return new BasePlayer(name, 90, 25, 16, 160, 1); // mana, defense, attack, health, level
        }
    }
}
