using System.Collections.Generic;
using System.IO;

namespace NLayer.Domain.Service.Util
{
    class DatWriter : DatFile
    {
        #region Properties

        public string TypeMnemonic { get; private set; }
        public string UnitSymbol { get; private set; }
        public int Rows { get; private set; }
        public List<KeyValuePair<double, double>> Values { get; private set; }

        #endregion

        #region Constructors

        public DatWriter(string filePath)
        {
            Values = new List<KeyValuePair<double, double>>();
            Export(filePath);
        }

        #endregion

        #region Methods

        private void Export(string filePath)
        {
            // Check if the filepath exist
            if (!File.Exists(filePath))
            {
                // Close if exist
                File.Create(filePath).Close();
            }

            // Creates the text file
            var textFile = File.CreateText(filePath);

            // Writes the Header
            textFile.WriteLine(Header);

            WriteMnmonicAndUnit(textFile);

            // Writes the number of dataset points
            textFile.WriteLine(VarRows + ": {0}", Rows);

            // Line break
            textFile.WriteLine();

            WriteDataset(textFile);

            textFile.Close();
        }

        private void WriteMnmonicAndUnit(TextWriter textFile)
        {
            // Writes the dataset mnemonic and unit
            if (UnitSymbol != string.Empty)
            {
                textFile.WriteLine("TypeMnemonic: {0} ({1})", TypeMnemonic, UnitSymbol);
            }
            else
            {
                textFile.WriteLine("TypeMnemonic: {0}", TypeMnemonic);
            }

        }

        private void WriteDataset(TextWriter textFile)
        {
            textFile.WriteLine("MD\t\tValue");

            foreach (var pair in Values)
            {
                var line = string.Format("{0:0.000000}\t{1:0.000000}", pair.Key, pair.Value);

                textFile.WriteLine(line);
            }
        }

        #endregion
    }
}
