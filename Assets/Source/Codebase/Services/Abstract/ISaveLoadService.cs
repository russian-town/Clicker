using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Services.Abstract
{
    public interface ISaveLoadService
    {
        public void Save(PlayerData playerData);
        public void Load();
        public void AddIDataReader(IDataReader dataReader);
        public void AddIDataWriter(IDataWriter dataWriter);
    }
}
