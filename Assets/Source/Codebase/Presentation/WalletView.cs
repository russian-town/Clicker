using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class WalletView : ViewBase
    {
        [SerializeField] private float _duration;
        [SerializeField] private TMP_Text _balanceText;

        public void SetBalanceText(string balanceText)
            => _balanceText.text = balanceText;
    }
}
