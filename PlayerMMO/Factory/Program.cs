using System;
using Factory.Pattern;
using GameBase.DefaultClasses;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Factory Method Pattern Demo ===\n");

            // Create factory manager
            PlayerFactoryManager factoryManager = new PlayerFactoryManager();

            // Show available classes
            factoryManager.ShowAvailableClasses();
            Console.WriteLine();

            // Create different types of players using different factories
            Console.WriteLine("Creating different player types:\n");

            // Create Warrior
            IPlayer warrior = factoryManager.CreatePlayer("warrior", "Thorin");
            warrior.Play();
            warrior.Attack();
            Console.WriteLine();

            // Create Mage
            IPlayer mage = factoryManager.CreatePlayer("mage", "Gandalf");
            mage.Play();
            mage.Attack();
            Console.WriteLine();

            // Create Rogue
            IPlayer rogue = factoryManager.CreatePlayer("rogue", "Shadow");
            rogue.Play();
            rogue.Attack();
            Console.WriteLine();

            // Create Paladin
            IPlayer paladin = factoryManager.CreatePlayer("paladin", "Arthur");
            paladin.Play();
            paladin.Attack();
            Console.WriteLine();

            // Try to create unknown class
            IPlayer unknown = factoryManager.CreatePlayer("necromancer", "DarkLord");
            unknown.Play();
            Console.WriteLine();

            // Demonstrate direct factory usage
            Console.WriteLine("=== Direct Factory Usage ===");
            PlayerFactory warriorFactory = new WarriorFactory();
            PlayerFactory mageFactory = new MageFactory();

            IPlayer warrior2 = warriorFactory.CreatePlayerWithStats("Conan");
            IPlayer mage2 = mageFactory.CreatePlayerWithStats("Merlin");

            Console.WriteLine();

            // Compare stats
            Console.WriteLine("=== Comparing Player Stats ===");
            List<IPlayer> players = new List<IPlayer> { warrior, mage, rogue, paladin };
            
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: Health={player.Health}, Mana={player.Mana}, Attack={player.AttackPower}, Defense={player.Defense}");
            }

            Console.WriteLine();

            // Demonstrate battle capabilities
            Console.WriteLine("=== Battle Test ===");
            IMonster testMonster = new Monster("Test Dummy", 10, 15, 100, 3);
            
            Console.WriteLine($"All players attack {testMonster.Name}:");
            foreach (var player in players)
            {
                int damage = Math.Max(1, player.AttackPower - testMonster.Defense);
                Console.WriteLine($"{player.Name} deals {damage} damage (Attack: {player.AttackPower} - Defense: {testMonster.Defense})");
            }
        }
    }
}
