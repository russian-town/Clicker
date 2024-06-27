using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Domain.Models
{
    public class ClickHandler : IDataReader
    {
        public int ClickForce { get; private set; } = 1;

        public void Read(PlayerData playerData)
        {
            ClickForce = playerData.CurrentClickForce;
        }
    }
}
