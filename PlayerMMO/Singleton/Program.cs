using System;
using Singleton.Pattern;
using GameBase.DefaultClasses;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Singleton Pattern Demo ===\n");

            // Demonstrate that GameManager is a singleton
            Console.WriteLine("Testing Singleton behavior:");
            GameManager gm1 = GameManager.Instance;
            GameManager gm2 = GameManager.Instance;
            
            Console.WriteLine($"GameManager instance 1: {gm1.GetHashCode()}");
            Console.WriteLine($"GameManager instance 2: {gm2.GetHashCode()}");
            Console.WriteLine($"Are they the same instance? {ReferenceEquals(gm1, gm2)}\n");

            // Use the GameManager
            GameManager gameManager = GameManager.Instance;

            // Create players and monsters
            IPlayer warrior = new BasePlayer("Warrior", 60, 15, 20, 150, 3);
            IPlayer mage = new BasePlayer("Mage", 80, 5, 25, 100, 3);
            
            IMonster goblin = new Monster("Goblin", 8, 12, 60, 2);
            IMonster orc = new Monster("Orc", 12, 18, 100, 4);
            IMonster dragon = new Monster("Dragon", 20, 30, 200, 8);

            // Register entities with GameManager
            Console.WriteLine("Registering game entities:");
            gameManager.RegisterPlayer(warrior);
            gameManager.RegisterPlayer(mage);
            gameManager.RegisterMonster(goblin);
            gameManager.RegisterMonster(orc);
            gameManager.RegisterMonster(dragon);

            Console.WriteLine();

            // Start the game
            gameManager.StartGame();
            gameManager.ShowGameStatus();

            // Simulate game progression
            Console.WriteLine("=== Game Simulation ===");
            
            // Level 1 battles
            Console.WriteLine("Level 1 - Basic Encounters:");
            gameManager.ProcessCombat(warrior, goblin);
            gameManager.ProcessCombat(mage, orc);
            
            gameManager.ShowGameStatus();

            // Advance to next level
            gameManager.NextLevel();
            
            // Level 2 battles
            Console.WriteLine("Level 2 - Dragon Boss Battle:");
            gameManager.ProcessCombat(warrior, dragon);
            gameManager.ProcessCombat(mage, dragon); // Both players vs dragon
            
            gameManager.ShowGameStatus();

            // Advance level again
            gameManager.NextLevel();
            gameManager.ShowGameStatus();

            // Test accessing the same GameManager from different "parts" of the game
            Console.WriteLine("=== Testing Singleton Access from Different Contexts ===");
            SimulateOtherGameSystem();
            
            // End the game
            gameManager.EndGame();
            gameManager.ShowGameStatus();
        }

        // Simulate another part of the game system accessing the same GameManager
        static void SimulateOtherGameSystem()
        {
            Console.WriteLine("Another game system accessing GameManager...");
            GameManager samegameManager = GameManager.Instance;
            
            Console.WriteLine($"Current level from other system: {samegameManager.GetCurrentLevel()}");
            Console.WriteLine($"Current score from other system: {samegameManager.GetTotalScore()}");
            
            // Add some bonus score from this "other system"
            samegameManager.AddScore(250);
            Console.WriteLine("Bonus score added from other system!");
        }
    }
}
