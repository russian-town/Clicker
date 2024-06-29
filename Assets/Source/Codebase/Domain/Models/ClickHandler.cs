using System;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;

namespace Source.Codebase.Domain.Models
{
    public class ClickHandler : IDataReader, IDataWriter
    {
        public int ClickForce { get; private set; } = 1;

        public void Read(PlayerData playerData)
            => ClickForce = playerData.CurrentClickForce;

        public void Write(PlayerData playerData)
            => playerData.CurrentClickForce = ClickForce;

        public void UpdateClickForce(int clickForce)
            => ClickForce = clickForce;
    }
}
