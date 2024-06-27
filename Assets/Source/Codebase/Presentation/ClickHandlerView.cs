using System;
using Source.Codebase.Presentation.Abstract;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.Codebase.Presentation
{
    public class ClickHandlerView : ViewBase, IPointerClickHandler
    {
        public event Action<Vector2> Clicked;

        public void OnPointerClick(PointerEventData eventData)
            => Clicked?.Invoke(eventData.position);
    }
}
