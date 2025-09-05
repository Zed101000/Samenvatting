using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public class RogueFactory : PlayerFactory
    {
        public override IPlayer CreatePlayer(string name)
        {
            LogCreation("Rogue", name);
            // Rogues have moderate health, moderate mana, high attack, low defense
            return new BasePlayer(name, 70, 8, 22, 120, 1); // mana, defense, attack, health, level
        }
    }
}
