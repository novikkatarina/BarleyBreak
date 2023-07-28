namespace Console_15
{
  public class MoveLeftCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveLeftCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      Game.MovePointerLeft();
    }
  }
}
