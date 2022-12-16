using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class InputValidator
    {
        private IGame game;

        internal InputValidator(IGame game) => this.game = game;

        internal int GetInput(Player player)
        {
            bool inputValid = false;

            string userInput = "";
            while (!inputValid)
            {
                userInput = player.Go();

                inputValid = Validate(userInput);
            }

            return int.Parse(userInput);
        }

        private bool Validate(string input)
        {
            return IsInt(input) && IsInRange(input) && CellFree(input);
        }

        private bool IsInRange(string input)
        {
            int value;
            int.TryParse(input, out value);
            int maxInput = game.NumOfCells;
            if (value < 1 || value > maxInput)
            {
                Console.WriteLine($"Expecting number between 1 and {maxInput}. Try again!");
                return false;
            }
                
            return true;
        }

        private bool IsInt(string input)
        {
            bool parseable = int.TryParse(input, out _);
            if (!parseable)
                Console.WriteLine("Integer is expected. Try again!");
            return parseable;
        }

        private bool CellFree(string input)
        {
            int value;
            int.TryParse(input, out value);
            string cellValue = game.GetCellValue(value);

            bool cellFree = cellValue.Equals(input);

            if (!cellFree)
                Console.WriteLine("This cell has already been used. Try again!");

            return cellFree;

        }
    }
}
