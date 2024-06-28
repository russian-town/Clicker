using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class ClickEffectPresenter : IPresenter
    {
        private readonly ClickEffect _clickEffect;
        private readonly ClickEffectView _clickEffectView;
        private readonly int _clickForce = 1;

        public ClickEffectPresenter(
            ClickEffect clickEffect,
            ClickEffectView view,
            int clickForce)
        {
            _clickEffect = clickEffect;
            _clickEffectView = view;
            _clickForce = clickForce;
        }

        public void Enable()
        {
            string text = $"+ {_clickForce}";
            _clickEffectView.SetText(text);
            _clickEffectView.PlayAnimation();
        }

        public void Disable() { }
    }
}
