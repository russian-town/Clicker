using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Source.Codebase.Presentation
{
    public class PageButtonView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        public void SetIcon(Sprite icon)
            => _icon.sprite = icon;

        public void AddListener(UnityAction onClick)
            => _button.onClick.AddListener(onClick);

        public void RemoveListener(UnityAction onClick)
            => _button.onClick.RemoveListener(onClick);

        public void Enable()
            => _button.interactable = true;

        public void Disable()
            => _button.interactable = false;
    }
}
