using Source.Codebase.Controllers.Presenters.Abstract;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;

namespace Source.Codebase.Controllers.Presenters
{
    public class ClickEffectPresenter : IPresenter
    {
        private readonly ClickEffect _clickEffect;
        private readonly ClickEffectView _clickEffectView;

        public ClickEffectPresenter(
            ClickEffect clickEffect,
            ClickEffectView view)
        {
            _clickEffect = clickEffect;
            _clickEffectView = view;
        }

        public async void Enable()
        {
            string text = $"+ {_clickEffect.ClickForce}";
            _clickEffectView.SetText(text);
            await _clickEffectView.PlayAnimation(_clickEffect.LifeTime, _clickEffect.LifeTime);
            _clickEffectView.Destroy();
        }

        public void Disable() { }
    }
}
