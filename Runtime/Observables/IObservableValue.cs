namespace Yarde.MVVM.Observables
{
    public interface IObservableValue<out T> : IObservable<T>
    {
        T Value { get; }
    }
}