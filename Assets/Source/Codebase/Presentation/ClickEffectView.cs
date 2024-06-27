using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class ClickEffectView : ViewBase
    {
        [SerializeField] private TMP_Text _clickForceText;

        public void SetText(string text)
            => _clickForceText.text = text;
    }
}
