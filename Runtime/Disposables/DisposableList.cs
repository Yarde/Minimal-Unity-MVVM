using System;
using System.Collections.Generic;

namespace Yarde.UnityObservable.Disposables
{
    public class DisposableList : IDisposable
    {
        private readonly List<IDisposable> _disposables = new();

        public IDisposable Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
            return disposable;
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables) disposable.Dispose();
        }
    }
}