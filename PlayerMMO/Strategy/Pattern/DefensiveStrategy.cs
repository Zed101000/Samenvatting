using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public class DefensiveStrategy : ICombatStrategy
    {
        public void ExecuteStrategy(IPlayer attacker, IMonster target)
        {
            Console.WriteLine($"=== {GetStrategyName()} ===");
            Console.WriteLine($"{attacker.Name} uses defensive combat style!");
            
            // Defensive: Lower damage, boosts defense, less mana cost
            attacker.Attack();
            attacker.Defend(); // Also calls defend
            
            int damage = (int)(attacker.AttackPower * 0.8); // 20% less damage
            int manaCost = 5;
            int defenseBoost = 5;
            
            attacker.Mana -= manaCost;
            attacker.Defense += defenseBoost; // Boost defense
            
            target.Health -= Math.Max(1, damage - target.Defense);
            
            Console.WriteLine($"{attacker.Name} deals {damage} careful damage");
            Console.WriteLine($"{attacker.Name} loses {manaCost} mana and gains {defenseBoost} defense");
            Console.WriteLine($"{target.Name} health: {target.Health}");
        }

        public string GetStrategyName()
        {
            return "Defensive Combat Strategy";
        }
    }
}
