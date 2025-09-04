using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public class GameFactoryCave : LevelFactory {
        private readonly GameMapFactory _mapFactory = new GameMapFactory();
        private readonly GameEnemyMapFactory _enemyFactory = new GameEnemyMapFactory();

        public ICave CreateCave() {
            string[,] caveMap = _mapFactory.CreateCaveMap(3, 3);
            IMonster[,] caveEnemies = _enemyFactory.CreateCaveEnemies(3, 3);
            return new Cave(caveMap, caveEnemies);
        }

        public IDungeon CreateDungeon() {
            throw new System.NotImplementedException();
        }
    }
}
