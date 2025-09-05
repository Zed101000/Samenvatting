using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public class PlayerPartyReverseIterator : IGameIterator<IPlayer>
    {
        private List<IPlayer> _players;
        private int _currentIndex;

        public PlayerPartyReverseIterator(List<IPlayer> players)
        {
            _players = players;
            _currentIndex = _players.Count - 1;
        }

        public IPlayer Current 
        { 
            get 
            { 
                if (_currentIndex >= 0 && _currentIndex < _players.Count)
                    return _players[_currentIndex];
                return null;
            } 
        }

        public bool HasNext()
        {
            return _currentIndex >= 0;
        }

        public IPlayer Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more players in the party (reverse)");
            }
            
            return _players[_currentIndex--];
        }

        public void Reset()
        {
            _currentIndex = _players.Count - 1;
        }
    }
}
