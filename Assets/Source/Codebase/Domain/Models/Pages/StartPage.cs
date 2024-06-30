using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class StartPage
    {
        private readonly PageConfig _config;

        public StartPage(PageConfig config)
        {
            _config = config;
        }

        public PageIndex PageIndex => _config.PageIndex;
    }
}
