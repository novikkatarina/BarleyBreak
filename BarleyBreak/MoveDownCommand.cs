public class MoveDownCommand : ICommand
{
  protected Board Board { get; private set; }

  public MoveDownCommand(Board board)
  {
    this.Board = board;
  }
  public void Execute()
  {
    Board.MovePointerDown();
  }
}
