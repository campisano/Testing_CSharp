using System.Collections.Generic;

namespace NLayer.Domain.Entity
{
    public class Log
    {
        private SortedDictionary<int, double> _values;

        #region Properties

        public IDictionary<int, double> Values { get { return _values; } }
        public string Name { get; private set; }
        public string Unit { get; private set; }

        #endregion

        #region Constructors

        public Log(string name)
        {
            _values = new SortedDictionary<int, double>();
            Name = name;
            Unit = "Unknown";
        }

        #endregion
    }
}
