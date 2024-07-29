using System;
using TMPro;
using UnityEngine;
using Yarde.MVVM.Observables;

namespace Yarde.UnityObservable.Bindings.TextMeshPro
{
    public static class TextMeshProBindings
    {
        public static IDisposable Bind<T>(this TMP_Text textMeshPro, IObservableValue<T> observable)
        {
            return observable.InvokeAndSubscribe(v => textMeshPro.SetText(v.ToString()));
        }
        
        public static IDisposable Bind(this TMP_Text textMeshPro, IObservableValue<Color> observable)
        {
            return observable.InvokeAndSubscribe(v => textMeshPro.color = v);
        }
    }
}