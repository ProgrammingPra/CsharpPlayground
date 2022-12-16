using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal interface IGame
    {
        internal int NumOfCells { get; }
        internal int Dimension { get; }
        internal string Winner { get; }

        internal string GetCellValue(int row, int column);
        internal string GetCellValue(int cellIndex);

        internal void SetCellValue(int cellIndex, string token);

        internal bool Finished();
    }
}
