using Yarde.MVVM.Observables;

namespace Yarde.Example.CookieClicker.Model
{
    public class CookieModel : MVVM.Model.Model
    {
        public IObservableValue<int> Score => _score;
        private readonly ObservableValue<int> _score;
        
        public CookieModel(int score)
        {
            _score = new ObservableValue<int>(this, score);
        }
        
        public void IncrementScore() { _score.Value++; }
    }
}