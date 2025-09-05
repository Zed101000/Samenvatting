namespace State.Pattern
{
    public class HealthyState : IPlayerState
    {
        public void Attack(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} attacks with full power!");
            context.Player.Attack();
            context.Player.Mana -= 5; // Attack costs mana
        }

        public void Defend(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} defends effectively!");
            context.Player.Defend();
            context.Player.Defense += 2; // Temporary defense boost
        }

        public void Heal(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} heals quickly while healthy!");
            context.Player.Heal();
            context.Player.Health += 15;
            context.Player.Mana -= 10;
        }

        public void Play(PlayerContext context)
        {
            Console.WriteLine($"{context.Player.Name} plays with enthusiasm!");
            context.Player.Play();
        }

        public void CheckStateTransition(PlayerContext context)
        {
            double healthPercentage = context.GetHealthPercentage();
            
            if (healthPercentage <= 0.3)
            {
                context.SetState(new CriticalState());
            }
            else if (healthPercentage <= 0.5)
            {
                context.SetState(new InjuredState());
            }
            else if (context.HasLowMana())
            {
                context.SetState(new ExhaustedState());
            }
        }
    }
}
