using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern
{
    public class GameEnvironmentManager
    {
        private IGameEnvironmentFactory _factory;

        public GameEnvironmentManager(IGameEnvironmentFactory factory)
        {
            _factory = factory;
        }

        public void SetFactory(IGameEnvironmentFactory factory)
        {
            _factory = factory;
            Console.WriteLine($"Environment factory changed to: {factory.GetEnvironmentName()}");
        }

        public void CreateGameEnvironment(IPlayer player, int enemyCount = 3)
        {
            Console.WriteLine($"\n=== Creating {_factory.GetEnvironmentName()} ===");
            
            // Create level
            ILevel level = _factory.CreateLevel();
            level.Initialize();
            level.DisplayInfo();

            Console.WriteLine();

            // Create enemies
            IMonster[] enemies = _factory.CreateEnemies(enemyCount);
            Console.WriteLine($"Spawning {enemies.Length} enemies:");
            
            foreach (var enemy in enemies)
            {
                Console.WriteLine($"- {enemy.Name} (HP: {enemy.Health}, Attack: {enemy.AttackPower}, Defense: {enemy.Defense})");
            }

            Console.WriteLine();

            // Simulate player encounter
            Console.WriteLine($"{player.Name} enters the {level.Name}!");
            Console.WriteLine($"Player stats: {player}");
            
            // Battle simulation with first enemy
            if (enemies.Length > 0)
            {
                Console.WriteLine($"\n{player.Name} encounters the first enemy: {enemies[0].Name}!");
                SimulateBattle(player, enemies[0]);
            }
        }

        private void SimulateBattle(IPlayer player, IMonster enemy)
        {
            Console.WriteLine($"Battle begins: {player.Name} vs {enemy.Name}");
            
            int rounds = 0;
            while (player.Health > 0 && enemy.Health > 0 && rounds < 3)
            {
                rounds++;
                Console.WriteLine($"\n--- Round {rounds} ---");
                
                // Player attacks
                player.Attack();
                int playerDamage = Math.Max(1, player.AttackPower - enemy.Defense);
                enemy.Health -= playerDamage;
                Console.WriteLine($"{enemy.Name} takes {playerDamage} damage! Health: {Math.Max(0, enemy.Health)}");
                
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} is defeated!");
                    break;
                }
                
                // Enemy attacks
                enemy.Attack();
                int enemyDamage = Math.Max(1, enemy.AttackPower - player.Defense);
                player.Health -= enemyDamage;
                Console.WriteLine($"{player.Name} takes {enemyDamage} damage! Health: {Math.Max(0, player.Health)}");
                
                if (player.Health <= 0)
                {
                    Console.WriteLine($"{player.Name} is defeated!");
                    break;
                }
            }
            
            if (rounds >= 3 && player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("Battle continues but time limit reached for demo...");
            }
        }
    }
}
