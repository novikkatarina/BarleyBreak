namespace TheGame
{
  public class Game
  {
    public Board Board { get; set; }

    // нициализация полей с последовательным вызовом всех неообходимых методов
    public void Initialize()
    {
      do
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nВведите параметры поля (не более {Board.Limiter})!\n");
        Console.ResetColor();
        try
        {
          Console.Write("Кол-во строк: ");
          Board.Params[1] = int.Parse(Console.ReadLine());

          Console.Write("Кол-во столбцов: ");
          Board.Params[0] = int.Parse(Console.ReadLine());
        }
        catch
        {
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"\nВведите цифровое значение!");
          Console.ResetColor();
        }
      }
      while (Board.Params[0] == 0 || Board.Params[0] > Board.Limiter || Board.Params[1] == 0 || Board.Params[1] > Board.Limiter);

      Bindings.Initialize(this);
    }

    // Начало игры
    public void Start()
    {
      LogicEngine.IsPlaying = true;

      Initialize();
      Board.Fill();
      Board.Print();
      Input();
    }

    // Считываение кнопки и запуск функции
    public static void Input()
    {
      do
      {
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        if (Bindings.Commands.ContainsKey(keyPressed.Key.ToString()))
          Bindings.Commands[keyPressed.Key.ToString()].Execute();
      }
      while (LogicEngine.IsPlaying);
    }

    // Проверка на выигрыш
    public void IsWin()
    {
      int index = 1;
      for (int i = 0; i < Board.Params[1]; i++)
      {
        for (int j = 0; j < Board.Params[0]; j++)
        {
          if (i == Board.Params[1] - 1 && j == Board.Params[0] - 1)
            index = 0;
          
          if (Board.Array[i, j] != index)
            return;
          index++;
        }
      }
      Console.Clear();
      Console.WriteLine("\nВы выиграли!");
      Console.ReadKey();
      Restart();
    }

    // Перезапуск игры
    public void Restart()
    {
      Board.Reset();
      LogicEngine.IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Перезапуск игры...");
      Console.ReadKey();

      Start();
    }

    // Конец игры
    public void Exit()
    {
      LogicEngine.IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Выход...");
      Environment.Exit(0);
    }

    public Game()
    {
      this.Board = new Board();
    }
  }
}
