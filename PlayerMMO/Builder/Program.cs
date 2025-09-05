using System;
using Builder.Pattern;
using GameBase.DefaultClasses;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Builder Pattern Demo ===\n");

            // Create builder and director
            IPlayerBuilder builder = new PlayerBuilder();
            GamePlayerDirector director = new GamePlayerDirector(builder);

            // Create different types of players using director
            Console.WriteLine("Creating players using Director:");
            IPlayer warrior = director.CreateWarrior();
            Console.WriteLine($"Warrior: {warrior}");
            warrior.Play();
            warrior.Attack();

            builder.Reset();
            IPlayer mage = director.CreateMage();
            Console.WriteLine($"\nMage: {mage}");
            mage.Play();
            mage.Attack();

            builder.Reset();
            IPlayer rogue = director.CreateRogue();
            Console.WriteLine($"\nRogue: {rogue}");
            rogue.Play();
            rogue.Attack();

            // Create custom player using builder directly
            Console.WriteLine("\n\nCreating custom player using Builder directly:");
            IPlayer customPlayer = builder
                .SetName("Custom Hero")
                .SetHealth(200)
                .SetMana(100)
                .SetAttackPower(25)
                .SetDefense(20)
                .SetLevel(10)
                .Build();

            Console.WriteLine($"Custom Player: {customPlayer}");
            customPlayer.Play();
            customPlayer.Attack();
        }
    }
}
