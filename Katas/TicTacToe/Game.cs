using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {

        private string[,] board;

        private string winnerToken;

        private int numOfRows;
        private int numOfColumns;

        internal int NumOfCells { get => numOfRows * numOfRows; }


        internal Game(int rowLength)
        {
            board = new string[rowLength, rowLength];

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < rowLength; column++)
                {
                    board[row, column] = MapPositionToValue(new Position(row, column), rowLength);

                }
            }

            numOfRows = rowLength;
            numOfColumns = numOfRows;

        }

        internal void ShowWinner()
        {
            if (string.IsNullOrWhiteSpace(winnerToken))
                Console.WriteLine("No winner!");
            else
                Console.WriteLine($"And the winner is player {winnerToken}");
        }

        internal bool Finished()
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
            string[][] rows = new string[numOfColumns][];

            for (int row = 0; row < numOfColumns; row++)
            {

                rows[row] = GetRow(row);

            }

            return rows;
        }

        private string[][] GetAllColumns()
        {
            string[][] columns = new string[numOfRows][];

            for (int column = 0; column < numOfRows; column++)
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
                winnerToken = values[0];
                return true;
            }

            return false;
        }

        private string[] GetLeftToRightDiag()
        {
            string[] leftToRight = new string[numOfRows];
            for (int row = 0; row < numOfRows; row++)
            {
                leftToRight[row] = board[row, row];
            }

            return leftToRight;
        }

        private string[] GetRightToLeftDiag()
        {
            string[] rightToLeft = new string[numOfRows];
            for (int row = 0, col = numOfRows - 1; row < numOfRows; row++, col--)
            {
                rightToLeft[row] = board[row, col];
            }

            return rightToLeft;
        }

        private string[] GetColumn(int colIndex)
        {
            string[] colValues = new string[numOfRows];

            for (int row = 0; row < numOfRows; row++)
            {
                colValues[row] = board[row, colIndex];
            }

            return colValues;
        }

        private string[] GetRow(int rowIndex)
        {
            string[] rowValues = new string[numOfRows];

            for (int column = 0; column < numOfRows; column++)
            {
                rowValues[column] = board[rowIndex, column];
            }

            return rowValues;
        }

        private string MapPositionToValue(Position position, int rowLength)
        {
            int value = position.row * rowLength + position.column + 1;
            return value.ToString();
        }

        private Position MapValueToPosition(int value)
        {

            int row = value / numOfRows;
            if (value % numOfRows == 0)
                row--;

            int column = value - 1 - row * numOfRows;

            return new Position(row, column);
        }

        internal string GetCellValue(int cellIndex)
        {
            var cell = MapValueToPosition(cellIndex);

            return board[cell.row, cell.column];
        }

        internal void SetCellValue(int cellIndex, string tokenOfPlayer)
        {

            var cell = MapValueToPosition(cellIndex);

            board[cell.row, cell.column] = tokenOfPlayer;
        }



        internal void ShowInConsole()
        {
            string rowSeparator = String.Concat(Enumerable.Repeat("-", GetRowLength()));
            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(0); column++)
                {
                    Console.Write($"| {board[row, column]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine(rowSeparator);
            }
        }


        private int GetRowLength()
        {
            int boardSide = board.GetLength(0);
            string lastValue = board[boardSide - 1, boardSide - 1];

            int whiteSpaces = 4;
            int lastRowSize = lastValue.Length * boardSide * whiteSpaces;

            return lastRowSize;



        }

        class Position
        {
            internal int row;
            internal int column;

            internal Position(int row, int column)
            {
                this.row = row;
                this.column = column;
            }
        }

    }
}
