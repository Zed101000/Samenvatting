using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public interface LevelFactory {
        ICave CreateCave(GameMapFactory mapFactory, GameEnemyMapFactory enemyFactory);
        IDungeon CreateDungeon(GameMapFactory mapFactory, GameEnemyMapFactory enemyFactory);
    }
}
