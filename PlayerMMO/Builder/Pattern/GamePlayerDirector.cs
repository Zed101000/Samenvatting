using GameBase.DefaultClasses;

namespace Builder.Pattern
{
    public class GamePlayerDirector
    {
        private IPlayerBuilder _builder;

        public GamePlayerDirector(IPlayerBuilder builder)
        {
            _builder = builder;
        }

        public IPlayer CreateWarrior()
        {
            return _builder
                .SetName("Warrior")
                .SetHealth(150)
                .SetMana(30)
                .SetAttackPower(20)
                .SetDefense(15)
                .SetLevel(5)
                .Build();
        }

        public IPlayer CreateMage()
        {
            return _builder
                .SetName("Mage")
                .SetHealth(80)
                .SetMana(120)
                .SetAttackPower(15)
                .SetDefense(5)
                .SetLevel(5)
                .Build();
        }

        public IPlayer CreateRogue()
        {
            return _builder
                .SetName("Rogue")
                .SetHealth(100)
                .SetMana(60)
                .SetAttackPower(18)
                .SetDefense(8)
                .SetLevel(5)
                .Build();
        }
    }
}
