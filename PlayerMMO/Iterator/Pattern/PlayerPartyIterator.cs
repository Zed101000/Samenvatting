using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public class PlayerPartyIterator : IGameIterator<IPlayer>
    {
        private List<IPlayer> _players;
        private int _currentIndex;

        public PlayerPartyIterator(List<IPlayer> players)
        {
            _players = players;
            _currentIndex = 0;
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
            return _currentIndex < _players.Count;
        }

        public IPlayer Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more players in the party");
            }
            
            return _players[_currentIndex++];
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}
