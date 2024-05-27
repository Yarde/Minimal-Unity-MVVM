using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarde.UnityObservable.Bindings;
using Yarde.UnityObservable.Bindings.TextMeshPro;
using Yarde.UnityObservable.Disposables;
using Yarde.UnityObservable.Observables;

namespace Yarde.UnityObservable.Samples_
{
    public class BindExample : MonoBehaviour, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Image _image;
        
        private readonly IObservableValue<Color> _observableColor = new ObservableValue<Color>(Color.red);
        private readonly IObservableValue<string> _observableString = new ObservableValue<string>("test");
        private readonly IObservableValue<bool> _observableBool = new ObservableValue<bool>(true);
        
        private readonly DisposableList _disposables = new();
        
        private void Start()
        {
            _textMeshPro.Bind(_observableString).AddTo(_disposables);
            _image.Bind(_observableColor).AddTo(_disposables);
            _image.gameObject.Bind(_observableBool).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}