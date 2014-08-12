using System;
using System.Collections.Generic;
using System.IO;

namespace NLayer.Domain.Service.Util
{
    class DatLoader : DatFile
    {
        #region Properties

        public string TypeMnemonic { get; private set; }
        public string UnitSymbol { get; private set; }
        public int Rows { get; private set; }
        public List<KeyValuePair<double, double>> Values { get; private set; }

        #endregion

        #region Constructors

        public DatLoader(string filePath)
        {
            Values = new List<KeyValuePair<double, double>>();
            Import(filePath);
        }

        #endregion

        #region Methods

        private void Import(string filePath)
        {
            var textFile = File.OpenText(filePath);

            // Header
            var header = textFile.ReadLine();

            if (!header.Equals(Header))
            {
                throw new Exception("Wrong Header Line!");
            }

            // VarType
            var typeMnemonicLine = textFile.ReadLine().Split(' ');

            if (typeMnemonicLine.Length != 3 ||
               !(typeMnemonicLine[0].Equals(VarType)))
            {
                throw new Exception("Wrong TypeMnemonic Line!");
            }

            TypeMnemonic = typeMnemonicLine[1];
            UnitSymbol = typeMnemonicLine[2];

            // VarRows
            var numberOfRowsLine = textFile.ReadLine().Split(' ');

            if (numberOfRowsLine.Length != 4 ||
               !((numberOfRowsLine[0] + ' ' + numberOfRowsLine[1] + ' ' + numberOfRowsLine[2]).Equals(VarRows)))
            {
                throw new Exception("Wrong 'Number of rows' Line!");
            }

            Rows = int.Parse(numberOfRowsLine[3]);

            // Empty line
            string line = textFile.ReadLine();

            if (!line.Equals(EmptyLine))
            {
                throw new Exception("Wrong Empty Line!");
            }

            // Columns header
            line = textFile.ReadLine();

            if (!line.Equals(ColumnsHeader))
            {
                throw new Exception("Wrong 'Columns header' Line!");
            }

            // Values
            string[] values;
            KeyValuePair<double, double> pair;

            while ((line = textFile.ReadLine()) != null)
            {
                values = line.Split('\t');
                pair = new KeyValuePair<double, double>();

                if (values.Length != 2)
                {
                    throw new Exception("Wrong Value Line!");
                }

                pair = new KeyValuePair<double, double>(
                    double.Parse(values[0]),
                    double.Parse(values[0])
                    );

                Values.Add(pair);
            }

            if (Values.Count != Rows)
            {
                throw new Exception("Number of rows inconsistent!");
            }

            textFile.Close();
        }

        #endregion
    }
}
