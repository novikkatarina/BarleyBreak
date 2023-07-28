namespace Console_15
{
  public class MoveRightCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveRightCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      Game.MovePointerRight();
    }
  }
}
