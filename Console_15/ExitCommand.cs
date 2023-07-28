namespace Console_15
{
  internal class ExitCommand : ICommand
  {
    protected Game Game { get; private set; }
    public ExitCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      Game.Exit();
    }
  }
}
