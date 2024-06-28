using Source.Codebase.Presentation.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Codebase.Presentation
{
    public class LevelView : ViewBase
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _needClickText;
        [SerializeField] private TMP_Text _forceClickText;
        [SerializeField] private Slider _levelSlider;

        public void SetLevelText(string levelText)
            => _levelText.text = levelText;

        public void SetNeedClickText(string needClickText)
            => _needClickText.text = needClickText;

        public void SetForcePerClickText(string forceClickText)
            => _forceClickText.text = forceClickText;

        public void SetValue(float value)
            => _levelSlider.value = value;
    }
}
