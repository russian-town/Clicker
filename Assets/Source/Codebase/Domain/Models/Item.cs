using Source.Codebase.Data;
using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class Item
    {
        public Item(ItemConfig configs)
        {
            ClickForce = configs.ClickForce;
            ClickType = configs.ClickType;
        }

        public int ClickForce { get; private set; }
        public ClickType ClickType { get; private set; }
        public bool IsBought { get; private set; }

        public void ApplyData(ItemData itemData)
            => IsBought = itemData.IsBought;
    }
}
