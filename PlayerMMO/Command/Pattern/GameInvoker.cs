using System.Collections.Generic;

namespace Command.Pattern
{
    public class GameInvoker
    {
        private Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("No commands to undo!");
            }
        }

        public void UndoMultipleCommands(int count)
        {
            for (int i = 0; i < count && _commandHistory.Count > 0; i++)
            {
                UndoLastCommand();
            }
        }

        public void ClearHistory()
        {
            _commandHistory.Clear();
            Console.WriteLine("Command history cleared!");
        }

        public int GetHistoryCount()
        {
            return _commandHistory.Count;
        }
    }
}
