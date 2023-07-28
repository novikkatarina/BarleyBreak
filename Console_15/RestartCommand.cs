namespace Console_15
{
  class RestartCommand : ICommand
  {
    protected Game Game { get; private set; }
    public RestartCommand(Game game)
    {
      this.Game = game;
    }

    public void Execute()
    {
      Game.Restart();
    }
  }
}
