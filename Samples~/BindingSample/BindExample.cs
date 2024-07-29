using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarde.MVVM.Bindings;
using Yarde.MVVM.Bindings.TextMeshPro;
using Yarde.MVVM.Disposables;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Samples_
{
    public class BindExample : MonoBehaviour, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private readonly IObservableValue<Color> _observableColor = new ObservableValue<Color>(Color.red);
        private readonly ObservableValue<string> _observableString = new ObservableValue<string>("test");
        private readonly ObservableValue<bool> _observableBool = new ObservableValue<bool>(true);
        
        // to hide setter a wrapper to interface can be added
        private IObservableValue<string> ObservableString => _observableString;
        
        private readonly DisposableList _disposables = new();
        
        private void Start()
        {
            _button.onClick.AddListener(() => _observableBool.Value = !_observableBool.Value);
            
            _textMeshPro.Bind(ObservableString).AddTo(_disposables);
            _image.Bind(_observableColor).AddTo(_disposables);
            _image.gameObject.Bind(_observableBool).AddTo(_disposables);
        }

        private void Update()
        {
            _observableString.Value = Time.time.ToString(CultureInfo.InvariantCulture);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}