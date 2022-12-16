using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ConsoleDisplay
    {
        private IGame game;

        internal ConsoleDisplay(IGame game) => this.game = game;

        internal void DrawBoard()
        {
            string rowSeparator = String.Concat(Enumerable.Repeat("-", GetRowLength()));
            for (int row = 0; row < game.Dimension; row++)
            {
                for (int column = 0; column < game.Dimension; column++)
                {
                    Console.Write($"| {game.GetCellValue(row, column)} ");
                }
                Console.WriteLine("|");
                Console.WriteLine(rowSeparator);
            }
        }


        private int GetRowLength()
        {
            string lastValue = game.GetCellValue(game.NumOfCells - 1);

            int whiteSpaces = 4;
            int lastRowSize = lastValue.Length * game.Dimension * whiteSpaces;

            return lastRowSize;

        }

        internal void ShowWinner()
        {
            if (string.IsNullOrWhiteSpace(game.Winner))
                Console.WriteLine("No winner!");
            else
                Console.WriteLine($"And the winner is player {game.Winner}");
        }
    }
}
