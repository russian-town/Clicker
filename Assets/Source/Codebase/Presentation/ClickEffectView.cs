using Cysharp.Threading.Tasks;
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

        public async UniTask PlayAnimation(float lifeTime, float fadeDuration)
        {
            _canvasGroup.alpha = 1;
            Sequence sequence = DOTween.Sequence();
            Vector2 targetPosition = new(0f, Screen.height / 2f);
            sequence.Append(_rectTransform.DOBlendableLocalMoveBy(targetPosition, lifeTime)).SetEase(Ease.InCubic);
            sequence.Join(_canvasGroup.DOFade(0f, fadeDuration).SetEase(Ease.Linear));
            await sequence.Play();
        }

        public void SetText(string text)
            => _clickForceText.text = text;
    }
}
