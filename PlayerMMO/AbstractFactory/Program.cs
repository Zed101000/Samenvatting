using System;
using AbstractFactory.Pattern;
using GameBase.DefaultClasses;

namespace AbstractFactory {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== Abstract Factory Pattern Demo ===\n");

            // Create a player
            IPlayer player = new BasePlayer("Adventure Hero", 60, 12, 18, 120, 3);
            
            Console.WriteLine("Starting adventure with player:");
            Console.WriteLine($"Player: {player}\n");

            // Create different environment factories
            IGameEnvironmentFactory caveFactory = new CaveEnvironmentFactory();
            IGameEnvironmentFactory dungeonFactory = new DungeonEnvironmentFactory();

            // Create environment manager
            GameEnvironmentManager environmentManager = new GameEnvironmentManager(caveFactory);

            // Create Cave environment
            environmentManager.CreateGameEnvironment(player, 3);
            
            Console.WriteLine("\n" + new string('=', 60));
            
            // Switch to Dungeon environment
            environmentManager.SetFactory(dungeonFactory);
            
            // Restore player health for next adventure
            player.Health = 120;
            player.Mana = 60;
            
            environmentManager.CreateGameEnvironment(player, 4);

            Console.WriteLine("\n" + new string('=', 60));
            
            // Demonstrate direct factory usage
            Console.WriteLine("\n=== Direct Factory Usage ===");
            
            Console.WriteLine("\nCreating Cave environment directly:");
            ILevel caveLevel = caveFactory.CreateLevel();
            caveLevel.DisplayInfo();
            
            IMonster[] caveEnemies = caveFactory.CreateEnemies(2);
            Console.WriteLine("Cave enemies:");
            foreach (var enemy in caveEnemies)
            {
                Console.WriteLine($"- {enemy.Name}");
            }

            Console.WriteLine("\nCreating Dungeon environment directly:");
            ILevel dungeonLevel = dungeonFactory.CreateLevel();
            dungeonLevel.DisplayInfo();
            
            IMonster[] dungeonEnemies = dungeonFactory.CreateEnemies(2);
            Console.WriteLine("Dungeon enemies:");
            foreach (var enemy in dungeonEnemies)
            {
                Console.WriteLine($"- {enemy.Name}");
            }

            Console.WriteLine("\n=== Demo Complete ===");
        }
    }
}
