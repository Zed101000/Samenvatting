namespace State.Pattern
{
    public class InjuredState : IPlayerState
    {
        public void Attack(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} attacks weakly due to injuries!");
            Console.WriteLine($"{context.Player.Name} - Injured attack!");
            context.Player.Mana -= 3; // Less mana cost when injured
        }

        public void Defend(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} defends poorly due to injuries!");
            context.Player.Defend();
            context.Player.Defense += 1; // Less defense boost
        }

        public void Heal(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} heals slowly while injured!");
            context.Player.Heal();
            context.Player.Health += 10; // Less healing
            context.Player.Mana -= 8;
        }

        public void Play(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} plays cautiously while injured!");
            context.Player.Play();
        }

        public void CheckStateTransition(PlayerContext context)
        {
            double healthPercentage = context.GetHealthPercentage();
            
            if (healthPercentage <= 0.3)
            {
                context.SetState(new CriticalState());
            }
            else if (healthPercentage >= 0.8)
            {
                context.SetState(new HealthyState());
            }
            else if (context.HasLowMana())
            {
                context.SetState(new ExhaustedState());
            }
        }
    }
}
