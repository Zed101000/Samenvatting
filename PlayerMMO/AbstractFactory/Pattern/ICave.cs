using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public interface ICave : ILevel {
        string[,] CaveMap();
        IMonster[,] CaveEnemies();
    }
}
