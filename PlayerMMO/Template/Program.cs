using System;
using Template.Pattern;
using GameBase.DefaultClasses;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Template Method Pattern Demo ===\n");

            // Create a player
            IPlayer player = new BasePlayer("Adventurer", 60, 12, 18, 120, 1);
            
            Console.WriteLine("Initial player stats:");
            Console.WriteLine($"Player: {player}\n");

            // Create different level types
            Console.WriteLine("The adventure begins! Choose your path through different levels...\n");

            // Play Forest Level
            GameLevelTemplate forestLevel = new ForestLevel(player);
            forestLevel.PlayLevel();

            // Check if player is still alive for next level
            if (player.Health <= 0)
            {
                Console.WriteLine("Adventure ended - player was defeated!");
                return;
            }

            Console.WriteLine($"After Forest - Player: {player}\n");

            // Play Cave Level
            GameLevelTemplate caveLevel = new CaveLevel(player);
            caveLevel.PlayLevel();

            // Check if player is still alive for next level
            if (player.Health <= 0)
            {
                Console.WriteLine("Adventure ended - player was defeated!");
                return;
            }

            Console.WriteLine($"After Cave - Player: {player}\n");

            // Play Dungeon Level (most challenging)
            GameLevelTemplate dungeonLevel = new DungeonLevel(player);
            dungeonLevel.PlayLevel();

            // Final results
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ADVENTURE COMPLETE!");
            Console.WriteLine($"Final player stats: {player}");
            
            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} successfully completed all levels!");
                Console.WriteLine("What a legendary adventure!");
            }
            else
            {
                Console.WriteLine($"{player.Name} fought valiantly but was ultimately defeated.");
                Console.WriteLine("Better luck next time!");
            }
        }
    }
}
