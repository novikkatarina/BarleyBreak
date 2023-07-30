namespace BarleyBreak
{
  internal static class Bindings
  {
    public static Dictionary<string, ICommand> Commands { get; private set; }
    public static void Initialize(Game game)
    {
      Commands = new Dictionary<string, ICommand>()
      {
        {"UpArrow", new MoveUpCommand(game)},
        {"DownArrow", new MoveDownCommand(game)},
        {"LeftArrow", new MoveLeftCommand(game)},
        {"RightArrow", new MoveRightCommand(game)},
        {"R", new RestartCommand(game)},
        {"E", new ExitCommand(game)}
      };
    }
  }
}
