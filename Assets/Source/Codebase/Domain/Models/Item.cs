using System;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class Item : IDataWriter
    {
        public Item(ItemConfig configs)
        {
            ClickForce = configs.ClickForce;
            ClickType = configs.ClickType;
        }

        public int ClickForce { get; private set; }
        public ClickType ClickType { get; private set; }
        public bool IsBought { get; private set; }

        public event Action Bought;

        public void ApplyData(ItemData itemData)
            => IsBought = itemData.IsBought;

        public void By()
        {
            if (IsBought == true)
                throw new Exception("Item is bought");

            IsBought = true;
            Bought?.Invoke();
        }

        public void Write(PlayerData playerData)
        {
            foreach (var itemData in playerData.ItemsData)
            {
                if(itemData.ClickType == ClickType)
                {
                    itemData.IsBought = IsBought;
                    break;
                }
            }
        }
    }
}
