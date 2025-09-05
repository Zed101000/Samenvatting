namespace Command.Pattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
