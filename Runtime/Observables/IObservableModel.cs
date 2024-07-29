using System.Collections.Generic;

namespace Yarde.MVVM.Observables
{
    public interface IObservableModel : IObservable<IObservableModel>
    {
        void Add(IObservable model);
    }
}