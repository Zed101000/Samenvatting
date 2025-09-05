using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern
{
    public class DungeonLevel : ILevel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public DungeonLevel()
        {
            Name = "Dark Dungeon";
            Description = "A foreboding underground fortress filled with ancient evil.";
        }

        public void Initialize()
        {
            Console.WriteLine($"Initializing {Name}...");
            Console.WriteLine("Torches flicker ominously on the stone walls.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Level: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine("Environment: Dark stone corridors with ancient architecture");
        }
    }
}
