using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase
{
    public class PageButtonFactory
    {
        private readonly IStaticDataService _staticDataService;

        public PageButtonFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Create(PageIndex pageIndex, Transform parent)
        {
            PageConfig config =
                _staticDataService.GetPageConfig(pageIndex);
            PageButton pageButton = new();
            PageButtonView template =
                _staticDataService.GetViewTemplate<PageButtonView>();
            PageButtonView view =
                Object.Instantiate(template, parent);
            PageButtonPresenter presenter = new(pageButton, view, config);
            view.Construct(presenter);
        }
    }
}
