using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Factory
{
    public class FactoryOfFactorys
    {
        private Dictionary<LootTypes, IGenericFactory> _factories = new Dictionary<LootTypes, IGenericFactory>();

        public void RegisterFactory(LootTypes type, IGenericFactory factory)
        {

            if (_factories.ContainsKey(type))
            {
                throw new Exception($"It alredy contains a factory with key: {type.ToString()}");
            }

            _factories.Add(type, factory);
        }

        public IGenericFactory GetFactory(LootTypes type)
        {
            if (!_factories.ContainsKey(type))
            {
                throw new Exception($"Ther's no factory with key: {type.ToString()}");
            }

            return _factories[type];
        }
    }
}
