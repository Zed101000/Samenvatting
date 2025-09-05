using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern
{
    public class CaveEnvironmentFactory : IGameEnvironmentFactory
    {
        public ILevel CreateLevel()
        {
            return new CaveLevel();
        }

        public IMonster[] CreateEnemies(int count)
        {
            IMonster[] enemies = new IMonster[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int enemyType = random.Next(1, 4);
                switch (enemyType)
                {
                    case 1:
                        enemies[i] = new Monster("Cave Bat", 3, 8, 25, 1);
                        break;
                    case 2:
                        enemies[i] = new Monster("Rock Golem", 15, 12, 80, 4);
                        break;
                    case 3:
                        enemies[i] = new Monster("Crystal Spider", 5, 10, 35, 2);
                        break;
                }
            }

            return enemies;
        }

        public string GetEnvironmentName()
        {
            return "Cave Environment";
        }
    }
}
