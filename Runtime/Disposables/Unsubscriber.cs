using System;

namespace Yarde.MVVM.Disposables
{
    internal readonly struct Unsubscriber : IDisposable
    {
        private readonly Action _unsubscribeAction;

        public Unsubscriber(Action unsubscribeAction)
        {
            _unsubscribeAction = unsubscribeAction;
        }

        public void Dispose()
        {
            _unsubscribeAction?.Invoke();
        }
    }
}