using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class ShopPage
    {
        private readonly PageConfig _config;

        public ShopPage(PageConfig config)
        {
            _config = config;
        }

        public PageIndex PageIndex => _config.PageIndex;
    }
}
