using System;
using State.Pattern;
using GameBase.DefaultClasses;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== State Pattern Demo ===\n");

            // Create a player and context
            IPlayer player = new BasePlayer("Hero", 50, 8, 15, 100, 3);
            PlayerContext playerContext = new PlayerContext(player);

            Console.WriteLine("Initial player state:");
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");

            // Demonstrate state transitions through actions
            Console.WriteLine("=== Player Actions ===");
            
            // Start playing
            playerContext.Play();
            Console.WriteLine($"Player: {player}\n");

            // Attack multiple times to drain mana
            Console.WriteLine("Attacking multiple times...");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"Attack {i + 1}:");
                playerContext.Attack();
                Console.WriteLine($"Player: {player}");
                Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");
            }

            // Try to heal while exhausted
            Console.WriteLine("Trying to heal while exhausted:");
            playerContext.Heal();
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");

            // Heal more to recover
            Console.WriteLine("Healing more to recover:");
            playerContext.Heal();
            playerContext.Heal();
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");

            // Simulate taking damage to show injury states
            Console.WriteLine("Simulating battle damage...");
            player.Health = 40; // Injured state
            playerContext.Attack();
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");

            // Critical state
            player.Health = 25; // Critical state
            playerContext.Defend();
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}\n");

            // Heal back to health
            Console.WriteLine("Healing back to full health...");
            player.Health = 90;
            player.Mana = 50;
            playerContext.Play();
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Current State: {playerContext.CurrentState.GetType().Name}");
        }
    }
}
