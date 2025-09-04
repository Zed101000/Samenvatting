using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public interface IDungeon : ILevel {
        string[,] DungeonMap();
        IMonster[,] DungeonEnemies();
    }
}
