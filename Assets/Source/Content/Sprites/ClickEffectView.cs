using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class ClickEffectView : PoolableViewBase
    {
        [SerializeField] private TMP_Text _clickForceText;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _moveDuration;
        [SerializeField] private float _fadeDuration;

        public void PlayAnimation()
        {
            _canvasGroup.alpha = 1;
            Sequence sequence = DOTween.Sequence();
            Vector2 targetPosition = new(0f, Screen.height / 2f);
            sequence.Append(_rectTransform.DOBlendableLocalMoveBy(targetPosition, _moveDuration)).SetEase(Ease.InCubic);
            sequence.Join(_canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.Linear));
            sequence.Play();
        }

        public void SetText(string text)
            => _clickForceText.text = text;
    }
}
