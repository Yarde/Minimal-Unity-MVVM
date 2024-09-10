using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Model
{
    public interface IModel : IObservable<IModel>
    {
        void Add(IObservable model);
    }
}