using System;
namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game");
            TicTacToeGame game = new TicTacToeGame();
            char[] board = game.createBoard();
            char playerLetter = game.choosePlayerLetter();
            char computerLetter = game.computerLetter();
            game.showBoard(board);
            game.toss();
            game.userMove(board);
            int computerMove = game.getComputerMove(board,computerLetter);
        }
    }
}
