using System;

namespace Source.Codebase.Services
{
    public class GameLoopService
    {
        public event Action<int> Clicked;

        public void HandleClick(int clickForce)
            => Clicked?.Invoke(clickForce);
    }
}
