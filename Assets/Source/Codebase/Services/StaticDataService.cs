using Source.Codebase.Presentation.Abstract;
using Source.Codebase.Services.Abstract;

namespace Source.Codebase.Services
{
    public class StaticDataService : IStaticDataService
    {
        public T GetViewTemplate<T>() where T : ViewBase
        {
            throw new System.NotImplementedException();
        }
    }
}
