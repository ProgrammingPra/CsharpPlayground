using System;

namespace TicTacToe 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //prepare
            int boardSize = 3;
            IGame game = new Game(boardSize);
            InputValidator validator = new InputValidator(game);
            ConsoleDisplay console = new ConsoleDisplay(game);

            Player player1 = new Player("X");
            Player player2 = new Player("O");      


            //start game
            Player currentPlayer = player1;
            console.DrawBoard();

            while (!game.Finished())
            {
               
                int cellIndex = validator.GetInput(currentPlayer);

                game.SetCellValue(cellIndex, currentPlayer.Token);

                console.DrawBoard();

                currentPlayer = currentPlayer == player1? player2 : player1;
            }

            console.ShowWinner();

        }
    }
}






