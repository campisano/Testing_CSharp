using System;
using System.Collections.Generic;

namespace NLayer.Application
{
    public class IODContainer
    {
        private IDictionary<Type, Type> _registeredItems;

        #region Constructors

        public IODContainer()
        {
            _registeredItems = new Dictionary<Type, Type>();
        }

        #endregion

        #region Methods

        public void RegisterType(Type t1, Type t2)
        {
            _registeredItems.Add(t1, t2);
        }

        public T2 Resolve<T2>(Type type1)
        {
            return (T2)Activator.CreateInstance(_registeredItems[type1]);
        }

        #endregion
    }
}
