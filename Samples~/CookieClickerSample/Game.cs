using System.Threading;
using UnityEngine;
using Yarde.Example.CookieClicker.Model;
using Yarde.Example.CookieClicker.View;
using Yarde.Example.CookieClicker.ViewModel;

namespace Yarde.Example
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private CookieView _cookieView;
        [SerializeField] private Transform _uiParent;
        
        private CookieViewModel _viewModel;
        private CookieView _view;
        private CookieModel _model;

        private void Start()
        {
            _model = new CookieModel(0);
            _view = Instantiate(_cookieView, _uiParent);
            _viewModel = new CookieViewModel();
            _viewModel.Initialize(_view, _model, new CancellationToken());
        }

        private void OnDestroy()
        {
            _viewModel.Close();
        }
    }
}