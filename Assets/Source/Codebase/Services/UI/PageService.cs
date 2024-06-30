using System;
using System.Collections.Generic;
using Source.Codebase.Domain;
using UnityEngine;

namespace Source.Codebase.Services.UI
{
    public class PageService
    {
        private readonly Dictionary<PageIndex, Transform> _pageByIndex = new();

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
    }
}
