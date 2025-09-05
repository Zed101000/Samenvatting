using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public class CombatContext
    {
        private ICombatStrategy _strategy;
        private IPlayer _player;

        public CombatContext(IPlayer player, ICombatStrategy strategy)
        {
            _player = player;
            _strategy = strategy;
        }

        public void SetStrategy(ICombatStrategy strategy)
        {
            _strategy = strategy;
            Console.WriteLine($"Combat strategy changed to: {strategy.GetStrategyName()}");
        }

        public void ExecuteCombat(IMonster target)
        {
            Console.WriteLine($"\n{_player.Name} prepares for combat against {target.Name}");
            Console.WriteLine($"Player stats: {_player}");
            Console.WriteLine($"Target stats: {target}");
            
            _strategy.ExecuteStrategy(_player, target);
            
            Console.WriteLine($"After combat - Player: {_player}");
            Console.WriteLine($"After combat - Target: {target}");
        }

        public ICombatStrategy GetCurrentStrategy()
        {
            return _strategy;
        }
    }
}
