using Yarde.MVVM.Disposables;

namespace Yarde.MVVM.ViewModel
{
    public abstract class ViewModel<TView>
        where TView : View.View
    {
        protected TView View;
        protected readonly DisposableList Disposables = new DisposableList();

        public virtual void Initialize(TView view)
        {
            View = view;
            Disposables.Add(view);
        }

        public virtual void Close()
        {
            Disposables.Dispose();
        }
    }
    
    public abstract class ViewModel<TView, TData> : ViewModel<TView>
        where TView : View.View
        where TData : class
    {
        public virtual void Initialize(TView view, TData data)
        {
            Initialize(view);
            SetupBindings(data);
        }

        protected abstract void SetupBindings(TData data);
    }
}