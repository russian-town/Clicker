using System;
using DG.Tweening;
using Source.Codebase.Presentation.Abstract;
using UnityEngine;

namespace Source.Codebase.Presentation
{
    public class ScrollView : ViewBase
    {
        [field: SerializeField] public RectTransform Container { get; private set; }

        public void StartMoveAnimation(
            Vector3 targetPosition,
            float duration, Action onEnded = null)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(Container.DOAnchorPos(-targetPosition, duration));
            sequence.OnComplete(() => onEnded?.Invoke());
        }
    }
}
