using GameBase.DefaultClasses;

namespace Factory.Pattern
{
    public class PlayerFactoryManager
    {
        private Dictionary<string, PlayerFactory> _factories;

        public PlayerFactoryManager()
        {
            _factories = new Dictionary<string, PlayerFactory>
            {
                { "warrior", new WarriorFactory() },
                { "mage", new MageFactory() },
                { "rogue", new RogueFactory() },
                { "paladin", new PaladinFactory() }
            };
        }

        public IPlayer CreatePlayer(string className, string playerName)
        {
            string normalizedClass = className.ToLower();
            
            if (_factories.ContainsKey(normalizedClass))
            {
                return _factories[normalizedClass].CreatePlayerWithStats(playerName);
            }
            else
            {
                Console.WriteLine($"Unknown player class: {className}. Creating default player.");
                return new BasePlayer(playerName);
            }
        }

        public void RegisterFactory(string className, PlayerFactory factory)
        {
            _factories[className.ToLower()] = factory;
            Console.WriteLine($"Registered factory for class: {className}");
        }

        public List<string> GetAvailableClasses()
        {
            return new List<string>(_factories.Keys);
        }

        public void ShowAvailableClasses()
        {
            Console.WriteLine("Available player classes:");
            foreach (var className in _factories.Keys)
            {
                Console.WriteLine($"- {char.ToUpper(className[0])}{className.Substring(1)}");
            }
        }
    }
}
