using GameBase.DefaultClasses;

namespace Template.Pattern
{
    public abstract class GameLevelTemplate
    {
        protected IPlayer _player;
        protected List<IMonster> _enemies;

        public GameLevelTemplate(IPlayer player)
        {
            _player = player;
            _enemies = new List<IMonster>();
        }

        // Template method that defines the algorithm
        public void PlayLevel()
        {
            Console.WriteLine($"=== Starting {GetLevelName()} ===");
            InitializeLevel();
            SpawnEnemies();
            ShowLevelIntro();
            
            while (!IsLevelComplete() && _player.Health > 0)
            {
                ExecuteLevelLoop();
            }
            
            FinishLevel();
            Console.WriteLine($"=== {GetLevelName()} Complete ===\n");
        }

        // Abstract methods that subclasses must implement
        protected abstract string GetLevelName();
        protected abstract void InitializeLevel();
        protected abstract void SpawnEnemies();
        protected abstract void ShowLevelIntro();
        protected abstract void ExecuteLevelLoop();
        protected abstract bool IsLevelComplete();

        // Hook method with default implementation (can be overridden)
        protected virtual void FinishLevel()
        {
            if (_player.Health > 0)
            {
                Console.WriteLine($"{_player.Name} completed the level!");
                GiveReward();
            }
            else
            {
                Console.WriteLine($"{_player.Name} was defeated...");
            }
        }

        protected virtual void GiveReward()
        {
            _player.Level++;
            _player.Health += 20;
            _player.Mana += 10;
            Console.WriteLine($"{_player.Name} gained a level! New level: {_player.Level}");
            Console.WriteLine($"Health and mana restored! {_player}");
        }

        protected void Battle(IMonster enemy)
        {
            Console.WriteLine($"{_player.Name} encounters {enemy.Name}!");
            
            while (enemy.Health > 0 && _player.Health > 0)
            {
                // Player attacks
                _player.Attack();
                int playerDamage = Math.Max(1, _player.AttackPower - enemy.Defense);
                enemy.Health -= playerDamage;
                Console.WriteLine($"{enemy.Name} takes {playerDamage} damage! Health: {enemy.Health}");
                
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} is defeated!");
                    break;
                }
                
                // Enemy counter-attacks
                enemy.Attack();
                int enemyDamage = Math.Max(1, enemy.AttackPower - _player.Defense);
                _player.Health -= enemyDamage;
                Console.WriteLine($"{_player.Name} takes {enemyDamage} damage! Health: {_player.Health}");
            }
        }
    }
}
