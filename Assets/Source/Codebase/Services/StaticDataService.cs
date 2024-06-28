using System;
using System.Collections.Generic;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly Dictionary<Type, object> _viewTemplateByType = new();

        public void LoadGameConfig(GameConfig gameConfig)
        {
            _viewTemplateByType.Clear();
            _viewTemplateByType.Add(typeof(LevelView), gameConfig.LevelViewTemplate);
            _viewTemplateByType.Add(typeof(ClickHandlerView), gameConfig.ClickHandlerViewTemplate);
            _viewTemplateByType.Add(typeof(LevelProgressBarView), gameConfig.LevelProgressBarViewTemplate);
            _viewTemplateByType.Add(typeof(ClickEffectView), gameConfig.ClickEffectViewTemplate);
        }

        public T GetViewTemplate<T>() where T : MonoBehaviour
        {
            if (_viewTemplateByType.TryGetValue(typeof(T), out object viewTemplate))
                return viewTemplate as T;

            throw new Exception($"Can't find viewTemplate with given type: {typeof(T)} ");
        }
    }
}
