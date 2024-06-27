using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Domain.Models
{
    public class ClickHandler : IDataReader
    {
        public ClickHandler(int clickForce)
        {
            ClickForce = clickForce;
        }

        public int ClickForce { get; private set; }

        public void Read(PlayerData playerData)
        {
            ClickForce = playerData.CurrentClickForce;
        }
    }
}
