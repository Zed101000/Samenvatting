using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern
{
    public class CaveLevel : ILevel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CaveLevel()
        {
            Name = "Crystal Cave";
            Description = "A mysterious cave filled with glowing crystals and hidden treasures.";
        }

        public void Initialize()
        {
            Console.WriteLine($"Initializing {Name}...");
            Console.WriteLine("The cave walls shimmer with magical energy.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Level: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine("Environment: Cool, damp cave with crystal formations");
        }
    }
}
