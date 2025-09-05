using System;
using Iterator.Pattern;
using GameBase.DefaultClasses;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Iterator Pattern Demo ===\n");

            // Create a party
            PlayerParty adventureParty = new PlayerParty("The Heroes");

            // Add players to the party
            Console.WriteLine("Building the party:");
            adventureParty.Add(new BasePlayer("Aragorn", 60, 15, 22, 140, 5));
            adventureParty.Add(new BasePlayer("Legolas", 80, 8, 25, 110, 4));
            adventureParty.Add(new BasePlayer("Gimli", 40, 20, 28, 160, 6));
            adventureParty.Add(new BasePlayer("Gandalf", 120, 5, 30, 90, 10));
            adventureParty.Add(new BasePlayer("Boromir", 50, 18, 24, 150, 5));

            // Show party info using internal iteration
            adventureParty.ShowPartyInfo();

            // Demonstrate forward iteration
            Console.WriteLine("=== Forward Iteration ===");
            var forwardIterator = adventureParty.CreateIterator();
            int position = 1;
            while (forwardIterator.HasNext())
            {
                var player = forwardIterator.Next();
                Console.WriteLine($"{position}. {player.Name} - Level {player.Level}");
                position++;
            }
            Console.WriteLine();

            // Demonstrate reverse iteration
            Console.WriteLine("=== Reverse Iteration ===");
            var reverseIterator = adventureParty.CreateReverseIterator();
            position = adventureParty.Count;
            while (reverseIterator.HasNext())
            {
                var player = reverseIterator.Next();
                Console.WriteLine($"{position}. {player.Name} - Level {player.Level}");
                position--;
            }
            Console.WriteLine();

            // Demonstrate filtered iteration - High level players
            Console.WriteLine("=== Filtered Iteration (Level >= 5) ===");
            var highLevelIterator = adventureParty.CreateFilteredIterator(p => p.Level >= 5);
            while (highLevelIterator.HasNext())
            {
                var player = highLevelIterator.Next();
                Console.WriteLine($"- {player.Name} (Level {player.Level})");
            }
            Console.WriteLine();

            // Demonstrate filtered iteration - High mana players
            Console.WriteLine("=== Filtered Iteration (Mana >= 70) ===");
            var highManaIterator = adventureParty.CreateFilteredIterator(p => p.Mana >= 70);
            while (highManaIterator.HasNext())
            {
                var player = highManaIterator.Next();
                Console.WriteLine($"- {player.Name} (Mana: {player.Mana})");
            }
            Console.WriteLine();

            // Demonstrate iterator reset functionality
            Console.WriteLine("=== Testing Iterator Reset ===");
            var testIterator = adventureParty.CreateIterator();
            
            Console.WriteLine("First iteration (first 2 players):");
            for (int i = 0; i < 2 && testIterator.HasNext(); i++)
            {
                var player = testIterator.Next();
                Console.WriteLine($"- {player.Name}");
            }
            
            Console.WriteLine("Resetting iterator...");
            testIterator.Reset();
            
            Console.WriteLine("After reset (all players):");
            while (testIterator.HasNext())
            {
                var player = testIterator.Next();
                Console.WriteLine($"- {player.Name}");
            }
            Console.WriteLine();

            // Simulate party operations
            Console.WriteLine("=== Party Operations ===");
            
            // Remove a player
            var boromir = adventureParty.CreateIterator();
            while (boromir.HasNext())
            {
                var player = boromir.Next();
                if (player.Name == "Boromir")
                {
                    adventureParty.Remove(player);
                    break;
                }
            }

            // Show updated party
            adventureParty.ShowPartyInfo();

            // Demonstrate battle turn order using iterator
            Console.WriteLine("=== Battle Turn Order ===");
            var battleIterator = adventureParty.CreateIterator();
            int turn = 1;
            while (battleIterator.HasNext())
            {
                var player = battleIterator.Next();
                Console.WriteLine($"Turn {turn}: {player.Name} attacks!");
                player.Attack();
                turn++;
            }
        }
    }
}
