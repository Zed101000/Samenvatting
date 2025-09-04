using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public class GameFactoryDungeon : LevelFactory {
        private readonly GameMapFactory _mapFactory = new GameMapFactory();
        private readonly GameEnemyMapFactory _enemyFactory = new GameEnemyMapFactory();

        public IDungeon CreateDungeon() {
            string[,] dungeonMap = _mapFactory.CreateDungeonMap(3, 3);
            IMonster[,] dungeonEnemies = _enemyFactory.CreateDungeonEnemies(3, 3);
            return new Dungeon(dungeonMap, dungeonEnemies);
        }

        public ICave CreateCave() {
            throw new System.NotImplementedException();
        }
    }
}
