using System;

namespace Yarde.MVVM.Disposables
{
    public class DisposableSubscription<T> : IDisposable
    {
        private event Action<T> SubscribeAction;

        private readonly DisposableList _disposablesList = new();
        
        public void Invoke(T value)
        {
            SubscribeAction?.Invoke(value);
        }

        public IDisposable Subscribe(Action<T> action)
        {
            SubscribeAction += action;
            var unsubscriber = new Unsubscriber(() => SubscribeAction -= action);
            return _disposablesList.Add(unsubscriber);
        }

        public void Dispose()
        {
            _disposablesList?.Dispose();
        }
    }
}