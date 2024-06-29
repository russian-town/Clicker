using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain;
using UnityEngine;

namespace Source.Codebase.Services.Abstract
{
    public interface IStaticDataService
    {
        public T GetViewTemplate<T>() where T : MonoBehaviour;
        public ItemConfig GetItemConfig(ClickType clickType);
        public PageConfig GetPageConfig(PageIndex pageIndex);
        public ScrollConfig GetScrollConfig(ScrollType scrollType);
    }
}
