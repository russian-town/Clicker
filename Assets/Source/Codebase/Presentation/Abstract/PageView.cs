namespace Source.Codebase.Presentation.Abstract
{
    public abstract class PageView : ViewBase
    {
        public PageButtonView Button { get; private set; }

        public void SetButton(PageButtonView button)
            => Button = button;

        public abstract void Open();
        public abstract void Close();
    }
}
