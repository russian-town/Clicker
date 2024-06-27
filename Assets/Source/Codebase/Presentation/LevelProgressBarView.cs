using Source.Codebase.Presentation.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Codebase.Presentation
{
    public class LevelProgressBarView : ViewBase
    {
        [SerializeField] private Slider _slider;

        public void UpdateSlider(float value)
            => _slider.value = value;
    }
}
