using GameBase.DefaultClasses;

namespace Iterator.Pattern
{
    public interface IGameIterator<T>
    {
        bool HasNext();
        T Next();
        void Reset();
        T Current { get; }
    }
}
