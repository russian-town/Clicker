using Source.Codebase.Controllers.Presenters;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Models;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using Source.Codebase.Services.UI;
using UnityEngine;

namespace Source.Codebase.Services.Factories
{
    public class PageFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly PageService _pageService;

        public PageFactory(
            IStaticDataService staticDataService,
            PageService pageService)
        {
            _staticDataService = staticDataService;
            _pageService = pageService;
        }

        public void Create(PageIndex pageIndex, Transform parent)
        {
            Page page = new(pageIndex);
            PageView template =
                _staticDataService.GetViewTemplate<PageView>();
            PageView view = Object.Instantiate(template, parent);
            _pageService.RegistrePage(pageIndex, view.transform);
            PagePresenter presenter = new(page, view);
            view.Construct(presenter);
        }
    }
}
