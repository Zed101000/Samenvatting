namespace State.Pattern
{
    public class ExhaustedState : IPlayerState
    {
        public void Attack(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} is too exhausted to attack effectively!");
            Console.WriteLine($"{context.Player.Name} - Exhausted attack!");
            // Can't use mana when exhausted
        }

        public void Defend(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} defends while exhausted!");
            context.Player.Defend();
            // No defense boost when exhausted
        }

        public void Heal(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} rests to recover mana and health!");
            context.Player.Heal();
            context.Player.Health += 5;
            context.Player.Mana += 15; // Recover mana
        }

        public void Play(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} moves slowly while exhausted!");
            context.Player.Play();
        }

        public void CheckStateTransition(PlayerContext context)
        {
            double healthPercentage = context.GetHealthPercentage();
            
            if (context.Player.Mana >= 30)
            {
                if (healthPercentage <= 0.3)
                {
                    context.SetState(new CriticalState());
                }
                else if (healthPercentage <= 0.5)
                {
                    context.SetState(new InjuredState());
                }
                else
                {
                    context.SetState(new HealthyState());
                }
            }
        }
    }
}
