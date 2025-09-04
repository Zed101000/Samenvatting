using GameBase.DefaultClasses;
using System;

namespace AbstractFactory.Pattern {
    public class GameFactoryCave : LevelFactory {
        public ICave CreateCave(int rows, int cols, string[] blocks, string[] enemyNames) {
            string[,] caveMap = CreateMap(rows, cols, blocks);
            IMonster[,] caveEnemies = CreateEnemies(rows, cols, enemyNames);
            return new Cave(caveMap, caveEnemies);
        }

        public IDungeon CreateDungeon(int rows, int cols, string[] blocks, string[] enemyNames) {
            throw new NotImplementedException();
        }

        private string[,] CreateMap(int rows, int cols, string[] blocks) {
            string[,] map = new string[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    map[i, j] = blocks[random.Next(blocks.Length)];
                }
            }

            return map;
        }

        private IMonster[,] CreateEnemies(int rows, int cols, string[] enemyNames) {
            IMonster[,] enemies = new IMonster[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (random.NextDouble() > 0.5) {
                        enemies[i, j] = new Monster(enemyNames[random.Next(enemyNames.Length)], 10, 15, 80, 1);
                    }
                }
            }

            return enemies;
        }
    }

    public class GameFactoryDungeon : LevelFactory {
        public IDungeon CreateDungeon(int rows, int cols, string[] blocks, string[] enemyNames) {
            string[,] dungeonMap = CreateMap(rows, cols, blocks);
            IMonster[,] dungeonEnemies = CreateEnemies(rows, cols, enemyNames);
            return new Dungeon(dungeonMap, dungeonEnemies);
        }

        public ICave CreateCave(int rows, int cols, string[] blocks, string[] enemyNames) {
            throw new NotImplementedException();
        }

        private string[,] CreateMap(int rows, int cols, string[] blocks) {
            string[,] map = new string[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    map[i, j] = blocks[random.Next(blocks.Length)];
                }
            }

            return map;
        }

        private IMonster[,] CreateEnemies(int rows, int cols, string[] enemyNames) {
            IMonster[,] enemies = new IMonster[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (random.NextDouble() > 0.5) {
                        enemies[i, j] = new Monster(enemyNames[random.Next(enemyNames.Length)], 20, 25, 120, 2);
                    }
                }
            }

            return enemies;
        }
    }
}
