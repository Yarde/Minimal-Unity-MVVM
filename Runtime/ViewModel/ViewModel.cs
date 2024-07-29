using System.Threading;
using Yarde.MVVM.Disposables;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.ViewModel
{
    public abstract class ViewModel<TView>
        where TView : View.View
    {
        protected TView View;
        protected readonly DisposableList Disposables = new DisposableList();

        public virtual void Initialize(TView view, CancellationToken token)
        {
            View = view;
            Disposables.Add(view);
            
            // register to token
        }

        public virtual void Close()
        {
            Disposables.Dispose();
        }
    }
    
    public abstract class ViewModel<TView, TData> : ViewModel<TView>
        where TView : View.View
        where TData : IObservableModel
    {
        public virtual void Initialize(TView view, TData data, CancellationToken token)
        {
            Initialize(view, token);
            SetupBindings(data);
        }

        protected abstract void SetupBindings(TData data);
    }
}