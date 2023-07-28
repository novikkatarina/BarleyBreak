namespace Console_15
{
  public class MoveDownCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveDownCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      Game.MovePointerDown();
    }
  }
}
