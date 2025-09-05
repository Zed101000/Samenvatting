using GameBase.DefaultClasses;

namespace Strategy.Pattern
{
    public class MagicalStrategy : ICombatStrategy
    {
        public void ExecuteStrategy(IPlayer attacker, IMonster target)
        {
            Console.WriteLine($"=== {GetStrategyName()} ===");
            
            if (attacker.Mana < 20)
            {
                Console.WriteLine($"{attacker.Name} doesn't have enough mana for magical attack!");
                Console.WriteLine("Falling back to basic attack...");
                attacker.Attack();
                int basicDamage = Math.Max(1, (attacker.AttackPower / 2) - target.Defense);
                target.Health -= basicDamage;
                Console.WriteLine($"{target.Name} takes {basicDamage} basic damage. Health: {target.Health}");
                return;
            }
            
            Console.WriteLine($"{attacker.Name} casts a magical spell!");
            
            // Magical: High damage, high mana cost, ignores some defense
            int damage = (int)(attacker.AttackPower * 1.3); // 30% more damage
            int manaCost = 20;
            int defenseIgnored = target.Defense / 2; // Ignores half of target's defense
            
            attacker.Mana -= manaCost;
            target.Health -= Math.Max(1, damage - defenseIgnored);
            
            Console.WriteLine($"{attacker.Name} deals {damage} magical damage (ignoring {defenseIgnored} defense)");
            Console.WriteLine($"{attacker.Name} loses {manaCost} mana");
            Console.WriteLine($"{target.Name} health: {target.Health}");
        }

        public string GetStrategyName()
        {
            return "Magical Combat Strategy";
        }
    }
}
