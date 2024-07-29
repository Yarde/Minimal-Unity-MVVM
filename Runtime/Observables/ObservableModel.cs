using System;
using System.Collections.Generic;
using Yarde.MVVM.Disposables;

namespace Yarde.MVVM.Observables
{
    public class ObservableModel : IObservableModel
    {
        private readonly List<IObservable> _children = new List<IObservable>();

        public void Add(IObservable model)
        {
            _children.Add(model);
        }

        public IDisposable InvokeAndSubscribe(Action<IObservableModel> action)
        {
            action.Invoke(this);
            return Subscribe(action);
        }

        public IDisposable Subscribe(Action<IObservableModel> action)
        {
            return Subscribe(() => action.Invoke(this));
        }

        public IDisposable InvokeAndSubscribe(Action action)
        {
            action.Invoke();
            return Subscribe(action);
        }

        public IDisposable Subscribe(Action action)
        {
            var count = _children.Count;
            if (count == 0)
            {
                return new EmptyDisposable();
            }
    
            if (count == 1)
            {
                return _children[0].Subscribe(action);
            }

            var disposables = new DisposableList(count);
            for (var i = 0; i < count; i++)
            {
                disposables.Add(_children[i].Subscribe(action));
            }
            return disposables;
        }
    }
}