namespace Console_15
{
  public class MoveRightCommand : ICommand
  {
    protected Game board { get; private set; }

    public MoveRightCommand(Game board)
    {
      this.board = board;
    }
    public void Execute()
    {
      board.MovePointerRight();
    }
  }
}
