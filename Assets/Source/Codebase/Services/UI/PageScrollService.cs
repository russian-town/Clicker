using System;
using Source.Codebase.Domain;
using UnityEngine;

namespace Source.Codebase.Services.UI
{
    public class PageScrollService
    {
        private PageIndex _movingPage;

        public PageIndex ActivPage {  get; private set; }

        public event Action<Transform> Scrolled;
        public event Action ScrollEnded;

        public void ScrollTo(Transform target, PageIndex pageIndex)
        {
            if (ActivPage == pageIndex)
                return;

            _movingPage = pageIndex;
            Scrolled?.Invoke(target);
        }

        public void EndScroll()
        {
            ActivPage = _movingPage;
            ScrollEnded?.Invoke();
        }
    }
}
