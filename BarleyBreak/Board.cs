namespace BarleyBreak
{
  public class Board
  {
    // Указатель: Pointer[0], Pointer[1]; и прошлая позиция указателя: Pointer[2], Pointer[3]
    public int[] Pointer { get; private set; }

    // Доска и её параметры
    public int[,]? Array { get; private set; }

    // BoardParams[0] - Width; BoardParams[1] - Height
    public int[] Params { get; private set; }

    // Ограничитель высоты и ширины поля
    public int Limiter { get; private set; }

    // Заполнение матрицы Пятнашек числами
    public void Fill()
    {
      Array = new int[Params[1], Params[0]];
      Random rnd = new Random();
      int maxValue = Params[0] * Params[1];
      IEnumerable<int> numbers = Enumerable.Range(1, maxValue - 1);

      // Перемешивание коллекции в случайном порядке
      numbers = numbers.OrderBy(n => rnd.Next());
      IEnumerator<int> currentNumber = numbers.GetEnumerator();

      // Заполнение двумерного массива числами из перемешанной одномерной коллекции
      for (int i = 0; i < Params[1]; i++)
      {
        for (int j = 0; j < Params[0]; j++)
        {
          Array[i, j] = currentNumber.Current;
          currentNumber.MoveNext();
        }
      }
      // Перемена первого и последнего элементов для пустой клетки в конце
      int temp = Array[Params[1] - 1, Params[0] - 1];
      Array[Params[1] - 1, Params[0] - 1] = 0;
      Array[0, 0] = temp;
      Pointer = new int[4] { Params[1] - 1, Params[0] - 1, Params[1] - 1, Params[0] - 1 };
    }

    // Отрисовка матрицы Пятнашек
    public void Print()
    {
      Console.Clear();
      Console.WriteLine("Игра Пятнашки!\n\nПравила игры:");
      Console.WriteLine("Выстроить заначения в ячейках в правильном порядке:\nслева направо от 1 до N с переносом строки.\nПустая клетка должна быть в правом нижнем углу.\n\n");

      string tableRow = "";
      for (int i = 0; i < Params[1]; i++)
      {
        for (int j = 0; j < Params[0]; j++)
        {
          if (Array[i, j] == 0)
          {
            // Пустая клетка на месте нуля
            tableRow += "[   ]\t";
            continue;
          }
          tableRow += "[ " + Array[i, j] + " ]\t";
        }
        Console.WriteLine(tableRow + "\n");
        tableRow = "";
      }
      Console.WriteLine("Управление:");
      Console.WriteLine("Используйте клавиши ▲, ▼, ◄ и ► для перемещения клетки в пустую ячейку.\nДля рестарта - \"R\", для выхода - \"E\".\n");
    }

    // Сброс значений доски
    public void Reset()
    {
      Pointer = new int[4] { 0, 0, 0, 0, };
      Params = new int[2] { 0, 0 };
    }

    public Board()
    {
      Pointer = new int[4] { 0, 0, 0, 0, };
      Params = new int[2] { 0, 0 };
      Limiter = 4;
    }
  }
}
