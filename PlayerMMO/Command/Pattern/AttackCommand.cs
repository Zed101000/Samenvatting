using GameBase.DefaultClasses;

namespace Command.Pattern
{
    public class AttackCommand : ICommand
    {
        private IPlayer _player;
        private IMonster _target;
        private int _previousPlayerHealth;
        private int _previousTargetHealth;

        public AttackCommand(IPlayer player, IMonster target)
        {
            _player = player;
            _target = target;
        }

        public void Execute()
        {
            _previousPlayerHealth = _player.Health;
            _previousTargetHealth = _target.Health;

            Console.WriteLine($"{_player.Name} attacks {_target.Name}!");
            _player.Attack();
            
            // Simulate damage
            int damage = Math.Max(1, _player.AttackPower - _target.Defense);
            _target.Health -= damage;
            Console.WriteLine($"{_target.Name} takes {damage} damage! Health: {_target.Health}");

            // Counter attack if target is alive
            if (_target.Health > 0)
            {
                int counterDamage = Math.Max(1, _target.AttackPower - _player.Defense);
                _player.Health -= counterDamage;
                Console.WriteLine($"{_target.Name} counter attacks! {_player.Name} takes {counterDamage} damage! Health: {_player.Health}");
            }
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing attack: {_player.Name} vs {_target.Name}");
            _player.Health = _previousPlayerHealth;
            _target.Health = _previousTargetHealth;
            Console.WriteLine($"Health restored - {_player.Name}: {_player.Health}, {_target.Name}: {_target.Health}");
        }
    }
}
