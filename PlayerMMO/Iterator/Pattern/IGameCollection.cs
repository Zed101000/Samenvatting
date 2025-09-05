using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public interface IGameCollection<T>
    {
        IGameIterator<T> CreateIterator();
        void Add(T item);
        void Remove(T item);
        int Count { get; }
    }
}
