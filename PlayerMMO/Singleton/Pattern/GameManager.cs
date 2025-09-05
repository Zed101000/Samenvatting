using GameBase.DefaultClasses;

namespace Singleton.Pattern
{
    public sealed class GameManager
    {
        private static GameManager _instance = null;
        private static readonly object _lock = new object();
        
        private List<IPlayer> _activePlayers;
        private List<IMonster> _activeMonsters;
        private int _currentLevel;
        private int _totalScore;
        private string _gameState;

        private GameManager()
        {
            _activePlayers = new List<IPlayer>();
            _activeMonsters = new List<IMonster>();
            _currentLevel = 1;
            _totalScore = 0;
            _gameState = "Initialized";
            Console.WriteLine("GameManager instance created!");
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void RegisterPlayer(IPlayer player)
        {
            _activePlayers.Add(player);
            Console.WriteLine($"Player {player.Name} registered with GameManager");
        }

        public void RegisterMonster(IMonster monster)
        {
            _activeMonsters.Add(monster);
            Console.WriteLine($"Monster {monster.Name} registered with GameManager");
        }

        public void StartGame()
        {
            _gameState = "Playing";
            Console.WriteLine("=== GAME STARTED ===");
            Console.WriteLine($"Level: {_currentLevel}");
            Console.WriteLine($"Active Players: {_activePlayers.Count}");
            Console.WriteLine($"Active Monsters: {_activeMonsters.Count}");
        }

        public void EndGame()
        {
            _gameState = "Ended";
            Console.WriteLine("=== GAME ENDED ===");
            Console.WriteLine($"Final Score: {_totalScore}");
            Console.WriteLine($"Levels Completed: {_currentLevel - 1}");
            
            // Clean up
            _activePlayers.Clear();
            _activeMonsters.Clear();
        }

        public void NextLevel()
        {
            _currentLevel++;
            _totalScore += 100 * _currentLevel;
            Console.WriteLine($"Advanced to Level {_currentLevel}! Score: {_totalScore}");
        }

        public void AddScore(int points)
        {
            _totalScore += points;
            Console.WriteLine($"Score added: {points}. Total score: {_totalScore}");
        }

        public void ShowGameStatus()
        {
            Console.WriteLine("\n=== GAME STATUS ===");
            Console.WriteLine($"Game State: {_gameState}");
            Console.WriteLine($"Current Level: {_currentLevel}");
            Console.WriteLine($"Total Score: {_totalScore}");
            Console.WriteLine($"Active Players: {_activePlayers.Count}");
            Console.WriteLine($"Active Monsters: {_activeMonsters.Count}");
            
            if (_activePlayers.Count > 0)
            {
                Console.WriteLine("Player Details:");
                foreach (var player in _activePlayers)
                {
                    Console.WriteLine($"  - {player}");
                }
            }
            
            if (_activeMonsters.Count > 0)
            {
                Console.WriteLine("Monster Details:");
                foreach (var monster in _activeMonsters)
                {
                    Console.WriteLine($"  - {monster}");
                }
            }
            Console.WriteLine("==================\n");
        }

        public void ProcessCombat(IPlayer player, IMonster monster)
        {
            Console.WriteLine($"GameManager processing combat: {player.Name} vs {monster.Name}");
            
            // Simple combat simulation
            int damage = Math.Max(1, player.AttackPower - monster.Defense);
            monster.Health -= damage;
            
            if (monster.Health <= 0)
            {
                Console.WriteLine($"{monster.Name} defeated!");
                AddScore(50);
                _activeMonsters.Remove(monster);
            }
            else
            {
                // Monster counter-attack
                int counterDamage = Math.Max(1, monster.AttackPower - player.Defense);
                player.Health -= counterDamage;
                Console.WriteLine($"{player.Name} takes {counterDamage} damage from {monster.Name}");
            }
        }

        public int GetCurrentLevel() => _currentLevel;
        public int GetTotalScore() => _totalScore;
        public string GetGameState() => _gameState;
        public List<IPlayer> GetActivePlayers() => new List<IPlayer>(_activePlayers);
        public List<IMonster> GetActiveMonsters() => new List<IMonster>(_activeMonsters);
    }
}
