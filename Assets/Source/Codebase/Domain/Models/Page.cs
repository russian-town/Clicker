namespace Source.Codebase.Domain.Models
{
    public class Page
    {
        public Page(PageIndex index)
        {
            Index = index;
        }

        public PageIndex Index { get; private set; }
    }
}
