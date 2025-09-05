using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public class AggressiveStrategy : ICombatStrategy
    {
        public void ExecuteStrategy(IPlayer attacker, IMonster target)
        {
            Console.WriteLine($"=== {GetStrategyName()} ===");
            Console.WriteLine($"{attacker.Name} uses aggressive combat style!");
            
            // Aggressive: High damage, costs more mana, reduces defense
            attacker.Attack();
            int damage = (int)(attacker.AttackPower * 1.5); // 50% more damage
            int manaCost = 15;
            
            attacker.Mana -= manaCost;
            attacker.Defense = Math.Max(1, attacker.Defense - 2); // Reduce defense temporarily
            
            target.Health -= Math.Max(1, damage - target.Defense);
            
            Console.WriteLine($"{attacker.Name} deals {damage} aggressive damage!");
            Console.WriteLine($"{attacker.Name} loses {manaCost} mana and 2 defense from reckless attack");
            Console.WriteLine($"{target.Name} health: {target.Health}");
        }

        public string GetStrategyName()
        {
            return "Aggressive Combat Strategy";
        }
    }
}
