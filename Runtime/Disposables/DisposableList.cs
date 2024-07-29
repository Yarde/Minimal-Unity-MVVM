using System;
using System.Collections.Generic;

namespace Yarde.MVVM.Disposables
{
    public class DisposableList : IDisposable
    {
        private readonly List<IDisposable> _disposables;

        public DisposableList()
        {
            _disposables = new List<IDisposable>();
        }
        
        public DisposableList(int count)
        {
            _disposables = new List<IDisposable>(count);
        }
        
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