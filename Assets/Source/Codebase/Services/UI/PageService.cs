using System;
using System.Collections.Generic;
using Source.Codebase.Domain;
using UnityEngine;

namespace Source.Codebase.Services.UI
{
    public class PageService
    {
        private readonly Dictionary<PageIndex, Transform> _pageByIndex = new();

        public event Action<Transform> PageMoved;
        public event Action NewsPageOpened;

        public void RegistrePage(PageIndex pageIndex, Transform transform)
        {
            _pageByIndex.Add(pageIndex, transform);
        }

        public Transform GetPageByIndex(PageIndex pageIndex) 
        {
            if (_pageByIndex.ContainsKey(pageIndex) == false)
                throw new ArgumentException();

            return _pageByIndex[pageIndex];
        }

        public void OpenPage(PageIndex pageIndex)
        {
            switch (pageIndex)
            {
                case PageIndex.None:
                    throw new Exception("Page is None!");
                case PageIndex.Home:
                    break;
                case PageIndex.Shop:
                    break;
                case PageIndex.News:
                    NewsPageOpened?.Invoke();
                    break;
            }
        }
    }
}
