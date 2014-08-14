using System;
using System.Collections.Generic;

namespace Test_GenericMediatorAndWPF.Common.Pattern
{
    public class IODContainer
    {
        private static IODContainer _instance;

        private IDictionary<Type, Type> _registeredItems;

        #region Properties

        public static IODContainer Instance
        {
            get { if (_instance == null) _instance = new IODContainer(); return _instance; }
        }

        #endregion

        #region Constructors

        private IODContainer()
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
