using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class LevelView : ViewBase
    {
        [SerializeField] private TMP_Text _levelText;

        public void SetText(string levelText)
            => _levelText.text = levelText;
    }
}
