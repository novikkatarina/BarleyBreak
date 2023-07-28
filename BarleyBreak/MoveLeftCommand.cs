public class MoveLeftCommand : ICommand
{
  protected Board Board { get; private set; }

  public MoveLeftCommand(Board board)
  {
    this.Board = board;
  }
  public void Execute()
  {
    Board.MovePointerLeft();
  }
}
