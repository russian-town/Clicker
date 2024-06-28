using System;
using System.Collections.Generic;
using System.Linq;
using Source.Codebase.Domain;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Presentation;
using Source.Codebase.Services.Abstract;
using UnityEngine;

namespace Source.Codebase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly Dictionary<Type, object> _viewTemplateByType;

        private Dictionary<ClickType, ItemConfig> _itemConfigByClickType;

        public StaticDataService()
        {
            _viewTemplateByType = new();
            _itemConfigByClickType = new();
        }

        public void LoadGameConfig(GameConfig gameConfig)
        {
            LoadItemConfigs(gameConfig.ItemConfigs);
            _viewTemplateByType.Clear();
            _viewTemplateByType.Add(typeof(LevelView), gameConfig.LevelViewTemplate);
            _viewTemplateByType.Add(typeof(ClickHandlerView), gameConfig.ClickHandlerViewTemplate);
            _viewTemplateByType.Add(typeof(ClickEffectView), gameConfig.ClickEffectViewTemplate);
            _viewTemplateByType.Add(typeof(ItemView), gameConfig.ItemViewTemplate);
        }

        public T GetViewTemplate<T>() where T : MonoBehaviour
        {
            if (_viewTemplateByType.TryGetValue(typeof(T), out object viewTemplate))
                return viewTemplate as T;

            throw new Exception($"Can't find viewTemplate with given type: {typeof(T)} ");
        }

        public ItemConfig GetItemConfig(ClickType clickType)
        {
            if (_itemConfigByClickType.ContainsKey(clickType) == false)
                throw new Exception($"ItemConfig for ClickType {clickType} does not exist!");

            return _itemConfigByClickType[clickType];
        }

        private void LoadItemConfigs(ItemConfig[] itemConfigs)
        {
            if (itemConfigs.Length != itemConfigs.Distinct().Count())
                throw new Exception("All candiConfigs must be distinct");

            _itemConfigByClickType =
                itemConfigs.ToDictionary(
                    itemConfigs => itemConfigs.ClickType,
                    itemConfigs => itemConfigs);
        }
    }
}
