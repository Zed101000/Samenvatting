using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public class Dungeon : IDungeon {
        public string[,] DungeonMap { get; }
        public IMonster[,] DungeonEnemiesMap { get; }

        public Dungeon(string[,] dungeonMap, IMonster[,] dungeonEnemiesMap) {
            DungeonMap = dungeonMap;
            DungeonEnemiesMap = dungeonEnemiesMap;
        }
    }
}
