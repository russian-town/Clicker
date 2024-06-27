using System.Collections.Generic;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class SaveLoadService
    {
        private const string Key = "Saves";

        private readonly List<IDataWriter> _dataWriters;
        private readonly List<IDataReader> _dataReaders;

        private PlayerData _playerData;

        public void Save()
        {
            foreach (var dataWriter in _dataWriters)
            {
                dataWriter.Write(_playerData);
            }

            string data = JsonUtility.ToJson(_playerData);
            PlayerPrefs.SetString(Key, data);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(Key) == false)
                return;

            string data = PlayerPrefs.GetString(Key);
            _playerData = JsonUtility.FromJson<PlayerData>(data);

            foreach (var dataReader in _dataReaders)
            {
                dataReader.Read(_playerData);
            }
        }
    }
}
