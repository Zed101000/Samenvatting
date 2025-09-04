using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public class ConcreteLevel : ILevel {
        private readonly string[,] _levelMap;
        private readonly IMonster[,] _enemiesMap;

        public ConcreteLevel(string[,] levelMap, IMonster[,] enemiesMap) {
            _levelMap = levelMap;
            _enemiesMap = enemiesMap;
        }

        public string[,] LevelMap() {
            return _levelMap;
        }

        public IMonster[,] EnemiesMap() {
            return _enemiesMap;
        }

        public string GetLevelDetails() {
            int rows = _levelMap.GetLength(0);
            int cols = _levelMap.GetLength(1);

            string details = "Level Map:\n";

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    details += _levelMap[i, j] + " ";
                }
                details += "\n";
            }

            details += "\nEnemies Map:\n";

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    details += _enemiesMap[i, j]?.Name ?? "Empty" + " ";
                }
                details += "\n";
            }

            return details;
        }
    }
}