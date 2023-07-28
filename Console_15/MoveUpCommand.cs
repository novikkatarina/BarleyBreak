namespace Console_15
{
  public class MoveUpCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveUpCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      Game.MovePointerUp();
    }
  }
}
