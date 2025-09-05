namespace State.Pattern
{
    public class CriticalState : IPlayerState
    {
        public void Attack(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} can barely attack in critical condition!");
            Console.WriteLine($"{context.Player.Name} - Critical weak attack!");
            context.Player.Mana -= 1; // Minimal mana cost
        }

        public void Defend(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} barely defends in critical condition!");
            context.Player.Defend();
            // No defense boost in critical state
        }

        public void Heal(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} desperately tries to heal in critical condition!");
            context.Player.Heal();
            context.Player.Health += 5; // Minimal healing
            context.Player.Mana -= 5;
        }

        public void Play(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} struggles to continue in critical condition!");
            context.Player.Play();
        }

        public void CheckStateTransition(PlayerContext context)
        {
            double healthPercentage = context.GetHealthPercentage();
            
            if (context.Player.Health <= 0)
            {
                Console.WriteLine($"{context.Player.Name} has been defeated!");
                return;
            }
            
            if (healthPercentage > 0.5)
            {
                context.SetState(new InjuredState());
            }
            else if (healthPercentage > 0.8)
            {
                context.SetState(new HealthyState());
            }
        }
    }
}
