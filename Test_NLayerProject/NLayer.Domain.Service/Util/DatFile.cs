namespace NLayer.Domain.Service.Util
{
    abstract class DatFile
    {
        protected const string Header = "SIMULATOR FOR STABILITY IN REAL TIME";
        protected const string VarType = "TypeMnemonic:";
        protected const string VarRows = "Number of rows:";
        protected const string EmptyLine = "";
        protected const string ColumnsHeader = "MD\t\tValue";
    }
}
