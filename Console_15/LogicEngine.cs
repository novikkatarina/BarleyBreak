using System.Runtime.CompilerServices;

namespace TheGame
{
  internal static class LogicEngine
  {
    // Логическая переменная факта работы игры
    public static bool IsPlaying { get; set; }

    // Передвижение указателя вверх
    public static void MovePointerUp(Game game)
    {
      int temp = game.Board.Pointer[0];
      if (temp-- > 0)
      {
        game.Board.Pointer[2] = game.Board.Pointer[0];
        game.Board.Pointer[3] = game.Board.Pointer[1];

        game.Board.Pointer[0]--;
        Update(game);
      }

    }

    // Передвижение указателя вниз
    public static void MovePointerDown(Game game)
    {
      int temp = game.Board.Pointer[0];
      if (temp++ < game.Board.Params[1] - 1)
      {
        game.Board.Pointer[2] = game.Board.Pointer[0];
        game.Board.Pointer[3] = game.Board.Pointer[1];

        game.Board.Pointer[0]++;
        Update(game);
      }
    }

    // Передвижение указателя влево
    public static void MovePointerLeft(Game game)
    {
      int temp = game.Board.Pointer[1];
      if (temp-- > 0)
      {
        game.Board.Pointer[2] = game.Board.Pointer[0];
        game.Board.Pointer[3] = game.Board.Pointer[1];

        game.Board.Pointer[1]--;
        Update(game);
      }
    }

    // Передвижение указателя вправо
    public static void MovePointerRight(Game game)
    {
      int temp = game.Board.Pointer[1];
      if (temp++ < game.Board.Params[0] - 1)
      {
        game.Board.Pointer[2] = game.Board.Pointer[0];
        game.Board.Pointer[3] = game.Board.Pointer[1];

        game.Board.Pointer[1]++;
        Update(game);
      }
    }

    // Обновление матрицы после передвижения указателя
    public static void Update(Game game)
    {
      int temp = game.Board.Array[game.Board.Pointer[0], game.Board.Pointer[1]];
      game.Board.Array[game.Board.Pointer[0], game.Board.Pointer[1]] = 0;
      game.Board.Array[game.Board.Pointer[2], game.Board.Pointer[3]] = temp;

      game.Board.Print();

      if (game.Board.Pointer[0] == game.Board.Params[1] - 1 && game.Board.Pointer[1] == game.Board.Params[0] - 1)
      {
        game.IsWin();
      }
    }
  }
}
