using System;
using System.Collections.Generic;
using Yarde.MVVM.Disposables;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Model
{
    public class Model : IModel
    {
        private readonly List<IObservable> _children = new List<IObservable>();

        public void Add(IObservable model)
        {
            _children.Add(model);
        }

        public IDisposable InvokeAndSubscribe(Action<IModel> action)
        {
            action.Invoke(this);
            return Subscribe(action);
        }

        public IDisposable Subscribe(Action<IModel> action)
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