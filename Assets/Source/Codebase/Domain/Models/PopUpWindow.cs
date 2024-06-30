using Source.Codebase.Domain.Configs;

namespace Source.Codebase.Domain.Models
{
    public class PopUpWindow
    {
        private readonly PopUpWindowConfig _config;

        public PopUpWindow(PopUpWindowConfig config)
        {
            _config = config;
        }

        public string Description => _config.Description;
    }
}
