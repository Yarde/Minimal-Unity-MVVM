using System;
using TMPro;
using UnityEngine;
using Yarde.MVVM.Model;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Bindings.TextMeshPro
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