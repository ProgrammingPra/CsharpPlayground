using System;

namespace TicTacToe 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //prepare
            int boardSize = 3;
            Game game = new Game(boardSize);
            InputValidator validator = new InputValidator(game);

            Player player1 = new Player("X");
            Player player2 = new Player("O");      


            //start game
            Player currentPlayer = player1;
            game.ShowInConsole();

            while (!game.Finished())
            {
               
                int cell = validator.GetInput(currentPlayer);

                game.SetCellValue(cell, currentPlayer.Token);

                game.ShowInConsole();

                currentPlayer = currentPlayer == player1? player2 : player1;
            }

            game.ShowWinner();

        }
    }
}






