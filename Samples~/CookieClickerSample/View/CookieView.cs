using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yarde.Example.CookieClicker.View
{
    public class CookieView : MVVM.View.View
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }

        public override void Dispose() { Destroy(gameObject); }
    }
}