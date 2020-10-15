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
            char playingOne=game.toss();
            while (true)
            {
                if (playingOne == playerLetter)
                {
                    Console.WriteLine("Enter the valid index to move");
                    game.userMove(board);
                    if (game.isWinner(board, playerLetter))
                    {
                        Console.WriteLine("Player Won");
                        break;
                    }
                    else if (game.noSpacesLeft(board))
                    {
                        Console.WriteLine("Game Draw");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Its computers turn now");
                    }
                    playingOne = computerLetter;
                }
                else if (playingOne==computerLetter)
                {
                    int computerMove = game.getComputerMove(board, computerLetter);
                    Console.WriteLine(computerMove);
                    game.compMove(board, computerMove);
                    if (game.isWinner(board, computerLetter))
                    {
                        Console.WriteLine("Computer Won");
                        break;
                    }
                    else if (game.noSpacesLeft(board))
                    {
                        Console.WriteLine("Game Draw");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Its players turn now");
                    }
                    playingOne = playerLetter;
                }
            }
        }
    }
}
