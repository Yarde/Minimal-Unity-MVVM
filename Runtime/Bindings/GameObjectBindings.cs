using System;
using UnityEngine;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Bindings
{
    public static class GameObjectBindings
    {
        public static IDisposable Bind(this GameObject gameObject, IObservableValue<bool> observable)
        {
            return observable.InvokeAndSubscribe(gameObject.SetActive);
        }
    }
}