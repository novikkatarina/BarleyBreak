namespace BarleyBreak
{
  internal class ExitCommand : ICommand
  {
    protected Game Game { get; private set; }
    public ExitCommand(Game game)
    {
      Game = game;
    }
    public void Execute()
    {
      Game.Exit();
    }
  }
}
