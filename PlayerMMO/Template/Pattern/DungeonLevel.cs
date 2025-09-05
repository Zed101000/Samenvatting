using GameBase.DefaultClasses;

namespace Template.Pattern
{
    public class DungeonLevel : GameLevelTemplate
    {
        private int _currentEnemyIndex = 0;

        public DungeonLevel(IPlayer player) : base(player)
        {
        }

        protected override string GetLevelName()
        {
            return "Dark Dungeon Level";
        }

        protected override void InitializeLevel()
        {
            Console.WriteLine("The dungeon is dark and foreboding...");
            Console.WriteLine("Ancient torches flicker on the walls.");
            // Dungeon reduces initial mana
            _player.Mana = Math.Max(10, _player.Mana - 15);
            Console.WriteLine($"The dark atmosphere drains {_player.Name}'s mana by 15!");
        }

        protected override void SpawnEnemies()
        {
            _enemies.Add(new Monster("Skeleton Warrior", 8, 12, 60, 3));
            _enemies.Add(new Monster("Dark Mage", 5, 18, 45, 4));
            _enemies.Add(new Monster("Dungeon Boss", 15, 25, 120, 6));
            Console.WriteLine($"The dungeon contains {_enemies.Count} dangerous enemies!");
        }

        protected override void ShowLevelIntro()
        {
            Console.WriteLine($"{_player.Name} enters the dungeon with caution...");
            Console.WriteLine($"Player stats: {_player}");
            Console.WriteLine("The air is thick with danger!");
        }

        protected override void ExecuteLevelLoop()
        {
            if (_currentEnemyIndex < _enemies.Count)
            {
                IMonster currentEnemy = _enemies[_currentEnemyIndex];
                Console.WriteLine($"\n--- Dungeon Battle {_currentEnemyIndex + 1} ---");
                Battle(currentEnemy);
                
                if (currentEnemy.Health <= 0)
                {
                    _currentEnemyIndex++;
                    if (_currentEnemyIndex < _enemies.Count)
                    {
                        // Heal slightly between battles in dungeon
                        _player.Health += 10;
                        Console.WriteLine($"{_player.Name} catches breath between battles. +10 health");
                    }
                }
            }
        }

        protected override bool IsLevelComplete()
        {
            return _currentEnemyIndex >= _enemies.Count;
        }

        protected override void GiveReward()
        {
            base.GiveReward();
            // Dungeon gives extra defense boost
            _player.Defense += 3;
            Console.WriteLine("Dungeon completion bonus: +3 Defense!");
        }
    }
}
