using System;
using Source.Codebase.Domain.Configs;
using Source.Codebase.Domain.Models;
using System.Collections.Generic;
using Source.Codebase.Domain;

namespace Source.Codebase.Services.Factories
{
    public class ItemFactory
    {
        public List<Item> Get(ItemConfig[] configs)
        {
            List<Item> items = new();

            foreach (var config in configs)
            {
                if (config.ClickType == ClickType.None)
                    throw new Exception("Click type is None!");

                Item item = new(config);
                items.Add(item);
            }

            return items;
        }
    }
}
