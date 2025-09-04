using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public class Cave : ICave {
        public string[,] CaveMap { get; }
        public IMonster[,] CaveEnemiesMap { get; }

        public Cave(string[,] caveMap, IMonster[,] caveEnemiesMap) {
            CaveMap = caveMap;
            CaveEnemiesMap = caveEnemiesMap;
        }
    }
}
