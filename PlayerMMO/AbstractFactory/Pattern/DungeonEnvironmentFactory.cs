using GameBase.DefaultClasses;

namespace AbstractFactory.Pattern
{
    public class DungeonEnvironmentFactory : IGameEnvironmentFactory
    {
        public ILevel CreateLevel()
        {
            return new DungeonLevel();
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
                        enemies[i] = new Monster("Skeleton Warrior", 8, 14, 50, 3);
                        break;
                    case 2:
                        enemies[i] = new Monster("Dark Mage", 4, 18, 40, 4);
                        break;
                    case 3:
                        enemies[i] = new Monster("Dungeon Guardian", 20, 22, 120, 6);
                        break;
                }
            }

            return enemies;
        }

        public string GetEnvironmentName()
        {
            return "Dungeon Environment";
        }
    }
}
