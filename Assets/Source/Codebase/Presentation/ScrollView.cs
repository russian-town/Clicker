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
            float duration)
        {
            Container.DOAnchorPos(-targetPosition, duration);
        }
    }
}
