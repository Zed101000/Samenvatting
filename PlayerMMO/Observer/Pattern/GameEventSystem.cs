namespace Observer.Pattern
{
    // Subject interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Observer interface
    public interface IObserver
    {
        void Update(string eventData); // Push model
        void Update(ISubject subject); // Pull model
    }

    // Subject implementation for Push Model
    public class GameEventSystemPush : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private string? _eventData; // Made nullable to avoid initialization error

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_eventData ?? "No Data"); // Push data to observers
            }
        }

        public void TriggerEvent(string eventData)
        {
            _eventData = eventData;
            Notify();
        }
    }

    // Subject implementation for Pull Model
    public class GameEventSystemPull : ISubject
    {
        private readonly List<IObserver> _observers = new();
        public string? EventData { get; private set; } // Made nullable to avoid initialization error

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this); // Notify observers to pull data
            }
        }

        public void TriggerEvent(string eventData)
        {
            EventData = eventData;
            Notify();
        }
    }

    // Observer implementation
    public class Player : IObserver
    {
        private readonly string _name;

        public Player(string name)
        {
            _name = name;
        }

        public void Update(string eventData)
        {
            Console.WriteLine($"{_name} received event data (Push): {eventData}");
        }

        public void Update(ISubject subject)
        {
            if (subject is GameEventSystemPull pullSubject)
            {
                Console.WriteLine($"{_name} pulled event data: {pullSubject.EventData}");
            }
        }
    }
}