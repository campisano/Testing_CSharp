using System.Collections.Generic;

namespace NLayer.Domain.Service.SystemOperation.Response
{
    public class DrawLogResponse
    {
        #region Properties

        public string Name { get; private set; }
        public string Color { get; private set; }
        public int Thickness { get; private set; }
        public IDictionary<int, double> Values { get; private set; }

        #endregion

        #region Constructors

        public DrawLogResponse(string name, IDictionary<int, double> dictionary, string color, int thickness)
        {
            Name = name;
            Values = dictionary;
            Color = color;
            Thickness = thickness;
        }

        #endregion
    }
}
