using System;

namespace AbstractFactory.Pattern {
    public class GameMapFactory {
        public string[,] CreateCaveMap(int rows, int cols) {
            string[,] caveMap = new string[rows, cols];
            string[] blocks = { "Rock", "Stalagmite", "Sand" };
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    caveMap[i, j] = blocks[random.Next(blocks.Length)];
                }
            }

            return caveMap;
        }

        public string[,] CreateDungeonMap(int rows, int cols) {
            string[,] dungeonMap = new string[rows, cols];
            string[] blocks = { "Brick", "Stone", "Lava" };
            Random random = new Random();

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    dungeonMap[i, j] = blocks[random.Next(blocks.Length)];
                }
            }

            return dungeonMap;
        }
    }
}
