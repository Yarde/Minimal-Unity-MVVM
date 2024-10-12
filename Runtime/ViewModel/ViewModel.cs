using System.Threading;
using UnityEngine;
using Yarde.MVVM.Disposables;

namespace Yarde.MVVM.ViewModel
{
    public abstract class ViewModel<TView> where TView : View.View
    {
        protected TView View;
        protected CancellationTokenSource CloseSource { get; private set; }
        protected readonly DisposableList Disposables = new DisposableList();

        public virtual void Initialize(TView view, CancellationToken parentCloseSource)
        {
            View = view;
            Disposables.Add(view);

            InitializeLifecycleToken(view, parentCloseSource);
        }

        private void InitializeLifecycleToken(TView view, CancellationToken parentCloseSource)
        {
            CloseSource = CancellationTokenSource
                .CreateLinkedTokenSource(view.destroyCancellationToken, parentCloseSource)
                .AddTo(Disposables);

            CloseSource.Token.Register(InternalClose).AddTo(Disposables);
        }

        public virtual void Close()
        {
            if (CloseSource.IsCancellationRequested)
            {
                Debug.LogError($"ViewModel: {GetType().FullName} already closed. Check element lifecycle.");
            }
            else
            {
                CloseSource.Cancel();
            }
        }

        private void InternalClose()
        {
            Disposables.Dispose();
        }
    }

    public abstract class ViewModel<TView, TData> : ViewModel<TView>
        where TView : View.View
        where TData : Model.Model
    {
        public virtual void Initialize(TView view, TData model, CancellationToken token)
        {
            Initialize(view, token);
            SetupBindings(model);
        }

        protected abstract void SetupBindings(TData model);
    }
}