using System;
using Source.Codebase.Domain.Models.Abstract;

namespace Source.Codebase.Services
{
    public class ShopService
    {
        private IWallet _wallet;

        public event Action<int> Selled;

        public void SetWallet(IWallet wallet)
            => _wallet = wallet;

        public bool TrySell(int price)
        {
            if (_wallet.Balance >= price)
            {
                Selled?.Invoke(price);
                return true;
            }

            return false;
        }
    }
}
