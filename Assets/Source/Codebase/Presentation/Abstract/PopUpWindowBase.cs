using UnityEngine;
using UnityEngine.UI;

namespace Source.Codebase.Presentation.Abstract
{
    public abstract class PopUpWindowBase : PoolableViewBase
    {
        [field: SerializeField] public Button CloseButton { get; private set; }

        public void Show()
            => gameObject.SetActive(true);

        public void Hide()
            => gameObject.SetActive(false);
    }
}
