﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace TicTacToeGame
{
    class TicTacToeGame
    {
        char playerLetter, compLetter;
        public const int HEAD = 1;
        public const int TAIL = 0;
        public char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public char choosePlayerLetter()
        {
            Console.WriteLine("Choose either X or O");
            playerLetter = char.ToUpper(Console.ReadLine()[0]);
            if (playerLetter.Equals('X') || playerLetter.Equals('O'))
            {
                Console.WriteLine("You have choosed"+playerLetter);
                
            }
            else
            {
                Console.WriteLine("Please,Choose either X or O");
                choosePlayerLetter();
            }
            return playerLetter;
            
        }
        public char computerLetter()
        {
            if (playerLetter.Equals('X'))
            {
                compLetter = 'O';
            }
            else 
            {
                compLetter = 'X';
            }
            return compLetter;
        }
        public void showBoard(char[] board)
        {
            Console.WriteLine(board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("---------");
            Console.WriteLine(board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("---------");
            Console.WriteLine(board[7] + " | " + board[8] + " | " + board[9]);
        }
        public void userMove(char[] board)
        {
            Console.WriteLine("Enter your Move[1-9]");
            int move = Convert.ToInt32(Console.ReadLine());
            if (move < 10 && move > 0 && board[move] ==' ')
            {
                Console.WriteLine("Your Move is Valid");
                board[move] = playerLetter;
                showBoard(board);
            }
            else
            {
                Console.WriteLine("Your Move is Not Valid ");
                userMove(board);
            }
        }
        public void compMove(char[] board,int pos)
        {
            board[pos] = compLetter;
            showBoard(board);
        }
        public char toss()
        {
            char playingOne;
            Random random = new Random();
            int tossWon = random.Next(0,2);
            if (tossWon == HEAD)
            {
                Console.WriteLine("User will play first");
                playingOne = playerLetter;
            }
            else
            {
                Console.WriteLine("Computer will play first");
                playingOne = compLetter;
            }
            return playingOne;
        }
        public bool isWinner(char[] b, char c)
        {
            return (
                (b[1] == c && b[2] == c && b[3] == c) ||
                (b[4] == c && b[5] == c && b[6] == c) ||
                (b[7] == c && b[8] == c && b[9] == c) ||
                (b[7] == c && b[4] == c && b[1] == c) ||
                (b[8] == c && b[5] == c && b[2] == c) ||
                (b[9] == c && b[6] == c && b[3] == c) ||
                (b[1] == c && b[5] == c && b[9] == c) ||
                (b[7] == c && b[5] == c && b[3] == c) 
                    );
        }
        public void makeMove(char[] b, int position, char letter) 
        {
            if (b[position] == ' ') 
            {
                b[position] = letter;
            }
        }
        public char[] getCopyOfBoard(char[] c)
        {
            char[] boardCopy = new char[10];
            Array.Copy(c, 0,boardCopy,0,boardCopy.Length);
            return boardCopy;
        }
        public int GetWinningMove(char[] b, char c)
        {
            for (int i = 1; i <b.Length; i++)
            {
                char[] copyBoard = getCopyOfBoard(b);
                if (copyBoard[i]==' ')
                {
                    makeMove(copyBoard, i, c);
                    if (isWinner(copyBoard,c))
                    {
                        return i;
                        
                    }
                }                
            }
            return 0;
        }
        public int getComputerMove(char[] b, char computerLetter)
        {
            int winningMove = GetWinningMove(b, computerLetter);
            if (winningMove != 0)
            {
                return winningMove;
            }
            int userWinningMove = GetWinningMove(b, playerLetter);
            if (userWinningMove != 0)
            {
                return userWinningMove;
            }
            int[] cornerMoves = { 1, 3, 7, 9 };
            int computerMove = getRandomMoveFromList(b,cornerMoves);
            if (computerMove != 0)
            {
                return computerMove;
            }
            if (b[5]==' ') 
            {
                return 5;
            }
            int[] sideMove = { 2,4,6,8};
            computerMove = getRandomMoveFromList(b, sideMove);
            if (computerMove != 0)
            {
                return computerMove;
            }
            return 0;
        }
        public int getRandomMoveFromList(char[] board, int[] moves)
        {
            for (int i=0;i<moves.Length;i++)
            {
                int num = moves[i];
                if (board[num] == ' ')
                {
                    return num;
                }
            }
            return 0;
        }
        public bool noSpacesLeft(char[] board)
        {
            return (
                board[1] != ' ' && board[2] != ' ' && board[3] != ' ' && 
                board[4] != ' ' && board[5] != ' ' && board[6] != ' ' &&
                board[7] != ' ' && board[8] != ' ' && board[9] != ' ' 
                );
        }
    }
}
