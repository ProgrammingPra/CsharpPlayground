using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game : IGame
    {

        private string[,] board;

        public int NumOfCells { get => board.Length; }
        public int Dimension { get; private set; }
        public string Winner { get; private set; }


        internal Game(int dimension)
        {
            board = new string[dimension, dimension];

            for (int row = 0; row < dimension; row++)
            {
                for (int column = 0; column < dimension; column++)
                {
                    board[row, column] = MapCellToValue(new Cell(row, column), dimension);

                }
            }

            Dimension = dimension;
            
        }

        

        public bool Finished()
        {
            return FullRow() || FullColumn() || FullDiagonal() || NowhereToGo();

        }

        private bool NowhereToGo()
        {
           return ColumnsBlocked() && RowsBlocked() && DiagsBlocked();
        }

        private bool DiagsBlocked()
        {
            return HasBlock(GetLeftToRightDiag()) && HasBlock(GetRightToLeftDiag());
        }

        private bool RowsBlocked()
        {
            string[][] rows = GetAllRows();

            return rows.All(row => HasBlock(row));
        }

        private bool ColumnsBlocked()
        {
            string[][] columns = GetAllColumns();

            return columns.All(col => HasBlock(col));
        }

        private bool HasBlock(string[] cells)
        {
            if (AllCellsFree(cells))
                return false;

            string usedCell = cells.First(cell => IsUsedCell(cell));
            return cells.Any(cell => IsUsedCell(cell) && !usedCell.Equals(cell));
        }

        private bool IsUsedCell(string cell)
        {
            return !IsFreeCell(cell);

        }

        private bool IsFreeCell(string cell) {
            return int.TryParse(cell, out _);

        }

        private bool AllCellsFree(string[] cells)
        {
            return cells.All(cell => IsFreeCell(cell));
        }
        

        private bool FullRow()
        {
            var rows = GetAllRows();

            return rows.Any(row => SameValues(row));
        }

        private string[][] GetAllRows()
        {
            string[][] rows = new string[Dimension][];

            for (int row = 0; row < Dimension; row++)
            {

                rows[row] = GetRow(row);

            }

            return rows;
        }

        private string[][] GetAllColumns()
        {
            string[][] columns = new string[Dimension][];

            for (int column = 0; column < Dimension; column++)
            {

                columns[column] = GetColumn(column);
                    
            }

            return columns;
        }

        private bool FullColumn()
        {
            var columns = GetAllColumns();

            return columns.Any(column => SameValues(column));
        }

        private bool FullDiagonal()
        {

            string[] leftToRight = GetLeftToRightDiag();

            if (SameValues(leftToRight))
                return true;

            string[] rightToLeft = GetRightToLeftDiag();

            if (SameValues(rightToLeft))
                return true;

            return false;
        }

        private bool SameValues(string[] values)
        {
            if (values.All(value => value.Equals(values[0])))
            {
                Winner = values[0];
                return true;
            }

            return false;
        }

        private string[] GetLeftToRightDiag()
        {
            string[] leftToRight = new string[Dimension];
            for (int row = 0; row < Dimension; row++)
            {
                leftToRight[row] = board[row, row];
            }

            return leftToRight;
        }

        private string[] GetRightToLeftDiag()
        {
            string[] rightToLeft = new string[Dimension];
            for (int row = 0, col = Dimension - 1; row < Dimension; row++, col--)
            {
                rightToLeft[row] = board[row, col];
            }

            return rightToLeft;
        }

        private string[] GetColumn(int colIndex)
        {
            string[] colValues = new string[Dimension];

            for (int row = 0; row < Dimension; row++)
            {
                colValues[row] = board[row, colIndex];
            }

            return colValues;
        }

        private string[] GetRow(int rowIndex)
        {
            string[] rowValues = new string[Dimension];

            for (int column = 0; column < Dimension; column++)
            {
                rowValues[column] = board[rowIndex, column];
            }

            return rowValues;
        }

        private string MapCellToValue(Cell cell, int boardDimension)
        {
            int value = cell.row * boardDimension + cell.column + 1;
            return value.ToString();
        }

        private Cell MapValueToCell(int value)
        {

            int row = value / Dimension;
            if (value % Dimension == 0)
                row--;

            int column = value - 1 - row * Dimension;

            return new Cell(row, column);
        }

        public string GetCellValue(int cellIndex)
        {
            var cell = MapValueToCell(cellIndex);

            return board[cell.row, cell.column];
        }

        public string GetCellValue(int row, int column)
        { 

            return board[row, column];
        }

        public void SetCellValue(int cellIndex, string tokenOfPlayer)
        {

            var cell = MapValueToCell(cellIndex);

            board[cell.row, cell.column] = tokenOfPlayer;
        }


        class Cell
        {
            internal int row;
            internal int column;

            internal Cell(int row, int column)
            {
                this.row = row;
                this.column = column;
            }
        }

    }
}
