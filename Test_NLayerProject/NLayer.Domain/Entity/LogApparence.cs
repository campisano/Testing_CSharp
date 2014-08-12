
namespace NLayer.Domain.Entity
{
    public class LogApparence
    {
        #region Properties

        //TODO [CMP][BSA] name é o id do banco, porém não é orientação a objeto assim. Log pode TER uma Apparence configurada...
        public string Name { get; private set; }
        public string Color { get; private set; }
        public int Thickness { get; private set; }

        #endregion

        #region Constructors

        public LogApparence(string name, string color, int thickness)
        {
            Name = name;
            Color = color;
            Thickness = thickness;
        }

        #endregion

        #region Methods

        public void Set(string color, int thickness)
        {
            //TODO [CMP] validação
            Color = color;
            Thickness = thickness;
        }

        #endregion
    }
}
