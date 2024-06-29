using Source.Codebase.Presentation.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Codebase.Presentation
{
    public class PageButtonView : ViewBase
    {
        [SerializeField] private Image _icon;

        [field: SerializeField] public Button Button { get; private set; }

        public void SetIcon(Sprite icon)
            => _icon.sprite = icon;
    }
}
