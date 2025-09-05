using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public class PlayerParty : IGameCollection<IPlayer>
    {
        private List<IPlayer> _players;
        private string _partyName;

        public PlayerParty(string partyName)
        {
            _players = new List<IPlayer>();
            _partyName = partyName;
        }

        public string PartyName => _partyName;

        public void Add(IPlayer player)
        {
            _players.Add(player);
            Console.WriteLine($"{player.Name} joined the party '{_partyName}'");
        }

        public void Remove(IPlayer player)
        {
            if (_players.Remove(player))
            {
                Console.WriteLine($"{player.Name} left the party '{_partyName}'");
            }
        }

        public int Count => _players.Count;

        public IGameIterator<IPlayer> CreateIterator()
        {
            return new PlayerPartyIterator(_players);
        }

        public IGameIterator<IPlayer> CreateReverseIterator()
        {
            return new PlayerPartyReverseIterator(_players);
        }

        public IGameIterator<IPlayer> CreateFilteredIterator(Func<IPlayer, bool> filter)
        {
            return new FilteredPlayerIterator(_players, filter);
        }

        public void ShowPartyInfo()
        {
            Console.WriteLine($"\n=== Party: {_partyName} ===");
            Console.WriteLine($"Members: {Count}");
            
            if (Count > 0)
            {
                var iterator = CreateIterator();
                while (iterator.HasNext())
                {
                    var player = iterator.Next();
                    Console.WriteLine($"- {player}");
                }
            }
            else
            {
                Console.WriteLine("No members in the party");
            }
            Console.WriteLine();
        }
    }
}
