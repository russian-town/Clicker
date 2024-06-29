using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class Scroll
    {
        private readonly ScrollConfig _config;

        public Scroll(ScrollConfig config)
        {
            _config = config;
        }

        public float MoveDuration => _config.MoveDuration;
    }
}
