using GameBase.DefaultClasses;
using System;

namespace AbstractFactory.Pattern {
    public class GameEnemyMapFactory {
        public IMonster[,] CreateCaveEnemies(int rows, int cols) {
            IMonster[,] caveEnemies = new IMonster[rows, cols];
            string[] enemyNames = { "Bat", "Spider", "Snake" };
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (random.NextDouble() > 0.5) {
                        caveEnemies[i, j] = new Monster(enemyNames[random.Next(enemyNames.Length)], 10, 15, 80, 1);
                    }
                }
            }

            return caveEnemies;
        }

        public IMonster[,] CreateDungeonEnemies(int rows, int cols) {
            IMonster[,] dungeonEnemies = new IMonster[rows, cols];
            string[] enemyNames = { "Skeleton", "Zombie", "Demon" };
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (random.NextDouble() > 0.5) {
                        dungeonEnemies[i, j] = new Monster(enemyNames[random.Next(enemyNames.Length)], 20, 25, 120, 2);
                    }
                }
            }

            return dungeonEnemies;
        }
    }
}
