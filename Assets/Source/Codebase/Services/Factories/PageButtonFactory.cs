using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase
{
    public class PageButtonFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly PageService _pageService;

        public PageButtonFactory(
            IStaticDataService staticDataService,
            PageService pageService)
        {
            _staticDataService = staticDataService;
            _pageService = pageService;
        }

        public void Create(
            PageIndex pageIndex,
            Transform parent,
            ScrollService scrollService)
        {
            PageConfig config =
                _staticDataService.GetPageConfig(pageIndex);
            PageButton pageButton = new();
            PageButtonView template =
                _staticDataService.GetViewTemplate<PageButtonView>();
            PageButtonView view =
                Object.Instantiate(template, parent);
            PageButtonPresenter presenter =
                new(pageButton, view, config, scrollService, _pageService);
            view.Construct(presenter);
        }
    }
}
