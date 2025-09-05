using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public interface ICombatStrategy
    {
        void ExecuteStrategy(IPlayer attacker, IMonster target);
        string GetStrategyName();
    }
}
