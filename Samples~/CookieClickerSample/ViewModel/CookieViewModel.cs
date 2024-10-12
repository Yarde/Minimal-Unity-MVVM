using Yarde.Example.CookieClicker.Model;
using Yarde.Example.CookieClicker.View;
using Yarde.MVVM.Bindings.TextMeshPro;
using Yarde.MVVM.Disposables;
using Yarde.MVVM.ViewModel;

namespace Yarde.Example.CookieClicker.ViewModel
{
    public class CookieViewModel : ViewModel<CookieView, CookieModel>
    {
        protected override void SetupBindings(CookieModel model)
        {
            View.ScoreText.Bind(model.Score).AddTo(Disposables);
            View.Button.onClick.AddListener(() => UpdateModel(model));
        }

        private void UpdateModel(CookieModel model)
        {
            model.IncrementScore();
        }
    }
}