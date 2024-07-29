using System;

namespace Yarde.MVVM.Observables
{
    public interface IObservable<out T>
    {
        IDisposable Subscribe(Action<T> observer);
        IDisposable InvokeAndSubscribe(Action<T> observer);
    }
}