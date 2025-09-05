using System;
using Strategy.Pattern;
using GameBase.DefaultClasses;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Strategy Pattern Demo ===\n");

            // Create game entities
            IPlayer player = new BasePlayer("Warrior", 100, 15, 20, 150, 5);
            IMonster goblin = new Monster("Goblin", 8, 10, 80, 3);
            IMonster orc = new Monster("Orc", 12, 15, 120, 5);
            IMonster dragon = new Monster("Dragon", 20, 25, 200, 10);

            // Create different strategies
            ICombatStrategy aggressiveStrategy = new AggressiveStrategy();
            ICombatStrategy defensiveStrategy = new DefensiveStrategy();
            ICombatStrategy balancedStrategy = new BalancedStrategy();
            ICombatStrategy magicalStrategy = new MagicalStrategy();

            // Create combat context with initial strategy
            CombatContext combatContext = new CombatContext(player, balancedStrategy);

            Console.WriteLine("Initial player stats:");
            Console.WriteLine($"Player: {player}\n");

            // Fight different enemies with different strategies
            Console.WriteLine("=== Battle 1: vs Goblin (Balanced Strategy) ===");
            combatContext.ExecuteCombat(goblin);

            Console.WriteLine("\n" + new string('=', 50));

            // Reset player stats and change strategy
            player.Health = 150;
            player.Mana = 100;
            player.Defense = 15;
            IMonster goblin2 = new Monster("Goblin2", 8, 10, 80, 3);

            Console.WriteLine("\n=== Battle 2: vs Goblin2 (Aggressive Strategy) ===");
            combatContext.SetStrategy(aggressiveStrategy);
            combatContext.ExecuteCombat(goblin2);

            Console.WriteLine("\n" + new string('=', 50));

            // Reset and fight stronger enemy with defensive strategy
            player.Health = 150;
            player.Mana = 100;
            player.Defense = 13; // Reduced from aggressive strategy
            
            Console.WriteLine("\n=== Battle 3: vs Orc (Defensive Strategy) ===");
            combatContext.SetStrategy(defensiveStrategy);
            combatContext.ExecuteCombat(orc);

            Console.WriteLine("\n" + new string('=', 50));

            // Reset and fight dragon with magical strategy
            player.Health = 150;
            player.Mana = 100;
            player.Defense = 20; // Boosted from defensive strategy
            
            Console.WriteLine("\n=== Battle 4: vs Dragon (Magical Strategy) ===");
            combatContext.SetStrategy(magicalStrategy);
            combatContext.ExecuteCombat(dragon);

            Console.WriteLine("\n" + new string('=', 50));

            // Demonstrate strategy switching during low mana
            player.Mana = 15; // Low mana
            IMonster dragon2 = new Monster("Dragon2", 20, 25, 200, 10);
            
            Console.WriteLine("\n=== Battle 5: vs Dragon2 (Magical Strategy with low mana) ===");
            combatContext.ExecuteCombat(dragon2);

            Console.WriteLine("\n=== Demo Complete ===");
            Console.WriteLine($"Final player stats: {player}");
        }
    }
}
