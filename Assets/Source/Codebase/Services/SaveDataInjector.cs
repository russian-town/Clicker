using System;
using System.Collections.Generic;
using Source.Codebase.Data;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Models;

namespace Source.Codebase.Services
{
    public class SaveDataInjector
    {
        private List<ItemData> _itemsData;
        private WalletData _walletData;

        public void SetData(PlayerData playerData)
        {
            _itemsData = playerData.ItemsData;
            _walletData = playerData.WalletData;
        } 

        public void Update(Item item)
        {
            if (item.ClickType == ClickType.None)
                throw new Exception("Click type is None!");

            foreach (var itemData in _itemsData) 
            {
                if (item.ClickType == itemData.ClickType)
                {
                    item.ApplyData(itemData);
                    break;
                }
            }
        }

        public void Update(Wallet wallet)
            => wallet.ApplyData(_walletData);
    }
}
