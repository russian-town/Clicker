using System;
using Source.Codebase.Domain.Models.Abstract;

namespace Source.Codebase.Services
{
    public class ShopService
    {
        private readonly IWallet _wallet;

        public ShopService(IWallet wallet)
        {
            _wallet = wallet;
        }

        public event Action<int> Selled;

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
