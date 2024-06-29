using System;
using Source.Codebase.Data;
using Source.Codebase.Data.Abstract;
using Source.Codebase.Domain.Models.Abstract;

namespace Source.Codebase.Domain
{
    public class Wallet : IWallet, IDataWriter
    {
        public int Balance { get; private set; }

        public event Action<int> BalanceChanged;

        public void ApplyData(WalletData data)
            => Balance = data.Balance;

        public void IncreaseBalance(int value)
        {
            if (value < 0)
                throw new ArgumentException(nameof(value));

            Balance += value;
            BalanceChanged?.Invoke(Balance);
        }

        public void DecreaseBalance(int price) 
        {
            if (price < 0)
                throw new ArgumentException(nameof(price));

            if (Balance - price < 0)
                throw new ArgumentException(nameof(Balance));

            Balance -= price;
            BalanceChanged?.Invoke(Balance);
        }

        public void Write(PlayerData playerData)
            => playerData.WalletData.Balance = Balance;
    }
}
