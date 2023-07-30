namespace BarleyBreak
{
  public class Game
  {
    public Board Board { get; set; }

    // Логическая переменная факта работы игры
    public bool IsPlaying { get; set; }

    // нициализация полей с последовательным вызовом всех неообходимых методов
    public void Initialize()
    {
      do
      {
        Console.Clear();
        Console.WriteLine("Игра Пятнашки!");
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
      while (Board.Params[0] <= 1  || Board.Params[0] > Board.Limiter || Board.Params[1] <= 1 || Board.Params[1] > Board.Limiter);

      Bindings.Initialize(this);
    }

    // Начало игры
    public void Start()
    {
      IsPlaying = true;

      Initialize();

      do
      {
        Board.Fill();
      }
      while (IsWin());

      Board.Print();
      Input();
    }

    // Считываение кнопки и запуск функции
    public void Input()
    {
      do
      {
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        if (Bindings.Commands.ContainsKey(keyPressed.Key.ToString()))
          Bindings.Commands[keyPressed.Key.ToString()].Execute();
      }
      while (IsPlaying);
    }

    // Проверка на выигрыш
    public bool IsWin()
    {
      int index = 1;
      for (int i = 0; i < Board.Params[1]; i++)
      {
        for (int j = 0; j < Board.Params[0]; j++)
        {
          if (i == Board.Params[1] - 1 && j == Board.Params[0] - 1)
            index = 0;

          if (Board.Array[i, j] != index)
            return false;
          index++;
        }
      }
      return true;
    }

    // Перезапуск игры
    public void Restart()
    {
      Board.Reset();
      IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Перезапуск игры...");
      Console.ReadKey();

      Start();
    }

    // Конец игры
    public void Exit()
    {
      IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Выход...");
      Environment.Exit(0);
    }

    public Game()
    {
      Board = new Board();
    }
  }
}
