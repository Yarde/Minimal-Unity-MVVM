using System;

namespace Yarde.MVVM.Disposables
{
    public static class DisposablesExtensions
    {
        public static IDisposable AddTo(this IDisposable disposable, DisposableList disposableList)
        {
            return disposableList.Add(disposable);
        }
    }
}