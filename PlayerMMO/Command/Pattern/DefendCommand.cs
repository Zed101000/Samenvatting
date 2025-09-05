using GameBase.DefaultClasses;

namespace Command.Pattern
{
    public class DefendCommand : ICommand
    {
        private IPlayer _player;
        private int _previousDefense;
        private int _defenseBoost;

        public DefendCommand(IPlayer player, int defenseBoost = 5)
        {
            _player = player;
            _defenseBoost = defenseBoost;
        }

        public void Execute()
        {
            _previousDefense = _player.Defense;
            _player.Defense += _defenseBoost;
            Console.WriteLine($"{_player.Name} defends! Defense increased by {_defenseBoost}. Defense: {_player.Defense}");
            _player.Defend();
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing defense boost for {_player.Name}");
            _player.Defense = _previousDefense;
            Console.WriteLine($"Defense restored to: {_player.Defense}");
        }
    }
}
