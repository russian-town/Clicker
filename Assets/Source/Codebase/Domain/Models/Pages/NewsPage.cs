using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class NewsPage
    {
        private readonly PageConfig _config;

        public NewsPage(PageConfig config)
        {
            _config = config;
        }

        public PageIndex PageIndex => _config.PageIndex;
    }
}
