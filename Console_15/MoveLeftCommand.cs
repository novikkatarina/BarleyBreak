namespace Console_15
{
  public class MoveLeftCommand : ICommand
  {
    protected Game board { get; private set; }

    public MoveLeftCommand(Game board)
    {
      this.board = board;
    }
    public void Execute()
    {
      board.MovePointerLeft();
    }
  }
}
