using System;
using Yarde.MVVM.Disposables;

namespace Yarde.MVVM.Observables
{
    public class ObservableValue<T> : IObservableValue<T>
    {
        private T _currentValue;

        public ObservableValue(T initialValue = default)
        {
            OnValueChanged = new DisposableSubscription<T>();
            _currentValue = initialValue;
        }

        private DisposableSubscription<T> OnValueChanged { get; }

        public T Value
        {
            get => _currentValue;
            set
            {
                if (_currentValue == null || !_currentValue.Equals(value))
                {
                    _currentValue = value;
                    OnValueChanged?.Invoke(Value);
                }
            }
        }
        
        public IDisposable InvokeAndSubscribe(Action<T> action)
        {
            action.Invoke(Value);
            return Subscribe(action);
        }

        public IDisposable Subscribe(Action<T> action)
        {
            return OnValueChanged.Subscribe(action);
        }
    }
}