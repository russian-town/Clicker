using System.Collections.Generic;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string Key = "Saves";

        private readonly List<IDataWriter> _dataWriters;
        private readonly List<IDataReader> _dataReaders;

        public SaveLoadService()
        {
            _dataReaders = new();
            _dataWriters = new();
        }

        public void Save(PlayerData playerData)
        {
            if (playerData == null)
                return;

            foreach (var dataWriter in _dataWriters)
            {
                dataWriter.Write(playerData);
            }

            string data = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString(Key, data);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(Key) == false)
                return;

            string data = PlayerPrefs.GetString(Key);

            if (string.IsNullOrEmpty(data))
                return;
            
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(data);

            foreach (var dataReader in _dataReaders)
            {
                dataReader.Read(playerData);
            }
        }

        public void AddIDataReader(IDataReader dataReader)
            => _dataReaders.Add(dataReader);

        public void AddIDataWriter(IDataWriter dataWriter)
            => _dataWriters.Add(dataWriter);
    }
}
