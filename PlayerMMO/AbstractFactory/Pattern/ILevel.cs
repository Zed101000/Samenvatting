namespace AbstractFactory.Pattern {
    public interface ILevel {
        string[,] LevelMap();
        object[,] EnemiesMap();
        string GetLevelDetails();
    }
}
