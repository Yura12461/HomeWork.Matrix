namespace MyMatrix
{
    class Matrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Матрица\n");
            int[,] matrix = GetMartix();
            Console.WriteLine("Результат : ");
            WriteMatrix(matrix);
            do
            {
                Console.WriteLine("\n1 - Количество положительных и отрицательных чисел \n2 - Сортировка строк" +
                                  "\n3 - Инверсия строки \n9 - Переписать матрицу \n0 - Завершить операцию");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        GetPositievOrNegative(matrix);
                        break;
                    case ConsoleKey.D2:
                        GetSort(matrix); WriteMatrix(matrix);
                        break;
                    case ConsoleKey.D3:
                        GetInversion(matrix); WriteMatrix(matrix);
                        break;
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D9:
                        GetMartix(); WriteMatrix(matrix);
                        break;
                    default:
                        Console.WriteLine("Неверный формат, повторите попытку");
                        break;
                }
                Console.WriteLine("\nЛюбая клавиша - Продолжить \n0 - Выход");
            } while (Console.ReadKey(true).Key != ConsoleKey.D0);

        }
        static int[,] GetMartix()
        {
            Console.Write("Введите количество столбцов - ");
            int y = GetNumber();
            Console.Write("Введите количество строк - ");
            int x = GetNumber();
            int[,] matrix = new int[x, y];
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Введите элемент : {j + 1} строки : {i + 1} - ");
                    matrix[i, j] = GetNumber();
                }
            }
            return matrix;
        }

        static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t" + "\t" + matrix[i, j]);
                }
                Console.WriteLine('\n');
            }
        }
        static int GetNumber()
        {
            bool isnumber;
            int Number;
            do
            {
                isnumber = int.TryParse(Console.ReadLine(), out Number);
                if (isnumber == false) { Console.Write("Неверный формат повторите попытку - "); }
            } while (isnumber == false);
            return Number;
        }
        static void GetPositievOrNegative(int[,] matrix)
        {
            int Negative = 0;
            int Positive = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= 0) Positive++;
                    else Negative++;
                }

            }
            Console.WriteLine("\n1 - Количество положительных \n2 - Количество отрицательных \n0 - Назад");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nКоличество положительных чисел = " + Positive);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("\nКоличество отрицательных чисел = " + Negative); ;
                    break;
                case ConsoleKey.D0: break;
                default:
                    Console.WriteLine("\nНеверный формат, повторите попытку");
                    break;
            }
        }
        static void GetSort(int[,] matrix)
        {
            Console.Write("Введите номер строки для сортировки - ");
            int a = GetNumber();
            a--;
            int increase = 0;
            int decrease = 0;
            Console.WriteLine("\n1 - По возрастанию \n2 - По убыванию");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = i + 1; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[a, i] > matrix[a, j])
                            {
                                increase = matrix[a, i];
                                matrix[a, i] = matrix[a, j];
                                matrix[a, j] = increase;
                            }
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = i + 1; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[a, i] < matrix[a, j])
                            {
                                decrease = matrix[a, i];
                                matrix[a, i] = matrix[a, j];
                                matrix[a, j] = decrease;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Неверный формат, повторите попытку");
                    break;

            }
        }

        static void GetInversion(int[,] matrix)
        {
            Console.Write("Введите номер строки для Инверсии - ");
            int a = GetNumber();
            a--;
            int Inversion = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    Inversion = matrix[a, i];
                    matrix[a, i] = matrix[a, j];
                    matrix[a, j] = Inversion;
                }
            }
        }
    }
}