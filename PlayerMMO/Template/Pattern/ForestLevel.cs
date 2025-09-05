using GameBase.DefaultClasses;

namespace Template.Pattern
{
    public class ForestLevel : GameLevelTemplate
    {
        private int _enemiesDefeated = 0;
        private int _totalEnemies = 3;

        public ForestLevel(IPlayer player) : base(player)
        {
        }

        protected override string GetLevelName()
        {
            return "Enchanted Forest Level";
        }

        protected override void InitializeLevel()
        {
            Console.WriteLine("The forest is lush and green...");
            Console.WriteLine("Magical energy flows through the trees.");
            // Forest restores some mana
            _player.Mana += 20;
            Console.WriteLine($"The forest's magic restores {_player.Name}'s mana by 20!");
        }

        protected override void SpawnEnemies()
        {
            _enemies.Add(new Monster("Forest Wolf", 6, 14, 50, 2));
            _enemies.Add(new Monster("Angry Bear", 10, 16, 80, 4));
            _enemies.Add(new Monster("Forest Troll", 12, 20, 100, 5));
            Console.WriteLine($"The forest is home to {_enemies.Count} wild creatures!");
        }

        protected override void ShowLevelIntro()
        {
            Console.WriteLine($"{_player.Name} steps into the magical forest...");
            Console.WriteLine($"Player stats: {_player}");
            Console.WriteLine("The forest whispers ancient secrets...");
        }

        protected override void ExecuteLevelLoop()
        {
            if (_enemiesDefeated < _totalEnemies)
            {
                IMonster currentEnemy = _enemies[_enemiesDefeated];
                Console.WriteLine($"\n--- Forest Encounter {_enemiesDefeated + 1} ---");
                Console.WriteLine("A rustling in the bushes...");
                
                Battle(currentEnemy);
                
                if (currentEnemy.Health <= 0)
                {
                    _enemiesDefeated++;
                    // Forest gives mana restoration after each battle
                    _player.Mana += 15;
                    Console.WriteLine($"The forest magic restores {_player.Name}'s mana by 15!");
                }
            }
        }

        protected override bool IsLevelComplete()
        {
            return _enemiesDefeated >= _totalEnemies;
        }

        protected override void GiveReward()
        {
            base.GiveReward();
            // Forest gives extra mana boost
            _player.Mana += 25;
            Console.WriteLine("Forest completion bonus: +25 Mana!");
        }
    }
}
