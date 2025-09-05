using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public abstract class PlayerFactory
    {
        // Factory method that subclasses must implement
        public abstract IPlayer CreatePlayer(string name);
        
        // Template method that uses the factory method
        public IPlayer CreatePlayerWithStats(string name)
        {
            IPlayer player = CreatePlayer(name);
            Console.WriteLine($"Created {player.GetType().Name}: {player}");
            return player;
        }
        
        // Common functionality that all factories can use
        protected void LogCreation(string playerType, string name)
        {
            Console.WriteLine($"Factory creating {playerType} named {name}");
        }
    }
}
