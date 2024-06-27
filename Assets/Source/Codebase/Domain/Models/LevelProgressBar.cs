using System;

namespace Source.Codebase.Domain.Models
{
    public class LevelProgressBar
    {
        private int _currentClickCount;

        public LevelProgressBar(int needClickPerNextLevel)
        {
            NeedClickPerNextLevel = needClickPerNextLevel;
        }

        public int NeedClickPerNextLevel { get; private set; }

        public event Action<int> ClickCountUpdated;

        public void UpdateClickCount(int clickForce)
        {
            if (clickForce <= 0)
                throw new Exception("Click count cannot be less than or equal to 0!");

            _currentClickCount += clickForce;
            ClickCountUpdated?.Invoke(_currentClickCount);
        }
    }
}
