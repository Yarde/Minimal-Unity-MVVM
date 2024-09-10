using System;
using UnityEngine;
using Yarde.MVVM.Model;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Bindings
{
    public static class TransformBindings
    {
        public static IDisposable Bind(this Transform transform, IObservableValue<bool> observable)
        {
            return observable.InvokeAndSubscribe(v => transform.gameObject.SetActive(v));
        }
        
        public static IDisposable Bind(this Transform transform, IObservableValue<Vector3> observable)
        {
            return observable.InvokeAndSubscribe(v => transform.localScale = v);
        }
    }
}