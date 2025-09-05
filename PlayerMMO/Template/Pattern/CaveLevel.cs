using GameBase.DefaultClasses;

namespace Template.Pattern
{
    public class CaveLevel : GameLevelTemplate
    {
        private int _turnsInCave = 0;
        private int _maxTurns = 5;
        private bool _treasureFound = false;

        public CaveLevel(IPlayer player) : base(player)
        {
        }

        protected override string GetLevelName()
        {
            return "Crystal Cave Level";
        }

        protected override void InitializeLevel()
        {
            Console.WriteLine("The cave glitters with precious crystals...");
            Console.WriteLine("The air is cool and echoes with mysterious sounds.");
            // Cave has neutral effect - no initial stat changes
            Console.WriteLine("The cave's crystals pulse with neutral energy.");
        }

        protected override void SpawnEnemies()
        {
            _enemies.Add(new Monster("Cave Bat", 4, 8, 30, 1));
            _enemies.Add(new Monster("Rock Golem", 18, 15, 90, 5));
            Console.WriteLine($"The cave shelters {_enemies.Count} creatures and hidden treasures!");
        }

        protected override void ShowLevelIntro()
        {
            Console.WriteLine($"{_player.Name} enters the sparkling crystal cave...");
            Console.WriteLine($"Player stats: {_player}");
            Console.WriteLine("The cave holds both danger and treasure...");
        }

        protected override void ExecuteLevelLoop()
        {
            _turnsInCave++;
            Console.WriteLine($"\n--- Cave Turn {_turnsInCave} ---");
            
            if (_turnsInCave <= 2 && _enemies.Count > 0)
            {
                // Fight enemies first
                IMonster currentEnemy = _enemies[0];
                Console.WriteLine("A creature emerges from the shadows...");
                Battle(currentEnemy);
                
                if (currentEnemy.Health <= 0)
                {
                    _enemies.RemoveAt(0);
                }
            }
            else if (!_treasureFound)
            {
                // Search for treasure
                Console.WriteLine($"{_player.Name} searches the cave for treasure...");
                if (new Random().Next(1, 4) == 1) // 33% chance
                {
                    _treasureFound = true;
                    Console.WriteLine("Found a crystal treasure!");
                    _player.AttackPower += 5;
                    _player.Health += 30;
                    Console.WriteLine("+5 Attack Power and +30 Health from crystal power!");
                }
                else
                {
                    Console.WriteLine("Nothing valuable found this time...");
                }
            }
        }

        protected override bool IsLevelComplete()
        {
            return _turnsInCave >= _maxTurns || (_enemies.Count == 0 && _treasureFound);
        }

        protected override void FinishLevel()
        {
            if (_treasureFound)
            {
                Console.WriteLine($"{_player.Name} found the cave treasure!");
            }
            else
            {
                Console.WriteLine($"{_player.Name} explored the cave but found no treasure.");
            }
            base.FinishLevel();
        }

        protected override void GiveReward()
        {
            base.GiveReward();
            // Cave gives balanced boost
            _player.AttackPower += 2;
            _player.Defense += 2;
            Console.WriteLine("Cave completion bonus: +2 Attack Power and +2 Defense!");
        }
    }
}
