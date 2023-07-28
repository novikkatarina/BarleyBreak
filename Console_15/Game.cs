namespace Console_15
{
  public class Game
  {
    // Доска и её параметры
    protected int[,] Board { get; private set; }
    protected int BoardWidth { get; private set; }
    protected int BoardHeight { get; private set; }

    // Указатель и прошлая позиция указателя
    protected int[] Pointer { get; private set; }
    protected int[] LastPointer { get; private set; }

    public bool IsPlaying { get; private set; }

    // Начало игры и инициализация полей с последовательным вызовом всех неообходимых методов
    public void Start()
    {
      this.IsPlaying = true;
      int limiter = 4;
      do
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nВведите параметры поля (не более {limiter})!\n");
        Console.ResetColor();
        try
        {
          Console.Write("Кол-во строк: ");
          this.BoardHeight = (int.Parse(Console.ReadLine()));

          Console.Write("Кол-во столбцов: ");
          this.BoardWidth = int.Parse(Console.ReadLine());
        }
        catch
        {
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"\nВведите цифровое значение!");
          Console.ResetColor();
        }
      }
      while ((this.BoardWidth == 0 || this.BoardWidth > limiter) || (this.BoardHeight == 0 || this.BoardHeight > limiter));

      this.Board = new int[this.BoardHeight, this.BoardWidth];
      this.Pointer = new int[2] { this.BoardHeight - 1, this.BoardWidth - 1 };
      this.LastPointer = new int[2] { 0, 0 };
      this.FillBoard();
      this.PrintBoard();
      this.Input();
    }

    // Заполнение матрицы Пятнашек числами
    public void FillBoard()
    {
      Random rnd = new Random();
      int maxValue = (this.BoardWidth * this.BoardHeight);
      IEnumerable<int> numbers = Enumerable.Range(1, maxValue - 1);

      // Перемешивание коллекции в случайном порядке
      numbers = numbers.OrderBy(n => rnd.Next());
      IEnumerator<int> currentNumber = numbers.GetEnumerator();

      // Заполнение двумерного массива числами из перемешанной одномерной коллекции
      for (int i = 0; i < this.BoardHeight; i++)
      {
        for (int j = 0; j < this.BoardWidth; j++)
        {
          this.Board[i, j] = currentNumber.Current;
          currentNumber.MoveNext();
        }
      }
      // Перемена первого и последнего элементов для пустой клетки в конце
      int temp = this.Board[this.BoardHeight - 1, this.BoardWidth - 1];
      this.Board[this.BoardHeight - 1, this.BoardWidth - 1] = 0;
      this.Board[0, 0] = temp;
      this.Pointer = new int[] { this.BoardHeight - 1, this.BoardWidth - 1 };
    }

    // Отрисовка матрицы Пятнашек
    public void PrintBoard()
    {
      Console.Clear();
      string tableRow = "";
      for (int i = 0; i < this.BoardHeight; i++)
      {
        for (int j = 0; j < this.BoardWidth; j++)
        {
          if (this.Board[i, j] == 0)
          {
            // Пустая клетка на месте нуля
            tableRow += "[   ]\t";
            continue;
          }
          tableRow += "[ " + Board[i, j] + " ]\t";
        }
        Console.WriteLine(tableRow + "\n");
        tableRow = "";
      }
      Console.WriteLine("\nСправка:\n- Перемещение ячеек - СТРЕЛКИ");
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
      while (this.IsPlaying);
    }

    // Передвижение указателя вверх
    public void MovePointerUp()
    {
      int temp = this.Pointer[0];
      if (temp-- > 0)
      {
        this.LastPointer[0] = this.Pointer[0];
        this.LastPointer[1] = this.Pointer[1];

        this.Pointer[0]--;
        this.Update();
      }
        
    }

    // Передвижение указателя вниз
    public void MovePointerDown()
    {
      int temp = this.Pointer[0];
      if (temp++ < this.BoardHeight - 1)
      {
        this.LastPointer[0] = this.Pointer[0];
        this.LastPointer[1] = this.Pointer[1];

        this.Pointer[0]++;
        this.Update();
      }
    }

    // Передвижение указателя влево
    public void MovePointerLeft()
    {
      int temp = this.Pointer[1];
      if (temp-- > 0)
      {
        this.LastPointer[0] = this.Pointer[0];
        this.LastPointer[1] = this.Pointer[1];

        this.Pointer[1]--;
        this.Update();
      }
    }

    // Передвижение указателя вправо
    public void MovePointerRight()
    {
      int temp = this.Pointer[1];
      if (temp++ < this.BoardWidth - 1)
      {
        this.LastPointer[0] = this.Pointer[0];
        this.LastPointer[1] = this.Pointer[1];

        this.Pointer[1]++;
        this.Update();
      }
    }

    // Обновление матрицы после передвижения указателя
    public void Update()
    {
      int temp = this.Board[this.Pointer[0], this.Pointer[1]];
      this.Board[this.Pointer[0], this.Pointer[1]] = 0;
      this.Board[this.LastPointer[0], this.LastPointer[1]] = temp;

      this.PrintBoard();

      if (this.Pointer[0] == this.BoardHeight - 1 && this.Pointer[1] == this.BoardWidth - 1)
      {
        if (this.IsWin())
        {
          Console.Clear();
          Console.WriteLine("\nВы выиграли!");
          Console.ReadKey();
          this.Restart();
        }
      }

    }

    // Проверка на выигрыш
    private bool IsWin()
    {
      int index = 1;
      for (int i = 0; i < this.BoardHeight; i++)
      {
        for (int j = 0; j < this.BoardWidth; j++)
        {
          if (i == this.BoardHeight - 1 && j == this.BoardWidth - 1)
            index = 0;
          if (this.Board[i, j] != index)
            return false;
          index++;
        }
      }
      return true;
    }

    // Перезапуск игры
    public void Restart()
    {
      this.BoardWidth = 0;
      this.BoardHeight = 0;
      this.IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Перезапуск игры...");
      Console.ReadKey();

      this.Start();
    }
    
    // Конец игры
    public void Exit()
    {
      this.IsPlaying = false;
      Console.Clear();
      Console.WriteLine("Выход...");
      Environment.Exit(0);
    }

    public Game()
    {
      this.BoardWidth = 0;
      this.BoardHeight = 0;
    }
  }
}
