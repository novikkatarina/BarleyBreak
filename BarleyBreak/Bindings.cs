internal static class Bindings
{
  public static Dictionary<string, ICommand> Commands { get; private set; }
  public static void Initialize(Board board)
  {
    Commands = new Dictionary<string, ICommand>()
    {
      {"UpArrow", new MoveUpCommand(board)},
      {"DownArrow", new MoveDownCommand(board)},
      {"LeftArrow", new MoveLeftCommand(board)},
      {"RightArrow", new MoveRightCommand(board)},
    };
  }
}
