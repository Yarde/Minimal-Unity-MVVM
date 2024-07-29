using System;

namespace Yarde.MVVM.Disposables
{
    public class Unsubscriber : IDisposable
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