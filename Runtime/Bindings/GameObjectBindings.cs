using System;
using UnityEngine;
using Yarde.UnityObservable.Observables;

namespace Yarde.UnityObservable.Bindings
{
    public static class GameObjectBindings
    {
        public static IDisposable Bind(this GameObject gameObject, IObservableValue<bool> observable)
        {
            return observable.InvokeAndSubscribe(gameObject.SetActive);
        }
    }
}