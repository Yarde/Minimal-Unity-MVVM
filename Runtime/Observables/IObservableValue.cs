using System;

namespace Yarde.MVVM.Observables
{
    public interface IObservableValue : IObservableValue<object>
    {
    }
    
    public interface IObservableValue<T>
    {
        T Value { get; }
        IDisposable Subscribe(Action<T> observer);
        IDisposable InvokeAndSubscribe(Action<T> observer);
    }
}