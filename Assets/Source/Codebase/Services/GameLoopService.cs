using System;

namespace Source.Codebase.Services
{
    public class GameLoopService
    {
        public event Action<int> Clicked;
        public event Action<int> ClickForceUpdated;

        public void HandleClick(int clickForce)
            => Clicked?.Invoke(clickForce);

        public void UpdateClickForce(int clickForce)
            => ClickForceUpdated?.Invoke(clickForce);
    }
}
