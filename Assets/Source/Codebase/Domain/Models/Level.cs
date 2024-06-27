using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Domain.Models
{
    public class Level : IDataReader
    {
        public int LevelNumber { get; private set; }

        public void Read(PlayerData playerData)
        {
        }
    }
}
