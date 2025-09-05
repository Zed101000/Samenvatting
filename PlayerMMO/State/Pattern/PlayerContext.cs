using GameBase.DefaultClasses;

namespace State.Pattern
{
    public class PlayerContext
    {
        private IPlayerState _currentState;
        private IPlayer _player;

        public PlayerContext(IPlayer player)
        {
            _player = player;
            _currentState = new HealthyState(); // Default state
        }

        public IPlayer Player => _player;
        public IPlayerState CurrentState => _currentState;

        public void SetState(IPlayerState state)
        {
            Console.WriteLine($"Player state changed to: {state.GetType().Name}");
            _currentState = state;
        }

        public void Attack()
        {
            _currentState.Attack(this);
            _currentState.CheckStateTransition(this);
        }

        public void Defend()
        {
            _currentState.Defend(this);
            _currentState.CheckStateTransition(this);
        }

        public void Heal()
        {
            _currentState.Heal(this);
            _currentState.CheckStateTransition(this);
        }

        public void Play()
        {
            _currentState.Play(this);
            _currentState.CheckStateTransition(this);
        }

        public double GetHealthPercentage()
        {
            // Assuming max health is at level 1 * 100
            int maxHealth = 100 + (_player.Level - 1) * 10;
            return (double)_player.Health / maxHealth;
        }

        public bool HasLowMana()
        {
            return _player.Mana < 20;
        }
    }
}
