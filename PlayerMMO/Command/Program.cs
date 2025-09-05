using System;
using Command.Pattern;
using GameBase.DefaultClasses;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Command Pattern Demo ===\n");

            // Create game entities
            IPlayer player = new BasePlayer("Hero", 100, 50, 15, 10, 5);
            IMonster monster = new Monster("Goblin", 5, 12, 60, 3);

            // Create game invoker
            GameInvoker gameInvoker = new GameInvoker();

            // Display initial states
            Console.WriteLine("Initial States:");
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Monster: {monster}\n");

            // Execute commands
            Console.WriteLine("=== Executing Commands ===");
            
            // Attack command
            ICommand attackCommand = new AttackCommand(player, monster);
            gameInvoker.ExecuteCommand(attackCommand);
            Console.WriteLine();

            // Heal command
            ICommand healCommand = new HealCommand(player, 15);
            gameInvoker.ExecuteCommand(healCommand);
            Console.WriteLine();

            // Defend command
            ICommand defendCommand = new DefendCommand(player, 8);
            gameInvoker.ExecuteCommand(defendCommand);
            Console.WriteLine();

            // Another attack
            ICommand attackCommand2 = new AttackCommand(player, monster);
            gameInvoker.ExecuteCommand(attackCommand2);
            Console.WriteLine();

            // Show current states
            Console.WriteLine("Current States:");
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Monster: {monster}");
            Console.WriteLine($"Commands in history: {gameInvoker.GetHistoryCount()}\n");

            // Undo commands
            Console.WriteLine("=== Undoing Commands ===");
            gameInvoker.UndoLastCommand();
            Console.WriteLine();
            
            gameInvoker.UndoLastCommand();
            Console.WriteLine();

            Console.WriteLine("After undoing 2 commands:");
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Monster: {monster}");
            Console.WriteLine($"Commands in history: {gameInvoker.GetHistoryCount()}\n");

            // Undo multiple commands at once
            Console.WriteLine("=== Undoing Multiple Commands ===");
            gameInvoker.UndoMultipleCommands(2);
            Console.WriteLine();

            Console.WriteLine("Final States:");
            Console.WriteLine($"Player: {player}");
            Console.WriteLine($"Monster: {monster}");
            Console.WriteLine($"Commands in history: {gameInvoker.GetHistoryCount()}");
        }
    }
}
