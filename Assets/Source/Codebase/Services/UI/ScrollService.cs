using System;
using UnityEngine;

namespace Source.Codebase.Services.UI
{
    public class ScrollService
    {
        public event Action<Transform> Scrolled;

        public void ScrollTo(Transform target)
            => Scrolled?.Invoke(target);
    }
}
