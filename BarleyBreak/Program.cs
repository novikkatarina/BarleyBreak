﻿class Program
{
  static void Main(string[] args)
  {
    Board board = new Board(3);
    board.Print(board.BoardArray);
    board.IsWin(board.BoardArray);
  }
}
