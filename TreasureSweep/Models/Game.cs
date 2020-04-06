using System;
using Newtonsoft.Json;

namespace TreasureSweepGame.Models
{
  public class Game
  {
    public int GameId { get; set; }
    public int P1Id { get; set; }
    public int P2Id { get; set; }
    public int TurnCount { get; set; } = 0;
    public bool IsComplete { get; set; } = false;
    public int WinningPlayer { get; set; }
    public string P1Board { get; set; }
    public string P2Board { get; set; }

    public Game()
    {
      P1Board = generateBoard();
      P2Board = generateBoard();

      // 0 = empty space
      // 1 = chest
      // 2 = mine
      // 3 = miss
      // 4 = hit

    }

    public static string generateBoard()
    {
      int numberOfTreasures = 7;

      //Generate empty board
      int[,] board = new int[5, 5];
      for (int y = 0; y < 5; y++)
      {
        for (int x = 0; x < 5; x++)
        {
          board[x, y] = 0;
        }
      }

      //Add treasure to the board
      for (int i = 0; i < numberOfTreasures; i++)
      {
        Random rnd = new Random();
        int x = rnd.Next(0, 5);
        int y = rnd.Next(0, 5);
        if (board[x, y] != 1)
        {
          board[x, y] = 1;
        }
        else
        {
          i--;
        }
      }

      //Add mine to board
      int numberOfMines = 1;
      for (int j = 0; j < numberOfMines; j++)
      {
        Random rnd = new Random();
        int mineX = rnd.Next(0, 5);
        int mineY = rnd.Next(0, 5);
        if (board[mineX, mineY] == 0)
        {
          board[mineX, mineY] = 2;
        }
        else
        {
          j--;
        }
      }
      //convert board to JSON format
      string boardJson = JsonConvert.SerializeObject(board);
      return boardJson;
    }
  }
}