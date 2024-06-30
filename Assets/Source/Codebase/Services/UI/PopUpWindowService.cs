using System;

namespace Source.Codebase.Services.UI
{
    public class PopUpWindowService
    {
        public event Action PageClosed;

        public void CloseAllWindows()
            => PageClosed?.Invoke();
    }
}
