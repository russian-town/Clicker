namespace Source.Codebase.Domain.Models.Abstract
{
    public abstract class Page
    {
        public Page(PageIndex index)
        {
            Index = index;
        }

        public PageIndex Index { get; private set; }
    }
}
