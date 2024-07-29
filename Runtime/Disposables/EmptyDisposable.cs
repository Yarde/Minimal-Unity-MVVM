using System;

namespace Yarde.MVVM.Disposables
{
    internal class EmptyDisposable : IDisposable
    {
        public void Dispose() { }
    }
}