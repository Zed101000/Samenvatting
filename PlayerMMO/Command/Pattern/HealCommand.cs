using GameBase.DefaultClasses;

namespace Command.Pattern
{
    public class HealCommand : ICommand
    {
        private IPlayer _player;
        private int _previousHealth;
        private int _healAmount;

        public HealCommand(IPlayer player, int healAmount = 20)
        {
            _player = player;
            _healAmount = healAmount;
        }

        public void Execute()
        {
            _previousHealth = _player.Health;
            _player.Health += _healAmount;
            Console.WriteLine($"{_player.Name} heals for {_healAmount} HP! Health: {_player.Health}");
            _player.Heal();
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing heal for {_player.Name}");
            _player.Health = _previousHealth;
            Console.WriteLine($"Health restored to: {_player.Health}");
        }
    }
}
