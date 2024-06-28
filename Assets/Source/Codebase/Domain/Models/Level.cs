using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using System;

namespace Source.Codebase.Domain.Models
{
    public class Level : IDataReader, IDataWriter
    {
        private int _currentClickCount;
        private int _levelNumber;

        public int NeedClickPerNextLevel { get; private set; }

        public event Action<int> LevelComplete;
        public event Action<int> ClickCountUpdated;
        public event Action<int, int> DataReaded;

        public void Read(PlayerData playerData)
        {
            _currentClickCount = playerData.LastClickCount;
            NeedClickPerNextLevel = playerData.NeedClickPerNextLevel;
            _levelNumber = playerData.CurrentLevel;
            DataReaded?.Invoke(_levelNumber, _currentClickCount);
        }

        public void Write(PlayerData playerData)
        {
            playerData.LastClickCount = _currentClickCount;
            playerData.NeedClickPerNextLevel = NeedClickPerNextLevel;
            playerData.CurrentLevel = _levelNumber;
        }

        public void UpdateClickCount(int clickForce)
        {
            if (_currentClickCount >= NeedClickPerNextLevel)
            {
                _currentClickCount = 0;
                NeedClickPerNextLevel *= 2;
                _levelNumber++;
                LevelComplete?.Invoke(_levelNumber);
            }

            _currentClickCount += clickForce;
            ClickCountUpdated?.Invoke(_currentClickCount);
        }
    }
}
