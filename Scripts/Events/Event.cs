using System;

namespace N8Sprite.Events
{
    public sealed class Event
    {
        private event Action _event;
        
        public void Invoke() =>
            _event?.Invoke();
        
        public void AddListener(in Action listener) =>
            _event += listener;
        
        public void RemoveListener(in Action listener) =>
            _event -= listener;
    }
    
    public sealed class Event<T1>
    {
        private event Action<T1> _event;
        
        public void Invoke(T1 t1) =>
            _event?.Invoke(t1);
        
        public void AddListener(Action<T1> listener) =>
            _event += listener;
        
        public void RemoveListener(Action<T1> listener) =>
            _event -= listener;
    }
    
    public sealed class Event<T1, T2>
    {
        private event Action<T1, T2> _event;
        
        public void Invoke(T1 t1, T2 t2) =>
            _event?.Invoke(t1, t2);
        
        public void AddListener(Action<T1, T2> listener) =>
            _event += listener;
        
        public void RemoveListener(Action<T1, T2> listener) =>
            _event -= listener;
    }
}