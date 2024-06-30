using System;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Domain.Models
{
    public class ClickHandler : IDataReader, IDataWriter
    {
        public int ClickForce { get; private set; } = 1;

        public event Action<int> DataReaded;

        public void Read(PlayerData playerData)
        {
            ClickForce = playerData.CurrentClickForce;
            DataReaded?.Invoke(ClickForce);
        } 

        public void Write(PlayerData playerData)
            => playerData.CurrentClickForce = ClickForce;

        public void UpdateClickForce(int clickForce)
            => ClickForce = clickForce;
    }
}
