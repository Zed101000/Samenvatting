using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public class FilteredPlayerIterator : IGameIterator<IPlayer>
    {
        private List<IPlayer> _filteredPlayers;
        private int _currentIndex;

        public FilteredPlayerIterator(List<IPlayer> players, Func<IPlayer, bool> filter)
        {
            _filteredPlayers = players.Where(filter).ToList();
            _currentIndex = 0;
        }

        public IPlayer Current 
        { 
            get 
            { 
                if (_currentIndex >= 0 && _currentIndex < _filteredPlayers.Count)
                    return _filteredPlayers[_currentIndex];
                return null;
            } 
        }

        public bool HasNext()
        {
            return _currentIndex < _filteredPlayers.Count;
        }

        public IPlayer Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more filtered players");
            }
            
            return _filteredPlayers[_currentIndex++];
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}
