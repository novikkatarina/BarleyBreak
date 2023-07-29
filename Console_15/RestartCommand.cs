namespace TheGame
{
  class RestartCommand : ICommand
  {
    protected Game Game { get; private set; }
    public RestartCommand(Game game)
    {
      Game = game;
    }

    public void Execute()
    {
      Game.Restart();
    }
  }
}
