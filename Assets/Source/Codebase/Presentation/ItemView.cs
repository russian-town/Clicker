using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Codebase.Presentation
{
    public class ItemView : ViewBase
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _clickForceText;
        [SerializeField] private TMP_Text _name;

        [field: SerializeField] public Button SellButton { get; private set; }

        public void SetIcon(Sprite sprite)
            => _icon.sprite = sprite;

        public void SetPriceText(string priceText)
            => _priceText.text = priceText;

        public void SetClickForceText(string clickForceText)
            => _clickForceText.text = clickForceText;

        public void SetName(string name)
            => _name.text = name;

        public void EnableSellButton()
        {
            SellButton.interactable = true;
            _priceText.enabled = true;
        }

        public void DisableSellButton() 
        {
            SellButton.interactable = false;
            _priceText.enabled = false;
        }
    }
}
