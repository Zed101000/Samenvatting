using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern {
    public interface IGameEnvironmentFactory {
        ILevel CreateLevel();
        IMonster[] CreateEnemies(int count);
        string GetEnvironmentName();
    }

    public interface ILevel {
        string Name { get; }
        string Description { get; }
        void Initialize();
        void DisplayInfo();
    }
}
