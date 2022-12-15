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

            numOfRows = board.GetLength(1);
            numOfColumns = board.GetLength(0);

        }

        internal void ShowWinner()
        {
            if (string.IsNullOrWhiteSpace(winnerToken))
            {
                Console.WriteLine("No winner!");
            }
            Console.WriteLine($"And the winner is player {winnerToken}");
        }

        internal bool Finished()
        {
            return FullRow() || FullColumn() || FullDiagonal();

        }

        private bool FullRow()
        {
            for (int row = 0; row < numOfRows; row++)
            {
                if (SameValues(GetRow(row)))
                    return true;
            }

            return false;
        }

        private bool FullColumn()
        {
            for (int column = 0; column < numOfColumns; column++)
            {

                if (SameValues(GetColumn(column)))
                    return true;
            }

            return false;
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
            for (int row = 0, col = numOfColumns - 1; row < numOfRows; row++, col--)
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
                colValues[row] = board[colIndex, row];
            }

            return colValues;
        }

        private string[] GetRow(int rowIndex)
        {
            string[] rowValues = new string[numOfColumns];

            for (int column = 0; column < numOfColumns; column++)
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

        private Position MapValueToPosition(int value, int rowLength)
        {

            int row = value / rowLength;
            if (value % rowLength == 0)
                row--;

            int column = value - 1 - row * rowLength;

            return new Position(row, column);
        }

        internal void SetValue(int numberToReplace, string tokenOfPlayer)
        {
            //TODO error handling


            var boardPosition = MapValueToPosition(numberToReplace, board.GetLength(0));

            board[boardPosition.row, boardPosition.column] = tokenOfPlayer;
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
