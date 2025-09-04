using System;
using AbstractFactory.Pattern;
using GameBase.DefaultClasses;

namespace AbstractFactory {
    class Program {
        static void Main(string[] args) {
            LevelFactory caveFactory = new GameFactoryCave();
            LevelFactory dungeonFactory = new GameFactoryDungeon();

            int rows = 5;
            int cols = 5;

            string[,] caveMap = caveFactory.CreateCaveMap(rows, cols);
            IMonster[,] caveEnemies = caveFactory.CreateCaveEnemies(rows, cols);

            string[,] dungeonMap = dungeonFactory.CreateDungeonMap(rows, cols);
            IMonster[,] dungeonEnemies = dungeonFactory.CreateDungeonEnemies(rows, cols);

            Console.WriteLine("Cave Level:");
            PrintMap(caveMap);
            PrintEnemies(caveEnemies);

            Console.WriteLine("\nDungeon Level:");
            PrintMap(dungeonMap);
            PrintEnemies(dungeonEnemies);
        }

        static void PrintMap(string[,] map) {
            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PrintEnemies(IMonster[,] enemies) {
            for (int i = 0; i < enemies.GetLength(0); i++) {
                for (int j = 0; j < enemies.GetLength(1); j++) {
                    Console.Write((enemies[i, j]?.Name ?? "Empty") + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
