using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public class BalancedStrategy : ICombatStrategy
    {
        public void ExecuteStrategy(IPlayer attacker, IMonster target)
        {
            Console.WriteLine($"=== {GetStrategyName()} ===");
            Console.WriteLine($"{attacker.Name} uses balanced combat style!");
            
            // Balanced: Normal damage, moderate mana cost, slight defense boost
            attacker.Attack();
            
            int damage = attacker.AttackPower; // Normal damage
            int manaCost = 8;
            int defenseBoost = 1;
            
            attacker.Mana -= manaCost;
            attacker.Defense += defenseBoost; // Small defense boost
            
            target.Health -= Math.Max(1, damage - target.Defense);
            
            Console.WriteLine($"{attacker.Name} deals {damage} balanced damage");
            Console.WriteLine($"{attacker.Name} loses {manaCost} mana and gains {defenseBoost} defense");
            Console.WriteLine($"{target.Name} health: {target.Health}");
        }

        public string GetStrategyName()
        {
            return "Balanced Combat Strategy";
        }
    }
}
