using System;
using UnityEngine;
using UnityEngine.UI;
using Yarde.MVVM.Model;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Bindings
{
    public static class ImageBindings
    {
        public static IDisposable Bind(this Image image, IObservableValue<Sprite> observable)
        {
            return observable.InvokeAndSubscribe(v => image.sprite = v);
        }
        
        public static IDisposable Bind(this Image image, IObservableValue<Material> observable)
        {
            return observable.InvokeAndSubscribe(v => image.material = v);
        }
        
        public static IDisposable Bind(this Image image, IObservableValue<float> observable)
        {
            return observable.InvokeAndSubscribe(v => image.fillAmount = v);
        }
        
        public static IDisposable Bind(this Image image, IObservableValue<Color> observable)
        {
            return observable.InvokeAndSubscribe(v => image.color = v);
        }
    }
}